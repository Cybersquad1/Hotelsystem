using Hotels.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotels.Controller
{
    public class ControllerHotelEmployee:Controller<HotelEmployee>
    {
        ComboBox cbHotel;
        ComboBox cbEmployee;
        HotelEmployee currentHotelEmployee;
        public ControllerHotelEmployee(DataGridView dgv, BindingNavigator bn, Dictionary<string, TextBox> textBoxs, ComboBox cbHotel, ComboBox cbEmployee) : base(dgv, bn, textBoxs)
        {
            this.cbHotel = cbHotel; this.cbEmployee = cbEmployee;
            //this.cbHotel.DataBindings.Add("Text", bindingSource, "Hotel");
            //this.cbEmployee.DataBindings.Add("Text", bindingSource, "Employee");
            currentHotelEmployee = new HotelEmployee();
        }
        public override void Delete()
        {
            currentHotelEmployee.Hotel = (Hotel)((DataRowView)bindingSource.Current).Row["Hotel"];
            currentHotelEmployee.ID = (int)((DataRowView)bindingSource.Current).Row["ID"];
            currentHotelEmployee.Delete();
        }

        public override void LoadDB()
        {
            new Employee().Get();
            new Hotel().Get();
            new HotelEmployee().Get();
            //FillRows(HotelEmployee.Items.Values.ToArray());
            cbHotel.DataSource = Hotel.Items.Values.ToList();
            cbEmployee.DataSource = Employee.AllEmployees.Values.ToList();
            try { cbHotel.SelectedItem = currentHotelEmployee.Hotel; } catch { }
            ChangeHotel();
        }

        public override void Save()
        {
            currentHotelEmployee.Hotel = (Hotel)cbHotel.SelectedItem;
            currentHotelEmployee.Employee = (Employee)cbEmployee.SelectedItem;

            if (((DataRowView)bindingSource.Current).IsNew == true)
                currentHotelEmployee.Insert();
            else
            {
                currentHotelEmployee.ID = (int)((DataRowView)bindingSource.Current).Row["ID"];
                currentHotelEmployee.Update();
            }
        }

        public void ChangeHotel()
        {
            try
            {
                FillRows(((Hotel)(cbHotel.SelectedItem)).HotelEmployees.ToArray());
            }
            catch { }
        }
        public void Add()
        {
            ((DataRowView)bindingSource.Current).Row["Hotel"] = (Hotel)cbHotel.SelectedItem;
            cbEmployee.SelectedItem = null;
        }
    }
}
