using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Model
{
    public class HotelEmployee:Base<HotelEmployee>
    {

        private int _hotelID;
        public Hotel Hotel
        {
            get
            {
                if (_hotelID == -1)
                    return null;
                return Hotel.Items[_hotelID];
            }
            set
            {
                if (value == null)
                    _hotelID = -1;
                else
                    _hotelID = value.ID;
            }
        }
        private int _employeeID;
        public Employee Employee
        {
            get
            {
                if (_employeeID == -1)
                    return null;
                return Employee.AllEmployees[_employeeID];
            }
            set
            {
                if (value == null)
                    _employeeID = -1;
                else
                    _employeeID = value.ID;
            }
        }

        public HotelEmployee() { }
        public HotelEmployee(Hotel ht, Employee em)
        {
            Hotel = ht; Employee = em;
        }
        //DB
        public override void Insert()
        {
            try
            {
                conn.Open();
                string query = @"insert into tbHotelEmployee
                            (_hotelID,_employeeID)
                            values (@_hotelID,@_employeeID)";
                // 2. define parameters used in command object
                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@_hotelID";
                param1.Value = this._hotelID;
                SqlParameter param2 = new SqlParameter();
                param2.ParameterName = "@_employeeID";
                param2.Value = this._employeeID;

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(param1);
                cmd.Parameters.Add(param2);
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
                string query = @"select * from tbHotelEmployee";
                // 1. Instantiate a new command with a query and connection
                SqlCommand cmd = new SqlCommand(query, conn);

                // 2. Call Execute reader to get query results
                SqlDataReader rdr = cmd.ExecuteReader();
                Items.Clear();
                while (rdr.Read())
                {
                    HotelEmployee temp = new HotelEmployee();
                    temp.ID = Convert.ToInt32(rdr[0]);
                    temp._hotelID = Convert.ToInt32(rdr[1]);
                    temp._employeeID = Convert.ToInt32(rdr[2]);
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
        public override void Update()
        {
            try
            {
                conn.Open();
                // prepare command string
                string query = @"
                update tbHotelEmployee
                set _hotelID = @_hotelID,
                    _employeeID = @_employeeID
                where HotelEmployeeID = @HotelEmployeeID";

                // 1. Instantiate a new command with command text only

                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@_hotelID";
                param1.Value = this._hotelID;
                SqlParameter param2 = new SqlParameter();
                param2.ParameterName = "@_employeeID";
                param2.Value = this._employeeID;
                SqlParameter param3 = new SqlParameter();
                param3.ParameterName = "@HotelEmployeeID";
                param3.Value = this.ID;

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(param1);
                cmd.Parameters.Add(param2);
                cmd.Parameters.Add(param3);
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
                 delete from tbHotelEmployee
                 where HotelEmployeeID = @HotelEmployeeID";
                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@HotelEmployeeID";
                param1.Value = this.ID;
                // 1. Instantiate a new command
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(param1);
                cmd.ExecuteNonQuery();

            }
            finally
            {
                // Close the connection
                if (conn != null)
                {
                    conn.Close();
                    //Items.Remove(this.ID);
                }
            }
        }
    }
}
