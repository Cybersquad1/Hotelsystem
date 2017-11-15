using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Model
{
    public class RoomType:Base<RoomType>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public short MaxPerson { get; set; }
        
        //public int HotelID { get; set; }

        public List<Hotel> Hotels
        {
            get
            {
                var res = new List<Hotel>();
                foreach (var ht in HotelRoomType.Items.Values)
                    if (ht.RoomType == this)
                        res.Add(ht.Hotel);
                return res;
            }
        }
        public List<Room> Rooms
        {
            get
            {
                var res = new List<Room>();
                foreach (var rm in Room.Items.Values)
                    if (rm.RoomType == this)
                        res.Add(rm);
                return res;
            }
        }
        public override string ToString()
        {
            return Name;
        }
        public override void Insert()
        {
            try
            {
                conn.Open();
                string query = @"insert into tbRoomType
                            (Name,Description,Price,MaxPerson)
                            values (@Name,@Description,@Price,@MaxPerson)";
                // 2. define parameters used in command object
                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@Name";
                param1.Value = this.Name;
                SqlParameter param2 = new SqlParameter();
                param2.ParameterName = "@Description";
                param2.Value = this.Description;
                SqlParameter param3 = new SqlParameter();
                param3.ParameterName = "@Price";
                param3.Value = this.Price;
                SqlParameter param4 = new SqlParameter();
                param4.ParameterName = "@MaxPerson";
                param4.Value = this.MaxPerson;

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(param1);
                cmd.Parameters.Add(param2);
                cmd.Parameters.Add(param3);
                cmd.Parameters.Add(param4);
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
                string query = @"select * from tbRoomType";
                // 1. Instantiate a new command with a query and connection
                SqlCommand cmd = new SqlCommand(query, conn);

                // 2. Call Execute reader to get query results
                SqlDataReader rdr = cmd.ExecuteReader();
                Items.Clear();
                while (rdr.Read())
                {
                    RoomType temp = new RoomType();
                    temp.ID = Convert.ToInt32(rdr[0]);
                    temp.Name = rdr[1].ToString();
                    temp.Description = rdr[2].ToString();
                    temp.Price = Convert.ToDecimal(rdr[3]);
                    temp.MaxPerson = Convert.ToInt16(rdr[4]);
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
                update tbRoomType
                set Name = @Name,
                    Description = @Description,
                    Price = @Price,
                    MaxPerson = @MaxPerson
                where RoomTypeID = @RoomTypeID";

                // 1. Instantiate a new command with command text only

                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@Name";
                param1.Value = this.Name;
                SqlParameter param2 = new SqlParameter();
                param2.ParameterName = "@Description";
                param2.Value = this.Description;
                SqlParameter param3 = new SqlParameter();
                param3.ParameterName = "@Price";
                param3.Value = this.Price;
                SqlParameter param4 = new SqlParameter();
                param4.ParameterName = "@MaxPerson";
                param4.Value = this.MaxPerson;
                SqlParameter param5 = new SqlParameter();
                param5.ParameterName = "@RoomTypeID";
                param5.Value = this.ID;

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(param1);
                cmd.Parameters.Add(param2);
                cmd.Parameters.Add(param3);
                cmd.Parameters.Add(param4);
                cmd.Parameters.Add(param5);
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
                 delete from tbRoomType
                 where RoomTypeID = @RoomTypeID";
                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@RoomTypeID";
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
