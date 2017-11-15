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
    public partial class FormPerson : Form
    {
        ControllerPerson controller;
        
        public FormPerson()
        {
            InitializeComponent();
            //LoadDB();
            Dictionary<string, TextBox>  textBoxs = new Dictionary<string, TextBox>();
            Dictionary<string, RadioButton> radioButtons = new Dictionary<string, RadioButton>();
            textBoxs.Add("FirstName", tbFirstName);
            textBoxs.Add("LastName", tbLastName);
            textBoxs.Add("Email", tbEmail);
            textBoxs.Add("Telephone", tbTelephone);
            textBoxs.Add("Login", tbLogin);
            textBoxs.Add("Password", tbPassword);
            //textBoxs.Add("UserRole", tbRole);
            radioButtons.Add("Male", rBMale);
            radioButtons.Add("Female", rBFemale);
            controller = new ControllerPerson(dGVPerson, bindingNavigatorFormPerson,textBoxs,dTPBirth, radioButtons,cbRole);
            controller.FillColumns();
        }

        private void FormPerson_Load(object sender, EventArgs e)
        {
            controller.LoadDB();
        }     
        private void saveToolStripButton_Click_1(object sender, EventArgs e)
        {
            //saveToolStripButton.Enabled = false;
            controller.Save();
            controller.LoadDB();
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            //saveToolStripButton.Enabled = true;
            
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            controller.Delete();
            controller.LoadDB();
        }

        private void rBMale_CheckedChanged(object sender, EventArgs e)
        {
            //controller.Gender = "Male";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cbRole_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
