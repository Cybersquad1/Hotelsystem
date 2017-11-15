using Hotels.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Hotels.Controller
{
    public class ControllerPerson:Controller<Person>
    {
        protected DateTimePicker Birth { get; set; }
        protected Dictionary<string, RadioButton> RadioButtons = new Dictionary<string, RadioButton>();
        protected ComboBox comboRole;
        public ControllerPerson() { }
        public ControllerPerson(DataGridView dgv, BindingNavigator bn):base(dgv,bn){ }
        public ControllerPerson(Dictionary<string, TextBox> textBoxs, DateTimePicker birth, Dictionary<string, RadioButton> radioButtons):base(textBoxs)
        {
            Birth = birth;
            foreach (var item in radioButtons)
            {
                RadioButtons.Add(item.Key, item.Value);
            }
        }
        public ControllerPerson(DataGridView dgv, BindingNavigator bn, Dictionary<string, TextBox> textBoxs, DateTimePicker birth, Dictionary<string, RadioButton> radioButtons) : base(dgv, bn, textBoxs)
        {
            Birth = birth;
            foreach (var item in radioButtons)
            {
                RadioButtons.Add(item.Key, item.Value);
            }
            Birth.DataBindings.Add("Text", bindingSource, "Birth");

            radioButtons["Male"].DataBindings.Add("Checked", bindingSource, "Male");
            radioButtons["Female"].DataBindings.Add("Checked", bindingSource, "Female");
        }
        public ControllerPerson(DataGridView dgv,BindingNavigator bn,Dictionary<string, TextBox> textBoxs, DateTimePicker birth, Dictionary<string, RadioButton> radioButtons, ComboBox comboBox) :base(dgv,bn,textBoxs)
        {
            Birth = birth;
            foreach (var item in radioButtons)
            {
                RadioButtons.Add(item.Key, item.Value);
            }
            Birth.DataBindings.Add("Text", bindingSource, "Birth");

            radioButtons["Male"].DataBindings.Add("Checked", bindingSource, "Male");
            radioButtons["Female"].DataBindings.Add("Checked", bindingSource, "Female");

            comboRole = comboBox;
            comboRole.DataSource = Role.GetValues(typeof(Role));
            comboRole.DataBindings.Add("Text", bindingSource, "UserRole");

            TextBoxs["Password"].PasswordChar = '*';
        }
        
        public override void Save()
        {
            Person person = new Person();
            person.FirstName = TextBoxs["FirstName"].Text;
            person.LastName = TextBoxs["LastName"].Text;
            person.Email = TextBoxs["Email"].Text;
            person.Telephone = TextBoxs["Telephone"].Text;
            person.Login = TextBoxs["Login"].Text;
            person.Password = TextBoxs["Password"].Text;
            person.Birth = Birth.Value.Date;
            person.UserRole = (Role)comboRole.SelectedItem;
            //try { person.UserRole = TextBoxs["UserRole"].Text; } catch { person.UserRole = "Client"; }
            if (RadioButtons["Male"].Checked)
                person.Gender = "Male";
            else if (RadioButtons["Female"].Checked)
                person.Gender = "Female";

            if (((DataRowView)bindingSource.Current).IsNew==true)
                person.Insert();               
            else
            {
                person.ID = (int)((DataRowView)bindingSource.Current).Row["ID"];
                person.Update();
            }
        }

        public override void Delete()
        {
            Person person = new Person();
            person.ID = (int)((DataRowView)bindingSource.Current).Row["ID"];
            person.Delete();
        }
        public override void LoadDB()
        {
            new Person().Get();
            FillRows(Person.Items.Values.ToArray());
        }
        public override void FillColumns()
        {
            base.FillColumns();

            dataGridView.Columns["Male"].Visible = false;
            dataGridView.Columns["Female"].Visible = false;
            dataGridView.Columns["ID"].Visible = false;
            dataGridView.Columns["Password"].Visible = false;
            dataTable.Columns["Male"].DefaultValue = true;
            dataTable.Columns["Female"].DefaultValue = false;
            dataTable.Columns["UserRole"].DataType = typeof(string);
            dataTable.Columns["UserRole"].DefaultValue = "Client" ;
            
        }
    }
}
