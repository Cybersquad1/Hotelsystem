using Hotels.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotels.Controller
{
    public class ControllerClient : ControllerPerson
    {
        public ControllerClient(DataGridView dgv, BindingNavigator bn):base(dgv,bn){ }

        public override void LoadDB()
        {
            new Client().Get();
            new Person().Get();
            new Booking().Get();
            new Room().Get();
            new Hotel().Get();

            List<Client> list = new List<Client>();
            foreach (var client in Client.Clients.Values.ToList())
            {
                if(client.LivingRoom!=null)
                    list.Add(client);
                
                
            }
            FillRows(list.ToArray());
        }
        public override void FillColumns()
        {
            Type myType = typeof(Client);
            IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());
            DataColumn column;
            foreach (PropertyInfo prop in props)
            {
                column = new DataColumn();
                column.DataType = prop.PropertyType;
                column.ColumnName = prop.Name;
                column.ReadOnly = true;
                dataTable.Columns.Add(column);
            }
            column = new DataColumn();
            column.DataType = typeof(Hotel);
            column.ColumnName = "Hotel";
            column.ReadOnly = true;
            dataTable.Columns.Add(column);


            dataGridView.Columns["Password"].Visible = false;
            dataGridView.Columns["UserRole"].Visible = false;
            dataGridView.Columns["Male"].Visible = false;
            dataGridView.Columns["Female"].Visible = false;
            dataGridView.Columns["ID"].Visible = false;
            dataTable.Columns["Male"].DefaultValue = true;
            dataTable.Columns["Female"].DefaultValue = false;

        }
        public override void AddRow(Person currentrow)
        {
            Type myType = typeof(Client);
            IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());
            DataRow row = dataTable.NewRow();
            foreach (PropertyInfo prop in props)
            {
                row[prop.Name] = prop.GetValue(currentrow, null);
            }
            //row["Hotel"] = ((Client)currentrow).BookedRoom.
            dataTable.Rows.Add(row);
        }
    }
}
