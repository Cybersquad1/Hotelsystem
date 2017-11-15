using Hotels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotels.Controller
{
    public class ControllerMain
    {
        Dictionary<string, ToolStripMenuItem> MenuItems = new Dictionary<string, ToolStripMenuItem>();

        public ControllerMain(Dictionary<string, ToolStripMenuItem> menuItems)
        {
            foreach (var item in menuItems)
            {
                MenuItems.Add(item.Key, item.Value);
            }
        }

        public void AccessLevel(Person currentUser)
        {
            switch (currentUser.UserRole)
            {
                case Role.Administrator:
                    MenuItems["Dictionary"].Visible = false;
                    MenuItems["Setting"].Visible = true;
                    MenuItems["Statistic"].Visible = true;
                    MenuItems["CheckIn"].Visible = true;
                    MenuItems["Payment"].Visible = true;
                    MenuItems["BookingAll"].Visible = true;
                    break;
                case Role.Concierge:
                    MenuItems["Dictionary"].Visible = false;
                    MenuItems["Setting"].Visible = false;
                    MenuItems["Statistic"].Visible = true;
                    MenuItems["CheckIn"].Visible = true;
                    MenuItems["Payment"].Visible = true;
                    MenuItems["BookingAll"].Visible = true;
                    break;
                case Role.Client:
                    MenuItems["Dictionary"].Visible = false;
                    MenuItems["Setting"].Visible = false;
                    MenuItems["Statistic"].Visible = false;
                    MenuItems["CheckIn"].Visible = false;
                    MenuItems["Payment"].Visible = false;
                    MenuItems["BookingAll"].Visible = false;
                    break;
                case Role.Worker:
                    MenuItems["Dictionary"].Visible = false;
                    MenuItems["Setting"].Visible = false;
                    MenuItems["Statistic"].Visible = false;
                    MenuItems["CheckIn"].Visible = false;
                    MenuItems["Payment"].Visible = false;
                    MenuItems["BookingAll"].Visible = false;
                    break;
            }
            
        }
    }
}
