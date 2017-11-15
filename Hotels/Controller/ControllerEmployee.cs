using Hotels.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Hotels.Controller
{
    public class ControllerEmployee : ControllerPerson
    {
        private ComboBox comboBox;
        private Dictionary<string, Chart> charts = new Dictionary<string, Chart>();
        public ControllerEmployee(Dictionary<string, Chart> Charts)
        {
            foreach (var item in Charts)
            {
                charts.Add(item.Key, item.Value);
            }
        }
        public ControllerEmployee(DataGridView dgv, BindingNavigator bn, Dictionary<string, TextBox> textBoxs, DateTimePicker birth, Dictionary<string, RadioButton> radioButtons,ComboBox cb):base(dgv,bn,textBoxs,birth, radioButtons)
        {
            comboBox = cb;
            comboBox.DataSource = Positions.GetValues(typeof(Positions));
            comboBox.DataBindings.Add("Text", bindingSource, "Position");
        }
        
        public override void LoadDB()
        {
            new Employee().Get();
            FillRows(Employee.AllEmployees.Values.ToArray());
        }

        public override void Save()
        {
            Employee person = new Employee();
            person.FirstName = TextBoxs["FirstName"].Text;
            person.LastName = TextBoxs["LastName"].Text;
            person.Email = TextBoxs["Email"].Text;
            person.Telephone = TextBoxs["Telephone"].Text;
            person.Birth = Birth.Value.Date;
            if (RadioButtons["Male"].Checked)
                person.Gender = "Male";
            else if (RadioButtons["Female"].Checked)
                person.Gender = "Female";
            person.Adress = TextBoxs["Adress"].Text;
            person.Pasport = TextBoxs["Pasport"].Text;
            person.Salary = Convert.ToDecimal(TextBoxs["Salary"].Text);

            person.Position = (Positions)comboBox.SelectedItem;

            if (((DataRowView)bindingSource.Current).IsNew == true)
                person.Insert();
            else
            {
                person.UserRole = (Role)((DataRowView)bindingSource.Current).Row["UserRole"];
                person.ID = (int)((DataRowView)bindingSource.Current).Row["ID"];
                person.Update();
            }
        }

        public override void FillColumns()
        {
            Type myType = typeof(Employee);
            IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());
            DataColumn column;
            foreach (PropertyInfo prop in props)
            {
                column = new DataColumn();
                column.DataType = prop.PropertyType;
                column.ColumnName = prop.Name;
                column.ReadOnly = true;
                dataTable.Columns.Add(column);
            }

            dataTable.Columns["Position"].DataType = typeof(string);

            dataGridView.Columns["Login"].Visible = false;
            dataGridView.Columns["Password"].Visible = false;
            dataGridView.Columns["UserRole"].Visible = false;

            dataGridView.Columns["Male"].Visible = false;
            dataGridView.Columns["Female"].Visible = false;
            dataGridView.Columns["ID"].Visible = false;
            dataTable.Columns["Male"].DefaultValue = true;
            dataTable.Columns["Female"].DefaultValue = false;
        }
        public override void AddRow(Person currentrow)
        {
            Type myType = typeof(Employee);//array[0].GetType();
            IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());
            DataRow row = dataTable.NewRow();
            foreach (PropertyInfo prop in props)
            {
                row[prop.Name] = prop.GetValue(currentrow, null);
            }
            dataTable.Rows.Add(row);
        }

        public void DrawChart()
        {
            new Employee().Get();
            charts["Salary"].ChartAreas[0].AxisY.Interval = 1;
            charts["Age"].ChartAreas[0].AxisY.Interval = 1;
            charts["Salary"].Titles["Salary"].Text = "Зарплата";
            charts["Age"].Titles["Age"].Text = "Вік";
            SalaryChart();
            AgeChart();
        }
        private void SalaryChart()
        { 
            Dictionary<string, int> dictonary = new Dictionary<string, int>();
            dictonary.Add("3200-5000", 0);
            dictonary.Add("5000-10000", 0);
            dictonary.Add("10000>", 0);
            foreach (var item in Employee.AllEmployees.Values.ToList())
            {
                if (item.Salary < 5000)
                    dictonary["3200-5000"]++;
                if (item.Salary >= 5000 && item.Salary < 10000)
                    dictonary["5000-10000"]++;
                if (item.Salary >= 10000)
                    dictonary["10000>"]++;
            }
            foreach (var item in dictonary)
                charts["Salary"].Series["Salary"].Points.AddXY(item.Key, item.Value);
        }

        private void AgeChart()
        {
            Dictionary<string, int> dictonary = new Dictionary<string, int>();
            dictonary.Add("18-20", 0);
            dictonary.Add("20-30", 0);
            dictonary.Add("30-40", 0);
            dictonary.Add("40-50", 0);
            dictonary.Add("50-60", 0);
            foreach (var item in Employee.AllEmployees.Values.ToList())
            {
                int temp = GetEmployeeAge(item);
                if (temp >= 18 && temp < 20)
                    dictonary["18-20"]++;
                if (temp >= 20 && temp < 30)
                    dictonary["20-30"]++;
                if (temp >= 30 && temp < 40)
                    dictonary["30-40"]++;
                if (temp >= 40 && temp < 50)
                    dictonary["40-50"]++;
                if (temp >= 50 && temp < 60)
                    dictonary["50-60"]++;
            }
            foreach (var item in dictonary)
                charts["Age"].Series["Age"].Points.AddXY(item.Key, item.Value);
        }

        public int GetEmployeeAge(Employee employee)
        {
            int age = DateTime.Now.Year - employee.Birth.Date.Year;
            return age;
        }
    }
}
