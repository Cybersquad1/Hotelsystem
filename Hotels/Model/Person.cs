using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace Hotels.Model
{
    public enum Role { Client, Administrator, Concierge, Worker };
    public class Person:Base<Person>
    {
        //Property
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime Birth { get; set; }
        public string Telephone { get; set; }
        public string Gender { get; set; }
        public Role UserRole { get; set; }
        

        public bool Male
        {
            get
            {
                if (Gender == "Male")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            set
            {
                if (value.Equals(true))
                {
                    Gender = "Male";
                }
            }
        }
        public bool Female
        {
            get
            {
                if (Gender == "Female")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            set
            {
                if (value.Equals(true))
                {
                    Gender = "Female";
                }
            }
        }
        public Person(){}
        public Person(string firstName,string lastName,string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        //DB
        public override void Insert()
        {
            try
            {
                conn.Open();
                string query = @"insert into tbPerson
                            (FirstName,LastName,Email,Login,Password,Birth,Telephone,Gender,Role)
                            values (@FirstName,@LastName,@Email,@Login,@Password,@Birth,@Telephone,@Gender,@Role)";
                // 2. define parameters used in command object
                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@FirstName";
                param1.Value = this.FirstName;
                SqlParameter param2 = new SqlParameter();
                param2.ParameterName = "@LastName";
                param2.Value = this.LastName;
                SqlParameter param3 = new SqlParameter();
                param3.ParameterName = "@Email";
                param3.Value = this.Email;
                SqlParameter param4 = new SqlParameter();
                param4.ParameterName = "@Birth";
                param4.Value = this.Birth;
                SqlParameter param5 = new SqlParameter();
                param5.ParameterName = "@Telephone";
                param5.Value = this.Telephone;
                SqlParameter param6 = new SqlParameter();
                param6.ParameterName = "@Login";
                param6.Value = this.Login;
                SqlParameter param7 = new SqlParameter();
                param7.ParameterName = "@Password";
                param7.Value = this.Password;
                SqlParameter param8 = new SqlParameter();
                param8.ParameterName = "@Gender";
                param8.Value = this.Gender;
                SqlParameter param9 = new SqlParameter();
                param9.ParameterName = "@Role";
                param9.Value = this.UserRole.ToString();

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(param1);
                cmd.Parameters.Add(param2);
                cmd.Parameters.Add(param3);
                cmd.Parameters.Add(param4);
                cmd.Parameters.Add(param5);
                cmd.Parameters.Add(param6);
                cmd.Parameters.Add(param7);
                cmd.Parameters.Add(param8);
                cmd.Parameters.Add(param9);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                // Close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }

        }
        public override void Get()
        {
            try
            {
                conn.Open();
                string query = @"select PersonID,FirstName,LastName,Email,
                                        Login, Password,Role,Birth,Telephone,Gender 
                                        from tbPerson";
                // 1. Instantiate a new command with a query and connection
                SqlCommand cmd = new SqlCommand(query, conn);

                // 2. Call Execute reader to get query results
                SqlDataReader rdr = cmd.ExecuteReader();
                List<Person> list = new List<Person>();
                Items.Clear();
                while (rdr.Read())
                {
                    Person temp = new Person();
                    temp.ID = Convert.ToInt32(rdr[0]);
                    temp.FirstName = rdr[1].ToString();
                    temp.LastName = rdr[2].ToString();
                    temp.Email = rdr[3].ToString();
                    temp.Login = rdr[4].ToString();
                    temp.Password = rdr[5].ToString();
                    switch (rdr[6].ToString())
                    {
                        case "Administrator":
                            temp.UserRole = Role.Administrator;
                            break;
                        case "Worker":
                            temp.UserRole = Role.Worker;
                            break;
                        case "Concierge":
                            temp.UserRole = Role.Concierge;
                            break;
                        default:
                            temp.UserRole = Role.Client;
                            break;
                    }
                    try { temp.Birth = (DateTime)rdr[7]; } catch { }
                    temp.Telephone = rdr[8].ToString();
                    temp.Gender = rdr[9].ToString();
                    //словник об'єктів
                    Items.Add(temp.ID, temp);
                }
                conn.Close();
            }
            finally
            {
                // Close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
        public void Select(int id)
        {
            try
            {
                conn.Open();
                string query = @"select PersonID,FirstName,LastName,Email,
                                        Login, Password,Role,Birth,Telephone,Gender 
                                        from tbPerson where PersonID = @PersonID";
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@PersonID";
                param.Value = this.ID;
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(param);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ID = Convert.ToInt32(rdr[0]);
                    FirstName = rdr[1].ToString();
                    LastName = rdr[2].ToString();
                    Email = rdr[3].ToString();
                    Login = rdr[4].ToString();
                    Password = rdr[5].ToString();
                    switch (rdr[6].ToString())
                    {
                        case "Administrator":
                            UserRole = Role.Administrator;
                            break;
                        case "Worker":
                            UserRole = Role.Worker;
                            break;
                        case "Concierge":
                            UserRole = Role.Concierge;
                            break;
                        default:
                            UserRole = Role.Client;
                            break;
                    }
                    try { Birth = (DateTime)rdr[7]; } catch { }
                    Telephone = rdr[8].ToString();
                    Gender = rdr[9].ToString();
                }
                conn.Close();
            }
            finally
            {
                // Close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
        public bool Select(string login, string password)
        {
            bool flag = false;
            try
            {

                conn.Open();
                string query = @"select * from tbPerson
                                 where Login = @Login and Password = @Password";
                // 1. Instantiate a new command with a query and connection
                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@Login";
                param1.Value = login;
                SqlParameter param2 = new SqlParameter();
                param2.ParameterName = "@Password";
                param2.Value = password;

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(param1);
                cmd.Parameters.Add(param2);
                // 2. Call Execute reader to get query results
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ID = Convert.ToInt32(rdr[0]);
                    FirstName = rdr[1].ToString();
                    LastName = rdr[2].ToString();
                    Email = rdr[3].ToString();
                    Login = rdr[4].ToString();
                    Password = rdr[5].ToString();
                    switch (rdr[6].ToString())
                    {
                        case "Administrator":
                            UserRole = Role.Administrator;
                            break;
                        case "Worker":
                            UserRole = Role.Worker;
                            break;
                        case "Concierge":
                            UserRole = Role.Concierge;
                            break;
                        default:
                            UserRole = Role.Client;
                            break;
                    }
                    try { Birth = (DateTime)rdr[7]; } catch { }
                    Telephone = rdr[8].ToString();
                    Gender = rdr[9].ToString();
                    flag = true;
                }
                conn.Close();
            }
            finally
            {
                // Close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return flag;
        }

        public override void Update()
        {
            try
            {
                conn.Open();
                // prepare command string
                string query = @"
                update tbPerson
                set FirstName = @FirstName,
                    LastName = @LastName,
                    Email = @Email,
                    Telephone = @Telephone,
                    Login = @Login,
                    Password = @Password,
                    Gender = @Gender,
                    Birth = @Birth,
                    Role = @Role
                where PersonID = @PersonID";

                // 1. Instantiate a new command with command text only
                
                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@FirstName";
                param1.Value = this.FirstName;
                SqlParameter param2 = new SqlParameter();
                param2.ParameterName = "@LastName";
                param2.Value = this.LastName;
                SqlParameter param3 = new SqlParameter();
                param3.ParameterName = "@Email";
                param3.Value = this.Email;
                SqlParameter param4 = new SqlParameter();
                param4.ParameterName = "@Login";
                param4.Value = this.Login;
                SqlParameter param5 = new SqlParameter();
                param5.ParameterName = "@Password";
                param5.Value = this.Password;
                SqlParameter param6 = new SqlParameter();
                param6.ParameterName = "@Telephone";
                param6.Value = this.Telephone;
                SqlParameter param7 = new SqlParameter();
                param7.ParameterName = "@PersonID";
                param7.Value = this.ID;
                SqlParameter param8 = new SqlParameter();
                param8.ParameterName = "@Birth";
                param8.Value = this.Birth;
                SqlParameter param9 = new SqlParameter();
                param9.ParameterName = "@Gender";
                param9.Value = this.Gender;
                SqlParameter param10 = new SqlParameter();
                param10.ParameterName = "@Role";
                param10.Value = this.UserRole.ToString();

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(param1);
                cmd.Parameters.Add(param2);
                cmd.Parameters.Add(param3);
                cmd.Parameters.Add(param4);
                cmd.Parameters.Add(param5);
                cmd.Parameters.Add(param6);
                cmd.Parameters.Add(param7);
                cmd.Parameters.Add(param8);
                cmd.Parameters.Add(param9);
                cmd.Parameters.Add(param10);
                // 3. Call ExecuteNonQuery to send command
                cmd.ExecuteNonQuery();
            }
            finally
            {
                // Close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
        public override void Delete()
        {
            try
            {               
                // Open the connection
                conn.Open();

                // prepare command string
                string query = @"
                 delete from tbPerson
                 where PersonID = @PersonID";
                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@PersonID";
                param1.Value = this.ID;
                // 1. Instantiate a new command
                SqlCommand cmd = new SqlCommand(query,conn);
                cmd.Parameters.Add(param1);
                cmd.ExecuteNonQuery();

            }
            finally
            {
                // Close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        public override string ToString()
        {
            return FirstName + " "+ LastName;
        }
    }
}
