using Microsoft.EntityFrameworkCore;

namespace LearningManagementSystemAPI.Entities
{
    public class ApplicationDbContext : DbContext
    {
        private readonly string _connectionString = "Server=(localdb)\\mssqllocaldb;Database=LearningManagementSystemAPI;Trusted_Connection=True;";
        
        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Activity> Activities { get; set; } 
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {    
            modelBuilder.Entity<User>(u =>
            {
                u.Property(x => x.Id).HasDefaultValueSql("NEWID()");
                u.Property(u => u.PasswordHash).IsRequired();
                u.Property(u => u.FirstName).IsRequired().HasMaxLength(20);
                u.Property(u => u.LastName).IsRequired().HasMaxLength(30);
                u.Property(u => u.Email).IsRequired();
                u.Property(u => u.RoleId).IsRequired();
                u.HasData(
                    new User { Id = Guid.NewGuid(), Email = "student@test.local", PasswordHash = "", FirstName = "studenttest", LastName = "studenttest", RoleId = 3 },
                    new User { Id = Guid.NewGuid(), Email = "teacher@test.local", PasswordHash = "", FirstName = "teachertest", LastName = "teachertest", RoleId = 3 },
                    new User { Id = Guid.NewGuid(), Email = "admin@test.local", PasswordHash = "", FirstName = "admintest", LastName = "admintest", RoleId = 3 });
            });

            modelBuilder.Entity<Role>(r =>
            {
                r.Property(r => r.Name).IsRequired();
                r.HasData(
                    new Role { Id = 1, Name = "Admin" },
                    new Role { Id = 2, Name = "Teacher" },
                    new Role { Id = 3, Name = "Student" });
            });

            modelBuilder.Entity<Course>(c =>
            {
                c.Property(c => c.Name).IsRequired();
                c.HasData(
                        new Course() { Id = 1, Name = "Mathematics", Description = "Test course", AuthorId="server" }
                );
            });

            modelBuilder.Entity<Activity>(a =>
            {
                a.Property(a => a.Name).IsRequired().HasMaxLength(100);
                a.Property(a => a.Details).IsRequired().HasMaxLength(250);
            });
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
