using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace IPB_Końcowy.Models
{
    public partial class spaceyContext : DbContext
    {
        public spaceyContext()
        {
        }

        public spaceyContext(DbContextOptions<spaceyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Application> Application { get; set; }
        public virtual DbSet<Celestialbody> Celestialbody { get; set; }
        public virtual DbSet<Consultant> Consultant { get; set; }
        public virtual DbSet<Flight> Flight { get; set; }
        public virtual DbSet<Labresults> Labresults { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Personalizedoffer> Personalizedoffer { get; set; }
        public virtual DbSet<Ticket> Ticket { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=database.n0izy.pl;port=3306;user=zdalny;password=!@#123qweASD;database=spacey");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Application>(entity =>
            {
                entity.ToTable("application");

                entity.HasIndex(e => e.UserPersonId)
                    .HasName("Application_User");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.DateOfSubmitting).HasColumnType("date");

                entity.Property(e => e.UserPersonId)
                    .HasColumnName("User_Person_Id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.UserPerson)
                    .WithMany(p => p.Application)
                    .HasForeignKey(d => d.UserPersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Application_User");
            });

            modelBuilder.Entity<Celestialbody>(entity =>
            {
                entity.ToTable("celestialbody");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Gravity).HasColumnType("decimal(6,2)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(63)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Consultant>(entity =>
            {
                entity.HasKey(e => e.PersonId)
                    .HasName("PRIMARY");

                entity.ToTable("consultant");

                entity.Property(e => e.PersonId)
                    .HasColumnName("Person_Id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Person)
                    .WithOne(p => p.Consultant)
                    .HasForeignKey<Consultant>(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Consultant_Person");
            });

            modelBuilder.Entity<Flight>(entity =>
            {
                entity.ToTable("flight");

                entity.HasIndex(e => e.ArrBodyId)
                    .HasName("Flight_DepBody_Id");

                entity.HasIndex(e => e.DepBodyId)
                    .HasName("Flight_ArrBody_Id");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.ArrBodyId)
                    .HasColumnName("ArrBody_Id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DepBodyId)
                    .HasColumnName("DepBody_Id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .HasMaxLength(127)
                    .IsUnicode(false);

                entity.HasOne(d => d.ArrBody)
                    .WithMany(p => p.FlightArrBody)
                    .HasForeignKey(d => d.ArrBodyId)
                    .HasConstraintName("Flight_DepBody_Id");

                entity.HasOne(d => d.DepBody)
                    .WithMany(p => p.FlightDepBody)
                    .HasForeignKey(d => d.DepBodyId)
                    .HasConstraintName("Flight_ArrBody_Id");
            });

            modelBuilder.Entity<Labresults>(entity =>
            {
                entity.ToTable("labresults");

                entity.HasIndex(e => e.UserPersonId)
                    .HasName("LabResults_User");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Description).HasColumnType("int(11)");

                entity.Property(e => e.UserPersonId)
                    .HasColumnName("User_Person_Id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.UserPerson)
                    .WithMany(p => p.Labresults)
                    .HasForeignKey(d => d.UserPersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("LabResults_User");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("person");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.CanLogin).HasColumnType("int(11)");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(31)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(31)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(31)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Personalizedoffer>(entity =>
            {
                entity.ToTable("personalizedoffer");

                entity.HasIndex(e => e.UserPersonId)
                    .HasName("PersonalizedOffer_User");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Accepted).HasColumnType("int(11)");

                entity.Property(e => e.Price).HasColumnType("decimal(8,2)");

                entity.Property(e => e.UserPersonId)
                    .HasColumnName("User_Person_Id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.UserPerson)
                    .WithMany(p => p.Personalizedoffer)
                    .HasForeignKey(d => d.UserPersonId)
                    .HasConstraintName("PersonalizedOffer_User");
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.ToTable("ticket");

                entity.HasIndex(e => e.FlightId)
                    .HasName("Ticket_Flight");

                entity.HasIndex(e => e.UserPersonId)
                    .HasName("Ticket_User");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.FlightId)
                    .HasColumnName("Flight_Id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Price).HasColumnType("decimal(8,2)");

                entity.Property(e => e.UserPersonId)
                    .HasColumnName("User_Person_Id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Flight)
                    .WithMany(p => p.Ticket)
                    .HasForeignKey(d => d.FlightId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Ticket_Flight");

                entity.HasOne(d => d.UserPerson)
                    .WithMany(p => p.Ticket)
                    .HasForeignKey(d => d.UserPersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Ticket_User");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.PersonId)
                    .HasName("PRIMARY");

                entity.ToTable("user");

                entity.Property(e => e.PersonId)
                    .HasColumnName("Person_Id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Birthdate).HasColumnType("date");

                entity.Property(e => e.CreditCardNumber)
                    .HasMaxLength(22)
                    .IsUnicode(false);

                entity.Property(e => e.PaidSoFar).HasColumnType("decimal(10,2)");

                entity.Property(e => e.PaymentByInstallments).HasColumnType("tinyint(1)");

                entity.Property(e => e.SpacesuitSize)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.HasOne(d => d.Person)
                    .WithOne(p => p.User)
                    .HasForeignKey<User>(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("User_Person");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
