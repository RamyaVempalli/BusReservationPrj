create database BusReservationProject

 sp_help Bus

 /*User Profile*/
 create table UserProfile(User_id int identity(1,1)primary key,First_Name varchar(20),Last_Name varchar(20),Contact_No varchar(20),Gender varchar(20),
 Email_Id varchar(20),DOB date ,Password varchar(20),Confirm_Password varchar(20),Address varchar(20))



 /*Inserted*/
 insert into UserProfile(First_Name,Last_Name,Contact_No,Gender,Email_Id,DOB,Password,Confirm_Password,Address)
 values ('Ramya','Vempalli','9876543210','Female','ramya@gmail.com','23-Sep-1998','ramya@123','','Tanuku'),
        ('Rahul','D','9876543211','Male','rahul@gmail.com','16-Aug-1999','rahul@123','','Chennai'),
		('Manasa','Singam','9876544210','Female','manasa@gmail.com','01-Dec-1999','manasa@123','','Kadapa'),
		('Venkat','Mamillapalli','9877543210','Male','venkat@gmail.com','02-Dec-1998','venkat@123','','Ongole'),
		('Tushant','Sutar','9886543210','Male','tushant@gmail.com','20-Jan-1999','tushant@123','','Mumbai')


select * from UserProfile


 /* Ticket Booking*/
 create table TicketBooking(Booking_Id int identity(1000,1)primary key,User_id int foreign key references UserProfile(User_id),No_of_Tickets int,No_of_Seats int,
 Date_of_Booking date,Ticket_Price float,Booking_Status varchar(20),Fare_Amount float)
 /*Inserted*/
 insert into TicketBooking(User_id,No_of_Tickets,No_of_Seats, Date_of_Booking,Ticket_Price,Booking_Status,Fare_Amount)
 values (1,1,1,'2022-03-19',560,'Pending',560),
        (3,2,2,'2022-03-25',560,'Booked',1120)

select * from TicketBooking



/*Passenger*/
 create table Passenger(Passenger_Id int identity(10,1) primary key,Passenger_Name varchar(20),Age int,Gender varchar(20),Passenger_Contact varchar(20),
 Email_Id varchar(20),No_of_Passengers int,Booking_Id int foreign key references TicketBooking(Booking_Id),Seat_No int)
 /*Inserted*/
 

 insert into Passenger(Passenger_Name,Age,Gender,Passenger_Contact,Email_Id,No_of_Passengers,Booking_Id,Seat_No)
 values('Ramya',23,'Female','8576543216','ramya@gmail.com',1,1000,25),
       ('Manasa',23,'Female','7876543214','manasa@gmail.com',2,1001,15),
	   ('Kavya',25,'Female','6876594212','manasa@gmail.com',2,1001,16)

select * from Passenger


 /*Payment*/
 create table Payment(Payment_Id int identity(1,1)primary key,Booking_Id int foreign key references TicketBooking(Booking_Id),
 Payment_Type varchar(20),Payment_Date date,Amount_Paid float)
 /*Inserted*/
 insert into Payment(Booking_Id,Payment_Type,Payment_Date,Amount_Paid)
 values(1000,'Debitcard','2022-03-15',560),
        (1001,'Debitcard','2022-03-14',1120)

select * from Payment


 /*Driver*/
 create table Driver(Driver_Id int identity(500,1)primary key,Driver_Name varchar(20),Driver_Contact varchar(20))
 /*Inserted*/
 insert into Driver(Driver_Name,Driver_Contact)
 values('Kashi','8790543216'),
       ('Pranai','8790543256'),
	   ('Kishore','8790573216')


 select * from Driver



  /*Return*/
 create table ReturnJourney(Return_Id int identity(100,1)primary key,Return_Date date, Return_From varchar(20),Return_To varchar(20),
 No_of_Passengers int,Return_Ticket_Price float,Return_Time time)

 /*Inserted*/
 insert into ReturnJourney(Return_Date,Return_From,Return_To,No_of_Passengers,Return_Ticket_Price,Return_Time) 
 values('2022-03-30','Pune','Mumbai',5,1000,'21:00:00'),
        ('2022-04-02','Pune','Mumbai',3,980,'21:00:00'),
 ('2022-04-15','Vizag','Hyderabad',3,980,'21:00:00'),
 ('2022-04-15','Chennai','Hyderabad',2,980,'19:00:00')
		
select * from ReturnJourney



 /*Bus*/
 create table Bus(Bus_Id int identity(100,1)primary key,Bus_No varchar(20),Bus_Type varchar(20),Bus_Name varchar(20),Departure varchar(20),Destination varchar(20),
 No_of_Seats_Available int,Capacity int,Start_Date date,End_Date date,Return_Id int foreign key references ReturnJourney(Return_Id),
 Ticket_Price float)

insert into Bus(Bus_No,Bus_Type,Bus_Name,Departure,Destination,No_of_Seats_Available,Capacity,Start_Date,End_Date,Return_Id,Ticket_Price)
values('MH-5040','Sleeper','Vinayaka','Mumbai','Pune',10,37,'2022-03-20','2022-03-21',101,560),
       ('AP-5050','Seater','Krishna','Hyderabad','Vizag',10,37,'2022-03-17','2022-03-18',103,560)

 select * from Bus


 /*Schedule*/
 create table Schedule(Schedule_Id int identity(50,1)primary key,User_id int foreign key references UserProfile(User_id),Bus_Id int foreign key references Bus(Bus_Id),
 Driver_Id int foreign key references Driver(Driver_Id),Departure varchar(20),Destination varchar(20),Schedule_Date date,
 Departure_Time time,Estimated_Arrival_Time time,Fare_Amount float,Remark varchar(20))

 /*Inserted*/
 insert into Schedule(User_id,Bus_Id,Driver_Id,Departure,Destination,Schedule_Date,Departure_Time,Estimated_Arrival_Time,Fare_Amount,Remark)
 values(1,104,500,'Mumbai','Pune','2022-03-20','22:00:00','2:00:00',560,'')
       

select * from Schedule     



/*Role*/
 create table Role(Role_Id int identity(400,1)primary key,Role_Title varchar(20),Role_Description varchar(20),User_id int foreign key references UserProfile(User_id))
 /*Inserted*/
 insert into Role(Role_Title,Role_Description,User_id)
 values('Manager','Schedule Booking',1)

 select * from Role
 


  /*Ticket Cancellation*/
 create table TicketCancellation(Cancellation_Id int identity(2000,1)primary key,Booking_Id int foreign key references TicketBooking(Booking_Id),
 Is_Cancel varchar(20),Is_Refund float,Is_Reschedule date,Return_Id int foreign key references ReturnJourney(Return_Id))
  /*Inserted*/
 insert into TicketCancellation(Booking_Id,Is_Cancel,Is_Refund,Is_Reschedule,Return_Id)
 values(1000,'yes','500','','100'),
       (1001,'No','','2022-03-30','101')

	 select * from TicketCancellation