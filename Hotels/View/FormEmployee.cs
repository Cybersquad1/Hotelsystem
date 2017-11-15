using Hotels.Controller;
using Hotels.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotels.View
{
    public partial class FormEmployee : Form
    {
        ControllerEmployee controller;
        public FormEmployee()
        {
            InitializeComponent();
            Dictionary<string, TextBox> textBoxs = new Dictionary<string, TextBox>();
            Dictionary<string, RadioButton> radioButtons = new Dictionary<string, RadioButton>();
            textBoxs.Add("FirstName", tbFirstName);
            textBoxs.Add("LastName", tbLastName);
            textBoxs.Add("Email", tbEmail);
            textBoxs.Add("Telephone", tbTelephone);
            textBoxs.Add("Adress", tbAdress);
            textBoxs.Add("Salary", tbSalary);
            textBoxs.Add("Pasport", tbPasport);
            radioButtons.Add("Male", rBMale);
            radioButtons.Add("Female", rBFemale);

            controller = new ControllerEmployee(dgv, bn, textBoxs, dTPBirth, radioButtons,cbPosition);
            controller.FillColumns();
        }

        private void FormEmployee_Load(object sender, EventArgs e)
        {
            controller.LoadDB();

        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            controller.Save();
            controller.LoadDB();
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            controller.Delete();
            controller.LoadDB();
        }

       
    }
}
