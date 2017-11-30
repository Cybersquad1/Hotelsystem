drop table tbPerson;
drop table tbHotel;
drop table tbRoomType;
drop table tbRoom;
drop table tbBooking;
drop table tbHotelEmployee;
drop table tbHotelRoomType;
drop table tbPayment;

create table tbPerson(
	PersonID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	FirstName nvarchar(50) NOT NULL, 
	LastName nvarchar(50) NOT NULL, 
	Email nvarchar(50) NOT NULL,
	Login nvarchar(50) NOT NULL,
	Password nvarchar(20) NOT NULL,
	Role nvarchar(50), 
	Birth date NOT NULL,	
	Telephone nvarchar(50), 
	Gender nvarchar(10) NOT NULL,
	Salary decimal(18,0),
	Passport nvarchar(20),
	Address nvarchar(50),
	Position nvarchar(20),
);
create table tbHotel(
	HotelID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Name nvarchar(50) NOT NULL,
	City nvarchar(20),
	Street nvarchar(max),
	Email nvarchar(50),
	Telephone nvarchar(50)
);
create table tbRoomType(
	RoomTypeID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Name nvarchar(50) NOT NULL, 
	Description nvarchar(200),
	Price decimal,
	MaxPerson int,
);
create table tbRoom(
	RoomID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Name nvarchar(50) NOT NULL, 
	_roomTypeID int NOT NULL,
	_hotelID int NOT NULL,
);
create table tbBooking(
	BookingID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	_roomID int NOT NULL,
	_clientID int NOT NULL,
	StartDate date,
	EndDate date,
	Status nvarchar(50) NOT NULL,
);
create table tbHotelEmployee(
    HotelEmployeeID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	_hotelID int NOT NULL,
	_employeeID int NOT NULL,
);
create table tbHotelRoomType(
	HotelRoomTypeID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	_hotelID int NOT NULL,
	_roomTypeID int NOT NULL,
);
create table tbPayment(
	PaymentID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	_bookingID int NOT NULL,
	Amount int NOT NULL,
	PaymentDate datetime NOT NULL,
);