using Hotels.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotels.Controller
{
    public class ControllerRoomType:Controller<RoomType>
    {
        RichTextBox Description;
        public ControllerRoomType(DataGridView dgv, BindingNavigator bn, Dictionary<string, TextBox> textBoxs, RichTextBox rtb):base(dgv,bn,textBoxs)
        {
            Description = rtb;
            Description.DataBindings.Add("Text", bindingSource, "Description");
        }

        public override void Save()
        {
            RoomType roomType = new RoomType();
            roomType.Name = TextBoxs["Name"].Text;
            roomType.Description = Description.Text;
            roomType.Price = Convert.ToDecimal(TextBoxs["Price"].Text);
            roomType.MaxPerson = Convert.ToInt16(TextBoxs["MaxPerson"].Text);

            if (((DataRowView)bindingSource.Current).IsNew == true)
                roomType.Insert();
            else
            {
                roomType.ID = (int)((DataRowView)bindingSource.Current).Row["ID"];
                roomType.Update();
            }
        }

        public override void Delete()
        {
            RoomType roomType = new RoomType();
            roomType.ID = (int)((DataRowView)bindingSource.Current).Row["ID"];
            roomType.Delete();
        }
        public override void LoadDB()
        {
            new RoomType().Get();
            FillRows(RoomType.Items.Values.ToArray());
        }

        public override void FillColumns()
        {
            base.FillColumns();
            dataGridView.Columns["Description"].Visible = false;
        }
    }
}
