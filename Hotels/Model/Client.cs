using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Model
{
    public enum ClientState { Booking,Living, Lived }
    public class Client:Person
    {
        public static Dictionary<int, Client> Clients = new Dictionary<int, Client>();
        public double Discount
        {
            get
            {
                return BookedRoom.Count*0.1;
            }
        }
        public int CountBookedRoom
        {
            get
            {
                return BookedRoom.Count;
            }
        }
        public ClientState State{get; set;}


        public List<Booking> Bookings
        {
            get
            {
                var res = new List<Booking>();
                foreach (var bk in Booking.Items.Values)
                    if (bk.Client == this)
                        res.Add(bk);
                return res;
            }

        }
        public List<Room> BookedRoom
        {
            get
            {
                var res = new List<Room>();
                foreach (var bk in Booking.Items.Values)
                    if (bk.Client == this)
                        res.Add(bk.Room);
                return res;
            }
        }

        public Room LivingRoom { get; set; }

        public void StateBook() { State = ClientState.Booking; }
        public void StateLiving() { State = ClientState.Living; }
        public void StateLived() { State = ClientState.Lived; }


        public override void Get()
        {
            try
            {
                conn.Open();
                string query = @"select PersonID,FirstName,LastName,Email,
                                        Birth,Telephone,Gender,Role,Login 
                                        from tbPerson where NOT Role = 'Worker'";
                // 1. Instantiate a new command with a query and connection
                SqlCommand cmd = new SqlCommand(query, conn);

                // 2. Call Execute reader to get query results
                SqlDataReader rdr = cmd.ExecuteReader();
                Clients.Clear();
                while (rdr.Read())
                {
                    Client temp = new Client();
                    temp.ID = Convert.ToInt32(rdr[0]);
                    temp.FirstName = rdr[1].ToString();
                    temp.LastName = rdr[2].ToString();
                    temp.Email = rdr[3].ToString();
                    try { temp.Birth = (DateTime)rdr[4]; } catch { }
                    temp.Telephone = rdr[5].ToString();
                    temp.Gender = rdr[6].ToString();
                    
                    switch (rdr[7].ToString())
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
                    temp.Login = rdr[8].ToString();

                    //словник об'єктів
                    Clients.Add(temp.ID, temp);
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

        
        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
    }
}
