using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BusReservation1.Models
{
    public partial class BusReservationContext : DbContext
    {
        public BusReservationContext()
        {
        }

        public BusReservationContext(DbContextOptions<BusReservationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bu> buses { get; set; }
        public object Buses { get; internal set; }
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<Passenger> Passengers { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<ReturnJourney> ReturnJourneys { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<TicketBooking> TicketBookings { get; set; }
        public virtual DbSet<TicketCancellation> TicketCancellations { get; set; }
        public virtual DbSet<UserProfile> UserProfiles { get; set; }
        public object Bu { get; internal set; }

        /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         {
             if (!optionsBuilder.IsConfigured)
             {
 #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                 optionsBuilder.UseSqlServer("Server=QCLAP758P466\\SQLEXPRESS;Database=BusReservation;User ID=sa;Password=newuser123#;");
             }
         }
        */

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Bu>(entity =>
            {
                entity.HasKey(e => e.BusId)
                    .HasName("PK__Bus__B0524D19350155A4");

                entity.ToTable("Bus");

                entity.Property(e => e.BusId)
                    .ValueGeneratedNever()
                    .HasColumnName("Bus_Id");

                entity.Property(e => e.BusName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Bus_Name");

                entity.Property(e => e.BusNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Bus_No");

                entity.Property(e => e.BusType)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Bus_Type");

                entity.Property(e => e.Departure)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Destination)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.EndDate)
                    .HasColumnType("date")
                    .HasColumnName("End_Date");

                entity.Property(e => e.NoOfSeatsAvailable).HasColumnName("No_of_Seats_Available");

                entity.Property(e => e.ReturnId).HasColumnName("Return_Id");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("Start_Date");

                entity.Property(e => e.TicketPrice).HasColumnName("Ticket_Price");

                entity.HasOne(d => d.Return)
                    .WithMany(p => p.Bus)
                    .HasForeignKey(d => d.ReturnId)
                    .HasConstraintName("FK__Bus__Return_Id__5070F446");
            });

            modelBuilder.Entity<Driver>(entity =>
            {
                entity.ToTable("Driver");

                entity.Property(e => e.DriverId)
                    .ValueGeneratedNever()
                    .HasColumnName("Driver_Id");

                entity.Property(e => e.DriverContact)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Driver_Contact");

                entity.Property(e => e.DriverName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Driver_Name");

                entity.Property(e => e.UserId).HasColumnName("User_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Drivers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Driver__User_id__46E78A0C");
            });

            modelBuilder.Entity<Passenger>(entity =>
            {
                entity.ToTable("Passenger");

                entity.Property(e => e.PassengerId)
                    .ValueGeneratedNever()
                    .HasColumnName("Passenger_Id");

                entity.Property(e => e.BookingId).HasColumnName("Booking_Id");

                entity.Property(e => e.EmailId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Email_Id");

                entity.Property(e => e.Gender)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NoOfPassengers).HasColumnName("No_of_Passengers");

                entity.Property(e => e.PassengerContact)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Passenger_Contact");

                entity.Property(e => e.PassengerName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Passenger_Name");

                entity.Property(e => e.SeatNo).HasColumnName("Seat_no");

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.Passengers)
                    .HasForeignKey(d => d.BookingId)
                    .HasConstraintName("FK__Passenger__Booki__412EB0B6");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("Payment");

                entity.Property(e => e.PaymentId)
                    .ValueGeneratedNever()
                    .HasColumnName("Payment_Id");

                entity.Property(e => e.AmountPaid).HasColumnName("Amount_Paid");

                entity.Property(e => e.BookingId).HasColumnName("Booking_Id");

                entity.Property(e => e.PaymentDate)
                    .HasColumnType("date")
                    .HasColumnName("Payment_Date");

                entity.Property(e => e.PaymentType)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Payment_Type");

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.BookingId)
                    .HasConstraintName("FK__Payment__Booking__440B1D61");
            });

            modelBuilder.Entity<ReturnJourney>(entity =>
            {
                entity.HasKey(e => e.ReturnId)
                    .HasName("PK__ReturnJo__0F4F4C36A4259096");

                entity.ToTable("ReturnJourney");

                entity.Property(e => e.ReturnId)
                    .ValueGeneratedNever()
                    .HasColumnName("Return_Id");

                entity.Property(e => e.NoOfPassengers).HasColumnName("No_of_Passengers");

                entity.Property(e => e.ReturnDate)
                    .HasColumnType("date")
                    .HasColumnName("Return_Date");

                entity.Property(e => e.ReturnFrom)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Return_From");

                entity.Property(e => e.ReturnTicketPrice).HasColumnName("Return_Ticket_Price");

                entity.Property(e => e.ReturnTime).HasColumnName("Return_Time");

                entity.Property(e => e.ReturnTo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Return_To");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.RoleId)
                    .ValueGeneratedNever()
                    .HasColumnName("Role_Id");

                entity.Property(e => e.RoleDescription)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Role_Description");

                entity.Property(e => e.RoleTitle)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Role_Title");

                entity.Property(e => e.UserId).HasColumnName("User_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Roles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Role__User_id__49C3F6B7");
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.ToTable("Schedule");

                entity.Property(e => e.ScheduleId)
                    .ValueGeneratedNever()
                    .HasColumnName("Schedule_Id");

                entity.Property(e => e.BusId).HasColumnName("Bus_Id");

                entity.Property(e => e.Departure)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DepartureTime).HasColumnName("Departure_Time");

                entity.Property(e => e.Destination)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DriverId).HasColumnName("Driver_Id");

                entity.Property(e => e.EstimatedArrivalTime).HasColumnName("Estimated_Arrival_Time");

                entity.Property(e => e.FareAmount).HasColumnName("Fare_Amount");

                entity.Property(e => e.Remark)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ScheduleDate)
                    .HasColumnType("date")
                    .HasColumnName("Schedule_Date");

                entity.Property(e => e.UserId).HasColumnName("User_id");

                entity.HasOne(d => d.Bus)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.BusId)
                    .HasConstraintName("FK__Schedule__Bus_Id__5535A963");

                entity.HasOne(d => d.Driver)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.DriverId)
                    .HasConstraintName("FK__Schedule__Driver__5629CD9C");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Schedule__User_i__5441852A");
            });

            modelBuilder.Entity<TicketBooking>(entity =>
            {
                entity.HasKey(e => e.BookingId)
                    .HasName("PK__Ticket_B__35ABFDC045CDA496");

                entity.ToTable("TicketBooking");

                entity.Property(e => e.BookingId)
                    .ValueGeneratedNever()
                    .HasColumnName("Booking_Id");

                entity.Property(e => e.BookingStatus)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Booking_Status");

                entity.Property(e => e.DateOfBooking)
                    .HasColumnType("date")
                    .HasColumnName("Date_of_Booking");

                entity.Property(e => e.FareAmount).HasColumnName("Fare_Amount");

                entity.Property(e => e.NoOfSeats).HasColumnName("No_of_Seats");

                entity.Property(e => e.NoOfTickets).HasColumnName("No_of_Tickets");

                entity.Property(e => e.TicketPrice).HasColumnName("Ticket_Price");

                entity.Property(e => e.UserId).HasColumnName("User_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TicketBookings)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Ticket_Bo__User___38996AB5");
            });

            modelBuilder.Entity<TicketCancellation>(entity =>
            {
                entity.HasKey(e => e.CancellationId)
                    .HasName("PK__TicketCa__BC9DC290E4F316BB");

                entity.ToTable("TicketCancellation");

                entity.Property(e => e.CancellationId)
                    .ValueGeneratedNever()
                    .HasColumnName("Cancellation_Id");

                entity.Property(e => e.BookingId).HasColumnName("Booking_Id");

                entity.Property(e => e.IsCancel)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Is_Cancel");

                entity.Property(e => e.IsRefund).HasColumnName("Is_Refund");

                entity.Property(e => e.IsReschedule)
                    .HasColumnType("date")
                    .HasColumnName("Is_Reschedule");

                entity.Property(e => e.ReturnId).HasColumnName("Return_Id");

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.TicketCancellations)
                    .HasForeignKey(d => d.BookingId)
                    .HasConstraintName("FK__TicketCan__Booki__4CA06362");

                entity.HasOne(d => d.Return)
                    .WithMany(p => p.TicketCancellations)
                    .HasForeignKey(d => d.ReturnId)
                    .HasConstraintName("FK__TicketCan__Retur__4D94879B");
            });

            modelBuilder.Entity<UserProfile>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserProf__206A9DF81CD36D70");

                entity.ToTable("UserProfile");

                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("User_id");

                entity.Property(e => e.Address)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ContactNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Contact_No");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("DOB");

                entity.Property(e => e.EmailId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Email_Id");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("First_Name");

                entity.Property(e => e.Gender)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Last_Name");

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
