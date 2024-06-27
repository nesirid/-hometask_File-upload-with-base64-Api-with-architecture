using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System.Reflection;


namespace Repository.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        public DbSet<Group> Groups { get; set; }
        public DbSet<Student> Students { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<GroupsStudents>()
                .HasKey(t => new { t.GroupId, t.StudentId });
            modelBuilder.Entity<GroupsStudents>()
                .HasOne(t => t.Group)
                .WithMany(t => t.GroupsStudents)
                .HasForeignKey(t => t.GroupId);





            modelBuilder.Entity<GroupsStudents>()
                .HasKey(t => new { t.StudentId, t.GroupId });
            modelBuilder.Entity<GroupsStudents>()
                .HasOne(t => t.Student)
                .WithMany(t => t.GroupsStudents)
                .HasForeignKey(t => t.StudentId);


        }
    }
}