using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BeMyNeighbor.Data.Entities
{
    public partial class BeMyNeighborDBContext : DbContext
    {
        public BeMyNeighborDBContext()
        {
        }

        public BeMyNeighborDBContext(DbContextOptions<BeMyNeighborDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Community> Community { get; set; }
        public virtual DbSet<EvaluationQuestions> EvaluationQuestions { get; set; }
        public virtual DbSet<GeoLocation> GeoLocation { get; set; }
        public virtual DbSet<Post> Post { get; set; }
        public virtual DbSet<Questions> Questions { get; set; }
        public virtual DbSet<Task> Task { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UsersEvaluation> UsersEvaluation { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:pizzaslice.database.windows.net,1433;Initial Catalog=BeMyNeighborDB;Persist Security Info=False;User ID=localuser;Password=Password12345;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Address", "Location");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.StateProvince)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.StreetName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Community>(entity =>
            {
                entity.ToTable("Community", "Communities");

                entity.Property(e => e.CommunityId).HasColumnName("CommunityID");

                entity.Property(e => e.CommunityName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.Radius).HasColumnType("decimal(5, 2)");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Community)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Community_GeoLocation_FK");
            });

            modelBuilder.Entity<EvaluationQuestions>(entity =>
            {
                entity.HasKey(e => new { e.EvaluationId, e.QuestionId })
                    .HasName("Eval_Quest_PK");

                entity.ToTable("EvaluationQuestions", "Evaluation");

                entity.Property(e => e.EvaluationId).HasColumnName("EvaluationID");

                entity.Property(e => e.QuestionId).HasColumnName("QuestionID");

                entity.HasOne(d => d.Evaluation)
                    .WithMany(p => p.EvaluationQuestions)
                    .HasForeignKey(d => d.EvaluationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Questions_UserEvaluation_FK");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.EvaluationQuestions)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Question_EvalQuestion_FK");
            });

            modelBuilder.Entity<GeoLocation>(entity =>
            {
                entity.ToTable("GeoLocation", "Location");

                entity.Property(e => e.GeoLocationId).HasColumnName("GeoLocationID");

                entity.Property(e => e.Latitude).HasColumnType("decimal(12, 9)");

                entity.Property(e => e.Longitude).HasColumnType("decimal(12, 9)");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("Post", "Posts");

                entity.Property(e => e.PostId).HasColumnName("PostID");

                entity.Property(e => e.CommunityId).HasColumnName("CommunityID");

                entity.Property(e => e.GeoLocationId).HasColumnName("GeoLocationID");

                entity.Property(e => e.TaskTypeId).HasColumnName("TaskTypeID");

                entity.HasOne(d => d.Community)
                    .WithMany(p => p.Post)
                    .HasForeignKey(d => d.CommunityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CommunityID_FK");

                entity.HasOne(d => d.GeoLocation)
                    .WithMany(p => p.Post)
                    .HasForeignKey(d => d.GeoLocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("GeoLocation_FK");

                entity.HasOne(d => d.TaskType)
                    .WithMany(p => p.Post)
                    .HasForeignKey(d => d.TaskTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TaskType_FK");
            });

            modelBuilder.Entity<Questions>(entity =>
            {
                entity.HasKey(e => e.QuestionId)
                    .HasName("Task_PK");

                entity.ToTable("Questions", "Evaluation");

                entity.Property(e => e.QuestionId).HasColumnName("QuestionID");

                entity.Property(e => e.QuestionText).IsRequired();
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.HasKey(e => e.TaskTypeId)
                    .HasName("Task_PK");

                entity.ToTable("Task", "Tasks");

                entity.Property(e => e.TaskTypeId).HasColumnName("TaskTypeID");

                entity.Property(e => e.TaskDescription).HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User", "Users");

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__User__A9D10534EE6A78D8")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.CommunityId).HasColumnName("CommunityID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.HashedPassword).IsRequired();

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.SeedPassword).IsRequired();

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("User_Address_FK");
            });

            modelBuilder.Entity<UsersEvaluation>(entity =>
            {
                entity.HasKey(e => e.EvaluationId)
                    .HasName("UserEval_PK");

                entity.ToTable("UsersEvaluation", "Evaluation");

                entity.Property(e => e.EvaluationId).HasColumnName("EvaluationID");

                entity.Property(e => e.PostId).HasColumnName("PostID");

                entity.Property(e => e.TaskTypeId).HasColumnName("TaskTypeID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.UsersEvaluation)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Post_FK");

                entity.HasOne(d => d.TaskType)
                    .WithMany(p => p.UsersEvaluation)
                    .HasForeignKey(d => d.TaskTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Task_FK");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UsersEvaluation)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("User_Evaluation_FK");
            });
        }
    }
}
