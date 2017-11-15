using Hotels.Controller;
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
    public partial class FormProfile : Form
    {
        ControllerProfile controller;
        public FormProfile()
        {
            InitializeComponent();
            Dictionary<string, TextBox> textBoxs = new Dictionary<string, TextBox>();
            Dictionary<string, RadioButton> radioButtons = new Dictionary<string, RadioButton>();
            textBoxs.Add("FirstName", tbFirstName);
            textBoxs.Add("LastName", tbLastName);
            textBoxs.Add("Email", tbEmail);
            textBoxs.Add("Telephone", tbTelephone);
            textBoxs.Add("Login", tbLogin);
            textBoxs.Add("Password", tbPassword1);
            textBoxs.Add("Password2", tbPassword2);
            radioButtons.Add("Male", rBMale);
            radioButtons.Add("Female", rBFemale);
            controller = new ControllerProfile(textBoxs, dTPBirth, radioButtons);
        }
        private void FormProfile_Load(object sender, EventArgs e)
        {
            controller.ChangeProfile();
            controller.LoadProfile();
        }
        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (tbPassword1.Text != "" && tbPassword2.Text != "")
            {
                if (tbPassword1.Text == tbPassword2.Text)
                {
                    controller.UpdateProfile();
                    MessageBox.Show("Профіль оновлений", "Оновлення пройшло успішно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Паролі не збігаються", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Введіть пароль", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void checkBoxShow_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBoxShow.Checked)
            {
                tbPassword1.PasswordChar = '\0';
                tbPassword2.PasswordChar = '\0';
            }
            else
            {
                tbPassword1.PasswordChar = '*';
                tbPassword2.PasswordChar = '*';
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
