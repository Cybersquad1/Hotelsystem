using Hotels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotels.Controller
{
    public class ControllerProfile : ControllerPerson
    {
        public static Client User = new Client();
        private bool newProfile;

        public ControllerProfile() { }
        public ControllerProfile(Dictionary<string, TextBox> textBoxs, DateTimePicker birth, Dictionary<string, RadioButton> radioButtons) : base(textBoxs, birth, radioButtons) { }

        public bool Authentication()
        {
            try
            {
                Microsoft.Win32.RegistryKey Rkey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("HotelsLicense");
                return User.Select(Convert.ToString(Rkey.GetValue("Login")), Convert.ToString(Rkey.GetValue("Password")));
            }
            catch { return false; }
        }
        public bool Authentication(string login, string password)
        {
            try
            {
                bool flag = User.Select(login, password);
                return flag;
            }
            catch { return false; }
        }
        public void LoadProfile()
        {
            TextBoxs["FirstName"].Text = User.FirstName;
            TextBoxs["LastName"].Text = User.LastName;
            TextBoxs["Email"].Text = User.Email;
            TextBoxs["Telephone"].Text = User.Telephone;
            TextBoxs["Login"].Text = User.Login;
            TextBoxs["Password"].Text = User.Password;
            TextBoxs["Password2"].Text = User.Password;
            Birth.Value = User.Birth;
            if (User.Gender == "Male")
                RadioButtons["Male"].Checked = true;
            else if (User.Gender == "Female")
                RadioButtons["Female"].Checked = true;
        }
        public void UpdateProfile()
        {
            //Person person = new Person();
            User.FirstName = TextBoxs["FirstName"].Text;
            User.LastName = TextBoxs["LastName"].Text;
            User.Email = TextBoxs["Email"].Text;
            User.Telephone = TextBoxs["Telephone"].Text;
            User.Login = TextBoxs["Login"].Text;
            User.Password = TextBoxs["Password"].Text;
            User.Birth = Birth.Value.Date;
            if (RadioButtons["Male"].Checked)
                User.Gender = "Male";
            else if (RadioButtons["Female"].Checked)
                User.Gender = "Female";
            if(newProfile)
            {
                User.UserRole = Role.Client;
                User.Insert();
            }
            else
            {
                User.ID = User.ID;
                User.UserRole = User.UserRole;
                User.Update();
            }
            
            SaveRegister();
        }
        public void NewProfile()
        {
            newProfile = true;
        }
        public void ChangeProfile()
        {
            newProfile = false;
        }
        public void SaveRegister()
        {
            ////додаємо поточного користувача в реєстр
            Microsoft.Win32.RegistryKey key;
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("HotelsLicense");
            key.SetValue("Login", User.Login);
            key.SetValue("Password", User.Password);
            key.Close();
        }

        

        
    }
}
