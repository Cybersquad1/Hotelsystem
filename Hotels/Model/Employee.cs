using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Model
{
    public enum Positions  {Administrator,Service,Concierge, Bookkeeper};
    public class Employee:Person
    {
        public static Dictionary<int, Employee> AllEmployees = new Dictionary<int, Employee>();
        public decimal Salary { get; set; }
        public Positions Position { get; set; }
        public string Pasport { get; set; }
        public string Adress { get; set; }

        public List<Hotel> Hotels
        {
            get
            {
                var res = new List<Hotel>();
                foreach (var ht in HotelEmployee.Items.Values)
                    if (ht.Employee == this)
                        res.Add(ht.Hotel);
                return res;
            }
        }

        public  override void Get()
        {
            try
            {
                conn.Open();
                string query = @"select PersonID,FirstName,LastName,Email,
                                        Birth,Telephone,Gender,
                                        Salary,Pasport,Adress,Position,Role 
                                        from tbPerson where NOT Role = 'Client'";
                // 1. Instantiate a new command with a query and connection
                SqlCommand cmd = new SqlCommand(query, conn);

                // 2. Call Execute reader to get query results
                SqlDataReader rdr = cmd.ExecuteReader();
                List<Person> list = new List<Person>();
                AllEmployees.Clear();
                while (rdr.Read())
                {
                    Employee temp = new Employee();
                    temp.ID = Convert.ToInt32(rdr[0]);
                    temp.FirstName = rdr[1].ToString();
                    temp.LastName = rdr[2].ToString();
                    temp.Email = rdr[3].ToString();
                    try { temp.Birth = (DateTime)rdr[4]; } catch { }
                    temp.Telephone = rdr[5].ToString();
                    temp.Gender = rdr[6].ToString();
                    try {
                        temp.Salary = Convert.ToDecimal(rdr[7]);
                        temp.Pasport = rdr[8].ToString();
                        temp.Adress = rdr[9].ToString();
                    }
                    catch { }
                    switch (rdr[10].ToString())
                    {
                        case "Administrator":
                            temp.Position = Positions.Administrator;
                            break;
                        case "Consierge":
                            temp.Position = Positions.Concierge;
                            break;
                        case "Service":
                            temp.Position = Positions.Service;
                            break;
                        case "Bookkeeper":
                            temp.Position = Positions.Bookkeeper;
                            break;
                            //default:
                            //    temp.Position = Positions.Service;
                            //    break;
                    }
                    switch (rdr[11].ToString())
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

                    //словник об'єктів
                    AllEmployees.Add(temp.ID, temp);
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
        public override void Insert()
        {
            try
            {
                conn.Open();
                string query = @"insert into tbPerson
                            (Salary,Pasport,Adress,Position,FirstName,LastName,Email,Birth,Telephone,Gender,Role)
                            values (@Salary,@Pasport,@Adress,@Position,@FirstName,@LastName,@Email,@Birth,@Telephone,@Gender,@UserRole)";
                // 2. define parameters used in command object
                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@Salary";
                param1.Value = this.Salary;
                SqlParameter param2 = new SqlParameter();
                param2.ParameterName = "@Pasport";
                param2.Value = this.Pasport;
                SqlParameter param3 = new SqlParameter();
                param3.ParameterName = "@Adress";
                param3.Value = this.Adress;
                SqlParameter param4 = new SqlParameter();
                param4.ParameterName = "@Position";
                param4.Value = this.Position.ToString();
                SqlParameter param5 = new SqlParameter();
                param5.ParameterName = "@FirstName";
                param5.Value = this.FirstName;
                SqlParameter param6 = new SqlParameter();
                param6.ParameterName = "@LastName";
                param6.Value = this.LastName;
                SqlParameter param7 = new SqlParameter();
                param7.ParameterName = "@Email";
                param7.Value = this.Email;
                SqlParameter param8 = new SqlParameter();
                param8.ParameterName = "@Birth";
                param8.Value = this.Birth;
                SqlParameter param9 = new SqlParameter();
                param9.ParameterName = "@Telephone";
                param9.Value = this.Telephone;
                SqlParameter param10 = new SqlParameter();
                param10.ParameterName = "@Gender";
                param10.Value = this.Gender;
                SqlParameter param11 = new SqlParameter();
                param11.ParameterName = "@UserRole";
                param11.Value = Role.Worker.ToString();
                

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
                cmd.Parameters.Add(param11);

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
        public override void Update()
        {
            try
            {
                conn.Open();
                // prepare command string
                string query = @"
                update tbPerson
                set Salary = @Salary,
                    Pasport = @Pasport,
                    Adress = @Adress,
                    Position = @Position,
                    FirstName = @FirstName,
                    LastName = @LastName,
                    Email = @Email,
                    Telephone = @Telephone,
                    Gender = @Gender,
                    Birth = @Birth,
                    Role = @UserRole
                where PersonID = @PersonID";

                // 1. Instantiate a new command with command text only

                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@Salary";
                param1.Value = this.Salary;
                SqlParameter param2 = new SqlParameter();
                param2.ParameterName = "@Pasport";
                param2.Value = this.Pasport;
                SqlParameter param3 = new SqlParameter();
                param3.ParameterName = "@Adress";
                param3.Value = this.Adress;
                SqlParameter param4 = new SqlParameter();
                param4.ParameterName = "@Position";
                param4.Value = this.Position.ToString();
                SqlParameter param5 = new SqlParameter();
                param5.ParameterName = "@FirstName";
                param5.Value = this.FirstName;
                SqlParameter param6 = new SqlParameter();
                param6.ParameterName = "@LastName";
                param6.Value = this.LastName;
                SqlParameter param7 = new SqlParameter();
                param7.ParameterName = "@Email";
                param7.Value = this.Email;
                SqlParameter param8 = new SqlParameter();
                param8.ParameterName = "@Birth";
                param8.Value = this.Birth;
                SqlParameter param9 = new SqlParameter();
                param9.ParameterName = "@Telephone";
                param9.Value = this.Telephone;
                SqlParameter param10 = new SqlParameter();
                param10.ParameterName = "@Gender";
                param10.Value = this.Gender;
                SqlParameter param11 = new SqlParameter();
                param11.ParameterName = "@PersonID";
                param11.Value = this.ID;
                SqlParameter param12 = new SqlParameter();
                param12.ParameterName = "@UserRole";
                param12.Value = this.UserRole.ToString();

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
                cmd.Parameters.Add(param11);
                cmd.Parameters.Add(param12);
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

        public override string ToString()
        {
            return FirstName.Substring(0,1) + ". " + LastName + " " + Position.ToString();
        }
    }
}
