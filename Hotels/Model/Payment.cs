using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Model
{
    public class Payment : Base<Payment>
    {
        //Property
        public DateTime Date { get; set; }
        public decimal Amount { get; private set; }

        private int _bookingID;
        public Booking Booking
        {
            get
            {
                try {
                    if (_bookingID == -1)
                        return null;
                    return Booking.Items[_bookingID];
                }
                catch { return null; }
            }
            set
            {
                if (value == null)
                    _bookingID = -1;
                else
                    _bookingID = value.ID;
            }
        }
        

        //DB
        public override void Delete()
        {
            try
            {
                // Open the connection
                conn.Open();

                // prepare command string
                string query = @"
                 delete from tbPayment
                 where PaymentID = @PaymentID";
                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@PaymentID";
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
                    conn.Close();
            }
        }
        public override void Insert()
        {
            try
            {
                conn.Open();
                string query = @"insert into tbPayment
                            (_bookingID,PaymentDate,Amount)
                            values (@_bookingID,@Date,@Amount)";
                // 2. define parameters used in command object
                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@_bookingID";
                param1.Value = this._bookingID;
                SqlParameter param2 = new SqlParameter();
                param2.ParameterName = "@Date";
                param2.Value = this.Date;
                SqlParameter param3 = new SqlParameter();
                param3.ParameterName = "@Amount";
                param3.Value = this.Amount;

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(param1);
                cmd.Parameters.Add(param2);
                cmd.Parameters.Add(param3);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                // Close the connection
                if (conn != null)
                    conn.Close();
            }
        }
        public override void Get()
        {
            try
            {
                conn.Open();
                string query = @"select * from tbPayment";
                // 1. Instantiate a new command with a query and connection
                SqlCommand cmd = new SqlCommand(query, conn);

                // 2. Call Execute reader to get query results
                SqlDataReader rdr = cmd.ExecuteReader();
                Items.Clear();
                while (rdr.Read())
                {
                    Payment temp = new Payment();
                    temp.ID = Convert.ToInt32(rdr[0]);
                    temp._bookingID = Convert.ToInt32(rdr[1]);
                    temp.Amount = Convert.ToInt32(rdr[2]);
                    try {temp.Date = (DateTime)rdr[3];} catch { }
                    //словник об'єктів
                    Items.Add(temp.ID, temp);
                }
                conn.Close();
            }

            finally
            {
                // Close the connection
                if (conn != null)
                    conn.Close();
            }
        }
        public override void Update()
        {
            try
            {
                conn.Open();
                // prepare command string
                string query = @"
                update tbPayment
                set _bookingID = @_bookingID,
                    Amount = @Amount,
                    PaymentDate = @Date
                where PaymentID = @PaymentID";

                // 1. Instantiate a new command with command text only

                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@_bookingID";
                param1.Value = this._bookingID;
                SqlParameter param2 = new SqlParameter();
                param2.ParameterName = "@Amount";
                param2.Value = this.Amount;
                SqlParameter param3 = new SqlParameter();
                param3.ParameterName = "@Date";
                param3.Value = this.Date;
                SqlParameter param4 = new SqlParameter();
                param4.ParameterName = "@PaymentID";
                param4.Value = this.ID;

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(param1);
                cmd.Parameters.Add(param2);
                cmd.Parameters.Add(param3);
                cmd.Parameters.Add(param4);
                // 3. Call ExecuteNonQuery to send command
                cmd.ExecuteNonQuery();
            }
            finally
            {
                // Close the connection
                if (conn != null)
                    conn.Close();
            }
        }

        //Pay
        public bool Pay(decimal amount)
        {
            decimal remainder = GetRemainder();

            if (amount > remainder || amount <= 0)
                return false;
            else
            {
                Amount = amount;
                return true;
            }

        }

        public decimal GetRemainder()
        {
            try
            {
                decimal remainder = GetAmount();
                if(this.Booking.Payments.Count !=0)
                    foreach (var item in Booking.Payments)
                        remainder -= item.Amount;
                return remainder;
            }
            catch { return GetAmount(); }
        }

        public decimal GetAmount()
        {
            return Booking.GetPrice();
        }
    }
}
