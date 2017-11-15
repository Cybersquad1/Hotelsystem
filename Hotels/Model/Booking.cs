using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Model
{
    public enum Status { Booking, CheckIn, CheckOut }
    public class Booking:Base<Booking>
    {
        //Property
        private Status status { get; set; }
        private int _roomID { get; set; }
        private int _clientID { get; set; }       
        public Client Client
        {
            get
            {
                try
                {
                    if (_clientID == -1)
                        return null;
                    return Client.Clients[_clientID];
                }
                catch { return null; }
                
            }
            set
            {
                if (value == null)
                    _clientID = -1;
                else
                    _clientID = value.ID;
            }
        }
        public Room Room
        {
            get
            {
                if (_roomID == -1)
                    return null;
                return Room.Items[_roomID];
            }
            set
            {
                if (value == null)
                    _roomID = -1;
                else
                    _roomID = value.ID;
            }
        }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        //List of payment
        public List<Payment> Payments
        {
            get
            {
                var res = new List<Payment>();
                foreach (var ht in Payment.Items.Values)
                    if (ht.Booking == this)
                        res.Add(ht);
                return res;
            }
        }

        //Constructor
        public Booking() { Book(); }
        public Booking(Room r,Client cl){Room = r; Client = cl; Book(); }

        //DB
        public override void Insert()
        {
            try
            {
                conn.Open();
                string query = @"insert into tbBooking
                            (_roomID,_clientID,StartDate,EndDate,Status)
                            values (@_roomID,@_clientID,@StartDate,@EndDate,@Status)";
                // 2. define parameters used in command object
                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@_roomID";
                param1.Value = this._roomID;
                SqlParameter param2 = new SqlParameter();
                param2.ParameterName = "@_clientID";
                param2.Value = this._clientID;
                SqlParameter param3 = new SqlParameter();
                param3.ParameterName = "@StartDate";
                param3.Value = this.StartDate;
                SqlParameter param4 = new SqlParameter();
                param4.ParameterName = "@EndDate";
                param4.Value = this.EndDate;
                SqlParameter param5 = new SqlParameter();
                param5.ParameterName = "@Status";
                param5.Value = this.status.ToString();

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
        public void SelectUserBooking(int id)
        {
            try
            {
                conn.Open();
                string query = @"select * from tbBooking where _clientID = @_clientID";
                // 1. Instantiate a new command with a query and connection
                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@_clientID";
                param1.Value = id;
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(param1);

                // 2. Call Execute reader to get query results
                SqlDataReader rdr = cmd.ExecuteReader();
                Items.Clear();
                while (rdr.Read())
                {
                    Booking temp = new Booking();
                    temp.ID = Convert.ToInt32(rdr[0]);
                    temp._roomID = Convert.ToInt32(rdr[1]);
                    temp._clientID = Convert.ToInt32(rdr[2]);
                    try
                    {
                        temp.StartDate = (DateTime)(rdr[3]);
                        temp.EndDate = Convert.ToDateTime(rdr[4]);
                    }
                    catch { }
                    switch (rdr[5].ToString())
                    {
                        case "Booking":
                            temp.Book();
                            break;
                        case "CheckIn":
                            temp.CheckIn();
                            break;
                        case "CheckOut":
                            temp.CheckOut();
                            break;
                        default:
                            temp.Book();
                            break;
                    }

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
        public override void Get()
        {
            try
            {
                conn.Open();
                string query = @"select * from tbBooking";
                // 1. Instantiate a new command with a query and connection
                SqlCommand cmd = new SqlCommand(query, conn);

                // 2. Call Execute reader to get query results
                SqlDataReader rdr = cmd.ExecuteReader();
                Items.Clear();
                while (rdr.Read())
                {
                    Booking temp = new Booking();
                    temp.ID = Convert.ToInt32(rdr[0]);
                    temp._roomID = Convert.ToInt32(rdr[1]);
                    temp._clientID = Convert.ToInt32(rdr[2]);
                    try
                    {
                        temp.StartDate = (DateTime)rdr[3];
                        temp.EndDate = Convert.ToDateTime(rdr[4]);
                    } catch{ }
                    switch (rdr[5].ToString())
                    {
                        case "Booking":
                            temp.Book();
                            break;
                        case "CheckIn":
                            temp.CheckIn();
                            break;
                        case "CheckOut":
                            temp.CheckOut();
                            break;
                        default:
                            temp.Book();
                            break;
                    }
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
                update tbBooking
                set _roomID = @_roomID,
                    _clientID = @_clientID,
                    StartDate = @StartDate,
                    EndDate  = @EndDate
                where BookingID = @BookingID";

                // 1. Instantiate a new command with command text only

                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@_roomID";
                param1.Value = this._roomID;
                SqlParameter param2 = new SqlParameter();
                param2.ParameterName = "@_clientID";
                param2.Value = this._clientID;
                SqlParameter param3 = new SqlParameter();
                param3.ParameterName = "@StartDate";
                param3.Value = this.StartDate;
                SqlParameter param4 = new SqlParameter();
                param4.ParameterName = "@EndDate";
                param4.Value = this.EndDate;
                SqlParameter param6 = new SqlParameter();
                param6.ParameterName = "@BookingID";
                param6.Value = this.ID;

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(param1);
                cmd.Parameters.Add(param2);
                cmd.Parameters.Add(param3);
                cmd.Parameters.Add(param4);
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
        public void UpdateStatus()
        {
            try
            {
                conn.Open();
                // prepare command string
                string query = @"
                update tbBooking
                set  Status = @Status
                where BookingID = @BookingID";

                // 1. Instantiate a new command with command text only

                
                SqlParameter param5 = new SqlParameter();
                param5.ParameterName = "@Status";
                param5.Value = this.status.ToString();
                SqlParameter param6 = new SqlParameter();
                param6.ParameterName = "@BookingID";
                param6.Value = this.ID;

                SqlCommand cmd = new SqlCommand(query, conn);
                
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
                 delete from tbBooking
                 where BookingID = @BookingID";
                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@BookingID";
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

        //State
        public void Book() { status = Status.Booking; }
        public void CheckIn() { status = Status.CheckIn; try { Client.LivingRoom = Room; } catch { } }
        public void CheckOut() { status = Status.CheckOut; try { Client.LivingRoom = null; } catch { } }

        //Price of booking
        public decimal GetPrice()
        {
            try
            {
                decimal priceOneNight = Room.RoomType.Price;
                int countOfNight = Math.Abs(EndDate.Date.DayOfYear - StartDate.Date.DayOfYear);
                decimal total = countOfNight * priceOneNight;
                return total;
            }
            catch { return 0; }
        }
        //Status of booking
        public string GetStatus()
        {
            return status.ToString();
        }
    }
}
