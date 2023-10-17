using Microsoft.EntityFrameworkCore;

namespace ASP.NET_WebAPI6.Entities
{
    public partial class DBContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        public DbSet<Student> Students { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<StudentResult> StudentResults { get; set; }


        public DBContext()
        {
        }

        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=IOTCloudRobomatics;database=demo");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.Mail)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.Skillsets)
                    .IsRequired()
                    .HasMaxLength(45);


                entity.Property(e => e.Hobby)
                    .IsRequired()
                    .HasMaxLength(45);

                modelBuilder.Entity<Book>()
                     .HasOne(b => b.Author)
                     .WithMany(a => a.Books)
                     .HasForeignKey(b => b.AuthorId);

                modelBuilder.Entity<StudentResult>()
                    .HasKey(sr => new { sr.StudentId, sr.ResultId });

                modelBuilder.Entity<StudentResult>()
                    .HasOne(sr => sr.Student)
                    .WithMany(s => s.StudentResults)
                    .HasForeignKey(sr => sr.StudentId);

                modelBuilder.Entity<StudentResult>()
                    .HasOne(sr => sr.Result)
                    .WithMany(r => r.StudentResults)
                    .HasForeignKey(sr => sr.ResultId);


            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
