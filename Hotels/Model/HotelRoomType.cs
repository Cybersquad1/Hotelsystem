using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Model
{
    public class HotelRoomType:Base<HotelRoomType>
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
        private int _roomTypeID;
        public RoomType RoomType
        {
            get
            {
                if (_roomTypeID == -1)
                    return null;
                return RoomType.Items[_roomTypeID];
            }
            set
            {
                if (value == null)
                    _roomTypeID = -1;
                else
                    _roomTypeID = value.ID;
            }
        }
        public HotelRoomType() { }
        public HotelRoomType(Hotel ht,RoomType rt)
        {
            Hotel = ht; RoomType = rt;
        }
        //DB
        public override void Insert()
        {
            try
            {
                conn.Open();
                string query = @"insert into tbHotelRoomType
                            (_hotelID,_roomTypeID)
                            values (@_hotelID,@_roomTypeID)";
                // 2. define parameters used in command object
                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@_hotelID";
                param1.Value = this._hotelID;
                SqlParameter param2 = new SqlParameter();
                param2.ParameterName = "@_roomTypeID";
                param2.Value = this._roomTypeID;

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
                string query = @"select * from tbHotelRoomType";
                // 1. Instantiate a new command with a query and connection
                SqlCommand cmd = new SqlCommand(query, conn);

                // 2. Call Execute reader to get query results
                SqlDataReader rdr = cmd.ExecuteReader();
                Items.Clear();
                while (rdr.Read())
                {
                    HotelRoomType temp = new HotelRoomType();
                    temp.ID = Convert.ToInt32(rdr[0]);
                    temp._hotelID = Convert.ToInt32(rdr[1]);
                    temp._roomTypeID = Convert.ToInt32(rdr[2]);
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
                update tbHotelRoomType
                set _hotelID = @_hotelID,
                    _roomTypeID = @_roomTypeID
                where HotelRoomTypeID = @HotelRoomTypeID";

                // 1. Instantiate a new command with command text only

                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@_hotelID";
                param1.Value = this._hotelID;
                SqlParameter param2 = new SqlParameter();
                param2.ParameterName = "@_roomTypeID";
                param2.Value = this._roomTypeID;
                SqlParameter param3 = new SqlParameter();
                param3.ParameterName = "@HotelRoomTypeID";
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
                 delete from tbHotelRoomType
                 where HotelRoomTypeID = @HotelRoomTypeID";
                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@HotelRoomTypeID";
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
