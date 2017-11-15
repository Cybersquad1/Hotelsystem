namespace Hotels
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.itemDictionary = new System.Windows.Forms.ToolStripMenuItem();
            this.itemPerson = new System.Windows.Forms.ToolStripMenuItem();
            this.itemHotels = new System.Windows.Forms.ToolStripMenuItem();
            this.itemRoomType = new System.Windows.Forms.ToolStripMenuItem();
            this.itemRoom = new System.Windows.Forms.ToolStripMenuItem();
            this.itemDictionaryBooking = new System.Windows.Forms.ToolStripMenuItem();
            this.itemEmployee = new System.Windows.Forms.ToolStripMenuItem();
            this.itemHotelRoomType = new System.Windows.Forms.ToolStripMenuItem();
            this.itemDictionaryHotelEmployee = new System.Windows.Forms.ToolStripMenuItem();
            this.kitchenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.foodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.barToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orderToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.drinksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemBooking = new System.Windows.Forms.ToolStripMenuItem();
            this.itemMakeBooking = new System.Windows.Forms.ToolStripMenuItem();
            this.itemMyBooking = new System.Windows.Forms.ToolStripMenuItem();
            this.itemBookingAll = new System.Windows.Forms.ToolStripMenuItem();
            this.itemCheckIn = new System.Windows.Forms.ToolStripMenuItem();
            this.itemPayment = new System.Windows.Forms.ToolStripMenuItem();
            this.itemStatistic = new System.Windows.Forms.ToolStripMenuItem();
            this.itemStatisticEmployee = new System.Windows.Forms.ToolStripMenuItem();
            this.itemStatisticHotel = new System.Windows.Forms.ToolStripMenuItem();
            this.itemProfile = new System.Windows.Forms.ToolStripMenuItem();
            this.itemSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.itemSettingHotels = new System.Windows.Forms.ToolStripMenuItem();
            this.itemSettingHotelList = new System.Windows.Forms.ToolStripMenuItem();
            this.itemSettingHotelRoom = new System.Windows.Forms.ToolStripMenuItem();
            this.itemSettingHotelEmployee = new System.Windows.Forms.ToolStripMenuItem();
            this.itemSettingTypeRooms = new System.Windows.Forms.ToolStripMenuItem();
            this.itemSettingRooms = new System.Windows.Forms.ToolStripMenuItem();
            this.itemSettingPerson = new System.Windows.Forms.ToolStripMenuItem();
            this.itemSettingPersonAll = new System.Windows.Forms.ToolStripMenuItem();
            this.itemSettingPersonEmployee = new System.Windows.Forms.ToolStripMenuItem();
            this.itemSettingClient = new System.Windows.Forms.ToolStripMenuItem();
            this.itemAboutProgram = new System.Windows.Forms.ToolStripMenuItem();
            this.itemClose = new System.Windows.Forms.ToolStripMenuItem();
            this.itemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.itemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemDictionary,
            this.itemBooking,
            this.itemCheckIn,
            this.itemPayment,
            this.itemStatistic,
            this.itemProfile,
            this.itemSetting,
            this.itemAboutProgram,
            this.itemClose});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Padding = new System.Windows.Forms.Padding(7, 5, 0, 5);
            this.mainMenu.Size = new System.Drawing.Size(1231, 35);
            this.mainMenu.TabIndex = 4;
            this.mainMenu.Text = "menuStrip1";
            // 
            // itemDictionary
            // 
            this.itemDictionary.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemPerson,
            this.itemHotels,
            this.itemRoomType,
            this.itemRoom,
            this.itemDictionaryBooking,
            this.itemEmployee,
            this.itemHotelRoomType,
            this.itemDictionaryHotelEmployee,
            this.kitchenToolStripMenuItem,
            this.barToolStripMenuItem});
            this.itemDictionary.Image = ((System.Drawing.Image)(resources.GetObject("itemDictionary.Image")));
            this.itemDictionary.Name = "itemDictionary";
            this.itemDictionary.Size = new System.Drawing.Size(108, 25);
            this.itemDictionary.Text = "Directory";
            // 
            // itemPerson
            // 
            this.itemPerson.Name = "itemPerson";
            this.itemPerson.Size = new System.Drawing.Size(200, 26);
            this.itemPerson.Text = "Users";
            this.itemPerson.Click += new System.EventHandler(this.itemPerson_Click);
            // 
            // itemHotels
            // 
            this.itemHotels.Name = "itemHotels";
            this.itemHotels.Size = new System.Drawing.Size(200, 26);
            this.itemHotels.Text = "Hotels";
            this.itemHotels.Click += new System.EventHandler(this.itemHotels_Click);
            // 
            // itemRoomType
            // 
            this.itemRoomType.Name = "itemRoomType";
            this.itemRoomType.Size = new System.Drawing.Size(200, 26);
            this.itemRoomType.Text = "Types of rooms";
            this.itemRoomType.Click += new System.EventHandler(this.itemRoomType_Click);
            // 
            // itemRoom
            // 
            this.itemRoom.Name = "itemRoom";
            this.itemRoom.Size = new System.Drawing.Size(200, 26);
            this.itemRoom.Text = "Rooms";
            this.itemRoom.Click += new System.EventHandler(this.itemRoom_Click);
            // 
            // itemDictionaryBooking
            // 
            this.itemDictionaryBooking.Name = "itemDictionaryBooking";
            this.itemDictionaryBooking.Size = new System.Drawing.Size(200, 26);
            this.itemDictionaryBooking.Text = "Reservation";
            this.itemDictionaryBooking.Click += new System.EventHandler(this.itemBooking_Click);
            // 
            // itemEmployee
            // 
            this.itemEmployee.Name = "itemEmployee";
            this.itemEmployee.Size = new System.Drawing.Size(200, 26);
            this.itemEmployee.Text = "Workers";
            this.itemEmployee.Click += new System.EventHandler(this.itemEmployee_Click);
            // 
            // itemHotelRoomType
            // 
            this.itemHotelRoomType.Name = "itemHotelRoomType";
            this.itemHotelRoomType.Size = new System.Drawing.Size(200, 26);
            this.itemHotelRoomType.Text = "Hotel Rooms";
            this.itemHotelRoomType.Click += new System.EventHandler(this.itemHotelRoomType_Click);
            // 
            // itemDictionaryHotelEmployee
            // 
            this.itemDictionaryHotelEmployee.Name = "itemDictionaryHotelEmployee";
            this.itemDictionaryHotelEmployee.Size = new System.Drawing.Size(200, 26);
            this.itemDictionaryHotelEmployee.Text = "Hotel Staff";
            this.itemDictionaryHotelEmployee.Click += new System.EventHandler(this.itemDictionaryHotelEmployee_Click);
            // 
            // kitchenToolStripMenuItem
            // 
            this.kitchenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.orderToolStripMenuItem,
            this.foodToolStripMenuItem});
            this.kitchenToolStripMenuItem.Name = "kitchenToolStripMenuItem";
            this.kitchenToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
            this.kitchenToolStripMenuItem.Text = "Kitchen";
            // 
            // orderToolStripMenuItem
            // 
            this.orderToolStripMenuItem.Name = "orderToolStripMenuItem";
            this.orderToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.orderToolStripMenuItem.Text = "Order";
            // 
            // foodToolStripMenuItem
            // 
            this.foodToolStripMenuItem.Name = "foodToolStripMenuItem";
            this.foodToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.foodToolStripMenuItem.Text = "Food";
            // 
            // barToolStripMenuItem
            // 
            this.barToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.orderToolStripMenuItem1,
            this.drinksToolStripMenuItem});
            this.barToolStripMenuItem.Name = "barToolStripMenuItem";
            this.barToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
            this.barToolStripMenuItem.Text = "Bar";
            // 
            // orderToolStripMenuItem1
            // 
            this.orderToolStripMenuItem1.Name = "orderToolStripMenuItem1";
            this.orderToolStripMenuItem1.Size = new System.Drawing.Size(129, 26);
            this.orderToolStripMenuItem1.Text = "Order";
            // 
            // drinksToolStripMenuItem
            // 
            this.drinksToolStripMenuItem.Name = "drinksToolStripMenuItem";
            this.drinksToolStripMenuItem.Size = new System.Drawing.Size(129, 26);
            this.drinksToolStripMenuItem.Text = "Drinks";
            // 
            // itemBooking
            // 
            this.itemBooking.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemMakeBooking,
            this.itemMyBooking,
            this.itemBookingAll});
            this.itemBooking.Image = ((System.Drawing.Image)(resources.GetObject("itemBooking.Image")));
            this.itemBooking.Name = "itemBooking";
            this.itemBooking.Size = new System.Drawing.Size(126, 25);
            this.itemBooking.Text = "Reservation";
            // 
            // itemMakeBooking
            // 
            this.itemMakeBooking.Name = "itemMakeBooking";
            this.itemMakeBooking.Size = new System.Drawing.Size(195, 26);
            this.itemMakeBooking.Text = "Reserve";
            this.itemMakeBooking.Click += new System.EventHandler(this.itemMakeBooking_Click);
            // 
            // itemMyBooking
            // 
            this.itemMyBooking.Name = "itemMyBooking";
            this.itemMyBooking.Size = new System.Drawing.Size(195, 26);
            this.itemMyBooking.Text = "My booking";
            this.itemMyBooking.Click += new System.EventHandler(this.itemMyBooking_Click);
            // 
            // itemBookingAll
            // 
            this.itemBookingAll.Name = "itemBookingAll";
            this.itemBookingAll.Size = new System.Drawing.Size(195, 26);
            this.itemBookingAll.Text = "All reservations";
            this.itemBookingAll.Click += new System.EventHandler(this.itemBookingAll_Click);
            // 
            // itemCheckIn
            // 
            this.itemCheckIn.Image = ((System.Drawing.Image)(resources.GetObject("itemCheckIn.Image")));
            this.itemCheckIn.Name = "itemCheckIn";
            this.itemCheckIn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.itemCheckIn.Size = new System.Drawing.Size(198, 25);
            this.itemCheckIn.Text = "Check-in / Check-out";
            this.itemCheckIn.Click += new System.EventHandler(this.itemCheckIn_Click);
            // 
            // itemPayment
            // 
            this.itemPayment.Image = ((System.Drawing.Image)(resources.GetObject("itemPayment.Image")));
            this.itemPayment.Name = "itemPayment";
            this.itemPayment.Size = new System.Drawing.Size(102, 25);
            this.itemPayment.Text = "Payment";
            this.itemPayment.Click += new System.EventHandler(this.itemPayment_Click);
            // 
            // itemStatistic
            // 
            this.itemStatistic.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemStatisticEmployee,
            this.itemStatisticHotel});
            this.itemStatistic.Image = ((System.Drawing.Image)(resources.GetObject("itemStatistic.Image")));
            this.itemStatistic.Name = "itemStatistic";
            this.itemStatistic.Size = new System.Drawing.Size(105, 25);
            this.itemStatistic.Text = "Statistics";
            // 
            // itemStatisticEmployee
            // 
            this.itemStatisticEmployee.Name = "itemStatisticEmployee";
            this.itemStatisticEmployee.Size = new System.Drawing.Size(162, 26);
            this.itemStatisticEmployee.Text = "Employees";
            this.itemStatisticEmployee.Click += new System.EventHandler(this.itemStatisticEmployee_Click);
            // 
            // itemStatisticHotel
            // 
            this.itemStatisticHotel.Name = "itemStatisticHotel";
            this.itemStatisticHotel.Size = new System.Drawing.Size(162, 26);
            this.itemStatisticHotel.Text = "Hotels";
            this.itemStatisticHotel.Click += new System.EventHandler(this.itemStatisticHotel_Click);
            // 
            // itemProfile
            // 
            this.itemProfile.Image = ((System.Drawing.Image)(resources.GetObject("itemProfile.Image")));
            this.itemProfile.Name = "itemProfile";
            this.itemProfile.Size = new System.Drawing.Size(87, 25);
            this.itemProfile.Text = "Profile";
            this.itemProfile.Click += new System.EventHandler(this.itemProfile_Click);
            // 
            // itemSetting
            // 
            this.itemSetting.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemSettingHotels,
            this.itemSettingTypeRooms,
            this.itemSettingRooms,
            this.itemSettingPerson});
            this.itemSetting.Image = ((System.Drawing.Image)(resources.GetObject("itemSetting.Image")));
            this.itemSetting.Name = "itemSetting";
            this.itemSetting.Size = new System.Drawing.Size(97, 25);
            this.itemSetting.Text = "Settings";
            // 
            // itemSettingHotels
            // 
            this.itemSettingHotels.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemSettingHotelList,
            this.itemSettingHotelRoom,
            this.itemSettingHotelEmployee});
            this.itemSettingHotels.Name = "itemSettingHotels";
            this.itemSettingHotels.Size = new System.Drawing.Size(200, 26);
            this.itemSettingHotels.Text = "Hotels";
            this.itemSettingHotels.Click += new System.EventHandler(this.itemSettingHotels_Click);
            // 
            // itemSettingHotelList
            // 
            this.itemSettingHotelList.Name = "itemSettingHotelList";
            this.itemSettingHotelList.Size = new System.Drawing.Size(241, 26);
            this.itemSettingHotelList.Text = "List of hotels";
            this.itemSettingHotelList.Click += new System.EventHandler(this.itemSettingHotelList_Click);
            // 
            // itemSettingHotelRoom
            // 
            this.itemSettingHotelRoom.Name = "itemSettingHotelRoom";
            this.itemSettingHotelRoom.Size = new System.Drawing.Size(241, 26);
            this.itemSettingHotelRoom.Text = "Types of hotel rooms";
            this.itemSettingHotelRoom.Click += new System.EventHandler(this.itemSettingHotelRoom_Click);
            // 
            // itemSettingHotelEmployee
            // 
            this.itemSettingHotelEmployee.Name = "itemSettingHotelEmployee";
            this.itemSettingHotelEmployee.Size = new System.Drawing.Size(241, 26);
            this.itemSettingHotelEmployee.Text = "Hotel staff";
            this.itemSettingHotelEmployee.Click += new System.EventHandler(this.itemSettingHotelEmployee_Click);
            // 
            // itemSettingTypeRooms
            // 
            this.itemSettingTypeRooms.Name = "itemSettingTypeRooms";
            this.itemSettingTypeRooms.Size = new System.Drawing.Size(200, 26);
            this.itemSettingTypeRooms.Text = "Types of rooms";
            this.itemSettingTypeRooms.Click += new System.EventHandler(this.itemSettingTypeRooms_Click);
            // 
            // itemSettingRooms
            // 
            this.itemSettingRooms.Name = "itemSettingRooms";
            this.itemSettingRooms.Size = new System.Drawing.Size(200, 26);
            this.itemSettingRooms.Text = "Rooms";
            this.itemSettingRooms.Click += new System.EventHandler(this.itemSettingRooms_Click);
            // 
            // itemSettingPerson
            // 
            this.itemSettingPerson.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemSettingPersonAll,
            this.itemSettingPersonEmployee,
            this.itemSettingClient});
            this.itemSettingPerson.Name = "itemSettingPerson";
            this.itemSettingPerson.Size = new System.Drawing.Size(200, 26);
            this.itemSettingPerson.Text = "Users";
            this.itemSettingPerson.Click += new System.EventHandler(this.itemSettingPerson_Click);
            // 
            // itemSettingPersonAll
            // 
            this.itemSettingPersonAll.Name = "itemSettingPersonAll";
            this.itemSettingPersonAll.Size = new System.Drawing.Size(161, 26);
            this.itemSettingPersonAll.Text = "All";
            this.itemSettingPersonAll.Click += new System.EventHandler(this.itemSettingPersonAll_Click);
            // 
            // itemSettingPersonEmployee
            // 
            this.itemSettingPersonEmployee.Name = "itemSettingPersonEmployee";
            this.itemSettingPersonEmployee.Size = new System.Drawing.Size(161, 26);
            this.itemSettingPersonEmployee.Text = "Workers";
            this.itemSettingPersonEmployee.Click += new System.EventHandler(this.itemSettingPersonEmployee_Click);
            // 
            // itemSettingClient
            // 
            this.itemSettingClient.Name = "itemSettingClient";
            this.itemSettingClient.Size = new System.Drawing.Size(161, 26);
            this.itemSettingClient.Text = "Customers";
            this.itemSettingClient.Click += new System.EventHandler(this.itemSettingClient_Click);
            // 
            // itemAboutProgram
            // 
            this.itemAboutProgram.Image = ((System.Drawing.Image)(resources.GetObject("itemAboutProgram.Image")));
            this.itemAboutProgram.Name = "itemAboutProgram";
            this.itemAboutProgram.Size = new System.Drawing.Size(180, 25);
            this.itemAboutProgram.Text = "About the program";
            this.itemAboutProgram.Click += new System.EventHandler(this.itemAboutProgram_Click);
            // 
            // itemClose
            // 
            this.itemClose.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemRefresh,
            this.itemExit});
            this.itemClose.Image = ((System.Drawing.Image)(resources.GetObject("itemClose.Image")));
            this.itemClose.Name = "itemClose";
            this.itemClose.Size = new System.Drawing.Size(67, 25);
            this.itemClose.Text = "Exit";
            // 
            // itemRefresh
            // 
            this.itemRefresh.Name = "itemRefresh";
            this.itemRefresh.Size = new System.Drawing.Size(147, 26);
            this.itemRefresh.Text = "Go Back";
            this.itemRefresh.Click += new System.EventHandler(this.itemRefresh_Click);
            // 
            // itemExit
            // 
            this.itemExit.Name = "itemExit";
            this.itemExit.Size = new System.Drawing.Size(147, 26);
            this.itemExit.Text = "Exit";
            this.itemExit.Click += new System.EventHandler(this.itemExit_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1231, 483);
            this.Controls.Add(this.mainMenu);
            this.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mainMenu;
            this.Name = "FormMain";
            this.Text = "ACU \"Hotel chain\"";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem itemDictionary;
        private System.Windows.Forms.ToolStripMenuItem itemPerson;
        private System.Windows.Forms.ToolStripMenuItem itemHotels;
        private System.Windows.Forms.ToolStripMenuItem itemRoomType;
        private System.Windows.Forms.ToolStripMenuItem itemRoom;
        private System.Windows.Forms.ToolStripMenuItem itemDictionaryBooking;
        private System.Windows.Forms.ToolStripMenuItem itemEmployee;
        private System.Windows.Forms.ToolStripMenuItem itemHotelRoomType;
        private System.Windows.Forms.ToolStripMenuItem itemBooking;
        private System.Windows.Forms.ToolStripMenuItem itemStatistic;
        private System.Windows.Forms.ToolStripMenuItem itemSetting;
        private System.Windows.Forms.ToolStripMenuItem itemAboutProgram;
        private System.Windows.Forms.ToolStripMenuItem itemClose;
        private System.Windows.Forms.ToolStripMenuItem itemSettingHotels;
        private System.Windows.Forms.ToolStripMenuItem itemSettingTypeRooms;
        private System.Windows.Forms.ToolStripMenuItem itemSettingRooms;
        private System.Windows.Forms.ToolStripMenuItem itemRefresh;
        private System.Windows.Forms.ToolStripMenuItem itemExit;
        private System.Windows.Forms.ToolStripMenuItem itemMakeBooking;
        private System.Windows.Forms.ToolStripMenuItem itemMyBooking;
        private System.Windows.Forms.ToolStripMenuItem itemStatisticEmployee;
        private System.Windows.Forms.ToolStripMenuItem itemSettingPerson;
        private System.Windows.Forms.ToolStripMenuItem itemCheckIn;
        private System.Windows.Forms.ToolStripMenuItem itemPayment;
        private System.Windows.Forms.ToolStripMenuItem itemDictionaryHotelEmployee;
        private System.Windows.Forms.ToolStripMenuItem itemStatisticHotel;
        private System.Windows.Forms.ToolStripMenuItem itemSettingHotelList;
        private System.Windows.Forms.ToolStripMenuItem itemSettingHotelRoom;
        private System.Windows.Forms.ToolStripMenuItem itemSettingHotelEmployee;
        private System.Windows.Forms.ToolStripMenuItem itemProfile;
        private System.Windows.Forms.ToolStripMenuItem itemBookingAll;
        private System.Windows.Forms.ToolStripMenuItem itemSettingPersonAll;
        private System.Windows.Forms.ToolStripMenuItem itemSettingPersonEmployee;
        private System.Windows.Forms.ToolStripMenuItem itemSettingClient;
        private System.Windows.Forms.ToolStripMenuItem kitchenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem orderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem foodToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem barToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem orderToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem drinksToolStripMenuItem;
    }
}

