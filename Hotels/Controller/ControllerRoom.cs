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
    public class ControllerRoom : Controller<Room>
    {
        ComboBox cbHotel;
        ComboBox cbRoomType;
        Room currentRoom;
        public ControllerRoom(DataGridView dgv, BindingNavigator bn, Dictionary<string, TextBox> textBoxs,ComboBox hotel,ComboBox roomtype):base(dgv,bn,textBoxs)
        {
            cbHotel = hotel; cbRoomType = roomtype;
            currentRoom = new Room();
            //cbHotel.DataBindings.Add("Text", bindingSource, "Hotel");
            //cbRoomType.DataBindings.Add("Text", bindingSource, "RoomType");
        }

        public override void Delete()
        {
            currentRoom.Hotel = (Hotel)((DataRowView)bindingSource.Current).Row["Hotel"];
            currentRoom.ID = (int)((DataRowView)bindingSource.Current).Row["ID"];
            currentRoom.Delete();
        }
        public void Add()
        {
            ((DataRowView)bindingSource.Current).Row["Hotel"] = (Hotel)cbHotel.SelectedItem;
            ((DataRowView)bindingSource.Current).Row["RoomType"] = (RoomType)cbRoomType.SelectedItem;
        }

        public override void LoadDB()
        {
            new Room().Get();
            new RoomType().Get();
            new Hotel().Get();
            new HotelRoomType().Get();
            cbHotel.DataSource = Hotel.Items.Values.ToList();
            cbRoomType.DataSource = ((Hotel)(cbHotel.SelectedItem)).RoomTypes;
            try { cbHotel.SelectedItem = currentRoom.Hotel; } catch { }
        }
        public void ChangeHotel()
        {
            cbRoomType.DataSource = ((Hotel)(cbHotel.SelectedItem)).RoomTypes;
        }
        public void ChangeRoomType()
        {
            List<Room> rooms = new List<Room>();
            foreach (var item in ((Hotel)(cbHotel.SelectedItem)).Rooms.ToList())
                if (item.RoomType == (RoomType)(cbRoomType.SelectedItem))
                    rooms.Add(item);
            FillRows(rooms.ToArray());

        }
        public override void Save()
        {
            currentRoom.Name = TextBoxs["Name"].Text;
            currentRoom.RoomType = (RoomType)cbRoomType.SelectedItem;
            currentRoom.Hotel = (Hotel)cbHotel.SelectedItem;

            if (((DataRowView)bindingSource.Current).IsNew == true)
                currentRoom.Insert();
            else
            {
                currentRoom.ID = (int)((DataRowView)bindingSource.Current).Row["ID"];
                currentRoom.Update();
            }
        }
    }
}
