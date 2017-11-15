using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Model
{
    public class Hotel : Base<Hotel>
    {
        //Property
        public string Name { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }

        public List<RoomType> RoomTypes
        {
            get
            {
                var res = new List<RoomType>();
                foreach (var ht in HotelRoomType.Items.Values)
                    if (ht.Hotel == this)
                        res.Add(ht.RoomType);
                return res;
            }
        }

        public List<HotelRoomType> HotelRoomTypes
        {
            get
            {
                var res = new List<HotelRoomType>();
                foreach (var ht in HotelRoomType.Items.Values)
                    if (ht.Hotel == this)
                        res.Add(ht);
                return res;
            }
        }
        public List<Employee> Employees
        {
            get
            {
                var res = new List<Employee>();
                foreach (var he in HotelEmployee.Items.Values)
                    if (he.Hotel == this)
                        res.Add(he.Employee);
                return res;
            }
        }
        public List<HotelEmployee> HotelEmployees
        {
            get
            {
                var res = new List<HotelEmployee>();
                foreach (var ht in HotelEmployee.Items.Values)
                    if (ht.Hotel == this)
                        res.Add(ht);
                return res;
            }
        }
        public List<Room> Rooms
        {
            get
            {
                var res = new List<Room>();
                foreach (var rm in Room.Items.Values)
                    if (rm.Hotel == this)
                        res.Add(rm);
                return res;
            }
        }

        public override string ToString()
        {
            return Name;
        }
        //DB
        public override void Insert()
        {
            try
            {
                conn.Open();
                string query = @"insert into tbHotel
                            (Name,City,Street,Email,Telephone)
                            values (@Name,@City,@Street,@Email,@Telephone)";
                // 2. define parameters used in command object
                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@Name";
                param1.Value = this.Name;
                SqlParameter param2 = new SqlParameter();
                param2.ParameterName = "@City";
                param2.Value = this.City;
                SqlParameter param3 = new SqlParameter();
                param3.ParameterName = "@Street";
                param3.Value = this.Street;
                SqlParameter param4 = new SqlParameter();
                param4.ParameterName = "@Email";
                param4.Value = this.Email;
                SqlParameter param5 = new SqlParameter();
                param5.ParameterName = "@Telephone";
                param5.Value = this.Telephone;

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(param1);
                cmd.Parameters.Add(param2);
                cmd.Parameters.Add(param3);
                cmd.Parameters.Add(param4);
                cmd.Parameters.Add(param5);
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
                string query = @"select * from tbHotel";
                // 1. Instantiate a new command with a query and connection
                SqlCommand cmd = new SqlCommand(query, conn);

                // 2. Call Execute reader to get query results
                SqlDataReader rdr = cmd.ExecuteReader();
                Items.Clear();
                while (rdr.Read())
                {
                    Hotel temp = new Hotel();
                    temp.ID = Convert.ToInt32(rdr[0]);
                    temp.Name = rdr[1].ToString();
                    temp.City = rdr[2].ToString();
                    temp.Street = rdr[3].ToString();
                    temp.Email = rdr[4].ToString();
                    temp.Telephone = rdr[5].ToString();
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
                update tbHotel
                set Name = @Name,
                    City = @City,
                    Street = @Street,
                    Email = @Email,
                    Telephone = @Telephone
                where HotelID = @HotelID";

                // 1. Instantiate a new command with command text only

                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@Name";
                param1.Value = this.Name;
                SqlParameter param2 = new SqlParameter();
                param2.ParameterName = "@City";
                param2.Value = this.City;
                SqlParameter param3 = new SqlParameter();
                param3.ParameterName = "@Street";
                param3.Value = this.Street;
                SqlParameter param4 = new SqlParameter();
                param4.ParameterName = "@Email";
                param4.Value = this.Email;
                SqlParameter param5 = new SqlParameter();
                param5.ParameterName = "@Telephone";
                param5.Value = this.Telephone;
                SqlParameter param6 = new SqlParameter();
                param6.ParameterName = "@HotelID";
                param6.Value = this.ID;
                

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(param1);
                cmd.Parameters.Add(param2);
                cmd.Parameters.Add(param3);
                cmd.Parameters.Add(param4);
                cmd.Parameters.Add(param5);
                cmd.Parameters.Add(param6);
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
                 delete from tbHotel
                 where HotelID = @HotelID";
                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@HotelID";
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
