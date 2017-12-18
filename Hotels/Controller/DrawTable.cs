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
    public class DrawTable
    {
        
        public static void DrawDataTable(Base<Person>[] array, DataGridView dgv /*TextBox[] arrayTextBox*/)
        {
            Type myType = array[0].GetType();
            IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());
            DataTable table = new DataTable();
            DataColumn column;
            DataRow row;
            // Add columns to the table
            foreach (PropertyInfo prop in props)
            {
                column = new DataColumn();
                column.DataType = prop.PropertyType;
                column.ColumnName = prop.Name;
                column.ReadOnly = true;
                table.Columns.Add(column);
            }
            //Add rows to the table
            for (int i = 0; i < array.Length; i++)
            {
                row = table.NewRow();
                foreach (PropertyInfo prop in props)
                {
                    row[prop.Name] = prop.GetValue(array[i],null);
                }
                table.Rows.Add(row);
            }
            dgv.DataSource = table;
            //for (int i = 0; i < arrayTextBox.Length; i++)
            //{
            //    arrayTextBox[i].DataBindings.Add("Text", table, "");
            //}

        }
        public static void DrawObjectInTable(Base<Person>[] array, DataGridView dgv)
        {
            dgv.Rows.Clear();
            dgv.Columns.Clear();
            try
            {
                // set the settings
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                // Add columns to the table
                foreach (var item in array[0].GetType().GetProperties())
                {
                    DataGridViewColumn temp = new DataGridViewTextBoxColumn();
                    temp.HeaderText = Convert.ToString(item.Name);
                    dgv.Columns.Add(temp);
                }
                //Add rows to the tabs that contain all objects in the input array
                for (int i = 0; i < array.Length; i++)
                {
                    AddRowsToTable(array[i], dgv);
                }
            }
            catch
            {

            }

        }
        public static void AddRowsToTable(Base<Person> obj, DataGridView dgv)
        {
            Dictionary<string, object> attributes = DictionaryFromType(obj);
            List<string> tmps = new List<string>();
            foreach (var item in attributes)
            {
                tmps.Add(Convert.ToString(item.Value));
            }
            dgv.Rows.Add(tmps.ToArray());
        }
        public static Dictionary<string, object> DictionaryFromType(object atype)
        {
            if (atype == null) return new Dictionary<string, object>();
            Type t = atype.GetType();
            PropertyInfo[] props = t.GetProperties();
            Dictionary<string, object> dict = new Dictionary<string, object>();
            foreach (PropertyInfo prp in props)
            {
                object value = prp.GetValue(atype, new object[] { });
                dict.Add(prp.Name, value);
            }
            return dict;
        }
    }
}
