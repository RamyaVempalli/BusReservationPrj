create database BusReservation
/*create table returntbl(return_id int primary key,return_date date, return_from nvarchar,return_to nvarchar,no_of_passengers int,return_ticket_price float,return_time time)
 
 select *from returntbl
 Drop table returntbl
 alter table Ticket_Booking rename to TicketBooking
RENAME TABLE Ticket_Booking TO TicketBooking;
sp_rename 'Ticket_Booking','TicketBooking'
RENAME Ticket_Booking TO TicketBooking
  EXEC sp_rename 'Ticket_Booking','TicketBooking'
 Drop table Ticket_Booking
 select * from TicketBooking
  sp_helper Bus
  */
 select * from Bus

 sp_help Bus


 /*Return*/
 create table ReturnJourney(Return_Id int primary key,Return_Date date, Return_From nvarchar,Return_To nvarchar,No_of_Passengers int,Return_Ticket_Price float,Return_Time time)

 alter table  ReturnJourney alter column Return_From varchar(20)
 alter table  ReturnJourney alter column Return_To varchar(20)
 /*Inserted*/
 insert into ReturnJourney(Return_Id,Return_Date,Return_From,Return_To,No_of_Passengers,Return_Ticket_Price,Return_Time) 
 values(100,'2022-03-30','Pune','Mumbai',5,1000,'21:00:00'),
        (101,'2022-04-02','Pune','Mumbai',3,980,'21:00:00')
select * from ReturnJourney

 /*User Profile*/
 create table UserProfile(User_id int primary key,First_Name varchar(20),Last_Name varchar(20),Contact_No varchar(20),Gender varchar(20),
 Email_Id varchar(20),DOB date ,Password varchar(20),Address varchar(20))

 alter table UserProfile drop column User_id

 /*Inserted*/
 insert into UserProfile(User_id,First_Name,Last_Name,Contact_No,Gender,Email_Id,DOB,Password,Address)
 values(1,'Ramya','Vempalli','9876543210','Female','ramya@gmail.com','23-Sep-1998','','Tanuku'),
        (2,'Rahul','D','9876543211','Male','rahul@gmail.com','16-Aug-1999','','Chennai'),
		(3,'Manasa','Singam','9876544210','Female','manasa@gmail.com','01-Dec-1999','','Kadapa'),
		(4,'Venkat','Mamillapalli','9877543210','Male','venkat@gmail.com','02-Dec-1998','','Ongole'),
		(5,'Tushant','Sutar','9886543210','Male','tushant@gmail.com','20-Jan-1999','','Mumbai')


select * from UserProfile

insert into UserProfile(Password)values('ramya1'),('rahul2'),('manasa3'),('venkat4'),('tushant5')

 /* Ticket Booking*/
 create table TicketBooking(Booking_Id int primary key,User_id int foreign key references UserProfile(User_id),No_of_Tickets int,No_of_Seats int,
 Date_of_Booking date,Ticket_Price float,Booking_Status varchar(20),Fare_Amount float)
 /*Inserted*/
 insert into TicketBooking(Booking_Id,User_id,No_of_Tickets,No_of_Seats, Date_of_Booking,Ticket_Price,Booking_Status,Fare_Amount)
 values(1000,1,1,1,'2022-03-19',560,'Pending',560),
        (1001,3,2,2,'2022-03-25',560,'Booked',1120)

select * from TicketBooking

 /*Passenger*/
 create table Passenger(Passenger_Id int primary key,Passenger_Name varchar(20),Age int,Gender varchar(20),Passenger_Contact varchar,
 Email_Id varchar(20),No_of_Passengers int,Booking_Id int foreign key references TicketBooking(Booking_Id))
 /*Inserted*/
 alter table Passenger alter column Passenger_Contact varchar(20)
 alter table Passenger add Seat_no int 

 insert into Passenger(Passenger_Id,Passenger_Name,Age,Gender,Passenger_Contact,Email_Id,No_of_Passengers,Booking_Id )
 values(10,'Ramya',23,'Female','8576543216','ramya@gmail.com',1,1000),
       (11,'Manasa',23,'Female','7876543214','manasa@gmail.com',2,1001),
	   (12,'Kavya',25,'Female','6876594212','manasa@gmail.com',2,1001)

