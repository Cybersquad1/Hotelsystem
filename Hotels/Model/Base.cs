using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
using System.Data.SqlClient;
using System.Configuration;

namespace Hotels.Model
{
    public abstract class Base<T>
        where T : Base<T>
    {
        public static Dictionary<int, T> Items = new Dictionary<int, T>();
        public int ID { get; set; }
        public abstract void Insert();
        public abstract void Get();
        public abstract void Update();
        public abstract void Delete();
        public override string ToString()
        {
            return "";
        }
        protected static SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Hotels.Properties.Settings.dbHotelsConnectionString"].ConnectionString);
    }
}
