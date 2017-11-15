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
    public class ControllerHotelRoomType : Controller<HotelRoomType>
    {
        ComboBox cbHotel;
        ComboBox cbRoomType;
        HotelRoomType currentHotelRoomType;
        public ControllerHotelRoomType(DataGridView dgv, BindingNavigator bn, Dictionary<string, TextBox> textBoxs,ComboBox cbHotel,ComboBox cbRoomType) : base(dgv, bn, textBoxs)
        {
            this.cbHotel = cbHotel; this.cbRoomType = cbRoomType;
            currentHotelRoomType = new HotelRoomType();
            //this.cbHotel.DataBindings.Add("Text", bindingSource, "Hotel");
            //this.cbRoomType.DataBindings.Add("Text", bindingSource, "RoomType");
        }
        public override void Delete()
        {
            currentHotelRoomType.Hotel = (Hotel)cbHotel.SelectedItem;
            currentHotelRoomType.ID = (int)((DataRowView)bindingSource.Current).Row["ID"];
            currentHotelRoomType.Delete();
        }

        public override void LoadDB()
        {
            new RoomType().Get();
            new Hotel().Get();
            new HotelRoomType().Get();
            cbHotel.DataSource = Hotel.Items.Values.ToList();
            cbRoomType.DataSource = RoomType.Items.Values.ToList();
            try { cbHotel.SelectedItem = currentHotelRoomType.Hotel; } catch { }
            ChangeHotel();
        }
        

        public override void Save()
        {
            currentHotelRoomType.Hotel = (Hotel)cbHotel.SelectedItem;
            currentHotelRoomType.RoomType = (RoomType)cbRoomType.SelectedItem;
            //room.RoomType;

            if (((DataRowView)bindingSource.Current).IsNew == true)
                currentHotelRoomType.Insert();
            else
            {
                currentHotelRoomType.ID = (int)((DataRowView)bindingSource.Current).Row["ID"];
                currentHotelRoomType.Update();
            }
        }
        public void Add()
        {
            ((DataRowView)bindingSource.Current).Row["Hotel"] = (Hotel)cbHotel.SelectedItem;
            cbRoomType.SelectedItem = null;
        }

        public void ChangeHotel()
        {
            try {
                FillRows(((Hotel)(cbHotel.SelectedItem)).HotelRoomTypes.ToArray()); }
            catch { }
        }
    }
}