select * from Passenger

 /*Payment*/
 create table Payment(Payment_Id int primary key,Booking_Id int foreign key references TicketBooking(Booking_Id),
 Payment_Type varchar(20),Payment_Date date,Amount_Paid float)
 /*Inserted*/
 insert into Payment(Payment_Id,Booking_Id,Payment_Type,Payment_Date,Amount_Paid)
 values(10050,1000,'Debitcard','2022-03-15',560),
        (10250,1001,'Debitcard','2022-03-14',1120)

select * from Payment

 /*Driver*/
 create table Driver(Driver_Id int primary key,Driver_Name varchar(20),Driver_Contact varchar(20),User_id int foreign key references UserProfile(User_id))
 /*Inserted*/
 insert into Driver(Driver_Id,Driver_Name,Driver_Contact,User_id)
 values(500,'Kashi','8790543216',1)

 select * from Driver

 /*Bus*/
 create table Bus(Bus_Id int primary key,Bus_No varchar(20),Bus_Type varchar(20),Bus_Name varchar(20),Departure varchar(20),Destination varchar(20),
 No_of_Seats_Available int,Capacity int,Start_Date date,End_Date date,Return_Id int foreign key references ReturnJourney(Return_Id),
 Ticket_Price float)

 select * from Bus

insert into Bus(Bus_Id,Bus_No,Bus_Type,Bus_Name,Departure,Destination,No_of_Seats_Available,Capacity,End_Date,Return_Id,Ticket_Price)
values(01,'MH-5040','Sleeper','Vinayaka','Mumbai','Pune',10,37,'2022-03-20',101,560)

insert into Bus(Bus_Id,Bus_No,Bus_Type,Bus_Name,Departure,Destination,No_of_Seats_Available,Capacity,Start_Date,End_Date,Return_Id,Ticket_Price)
values(02,'MH-5050','Seater','Krishna','Hyderabad','Vizag',10,37,'2022-03-17','2022-03-18',101,560)
     
 

/* alter table Bus add foreign key(Schedule_Id) references Schedule(Schedule_Id)*/


 /*Schedule*/
 create table Schedule(Schedule_Id int primary key,User_id int foreign key references UserProfile(User_id),Bus_Id int foreign key references Bus(Bus_Id),
 Driver_Id int foreign key references Driver(Driver_Id),Departure varchar(20),Destination varchar(20),Schedule_Date date,
 Departure_Time time,Estimated_Arrival_Time time,Fare_Amount float,Remark varchar(20))

 /*Inserted*/
 insert into Schedule(Schedule_Id,User_id,Bus_Id,Driver_Id,Departure,Destination,Schedule_Date,Departure_Time,Estimated_Arrival_Time,Fare_Amount,Remark)
 values(50,1,01,500,'Mumbai','Pune','2022-03-19','22:00:00','2:00:00',560,'')
       


 /*Role*/
 create table Role(Role_Id int primary key,Role_Title varchar(20),Role_Description varchar(20),User_id int foreign key references UserProfile(User_id))
 /*Inserted*/
 insert into Role(Role_Id,Role_Title,Role_Description,User_id)
 values(400,'Manager','Schedule Booking',1)

 select * from Role

 /*Ticket Cancellation*/
 create table TicketCancellation(Cancellation_Id int primary key,Booking_Id int foreign key references TicketBooking(Booking_Id),
 Is_Cancel varchar(20),Is_Refund float,Is_Reschedule date,Return_Id int foreign key references ReturnJourney(Return_Id))
  /*Inserted*/
 insert into TicketCancellation(Cancellation_Id,Booking_Id,Is_Cancel,Is_Refund,Is_Reschedule,Return_Id)
 values(2000,1000,'yes','500','','100'),
       (2001,1001,'No','','2022-03-30','101')

	 select * from TicketCancellation