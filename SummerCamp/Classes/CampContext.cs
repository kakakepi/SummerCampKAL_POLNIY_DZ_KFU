using Microsoft.EntityFrameworkCore;

namespace SummerCamp
{
    public class CampContext : DbContext
    {
        public DbSet<Camper> Campers { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Schedule> Schedules { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseNpgsql("Host=localhost;Database=SummerCamp;Username=postgres;Password=MNXAKER123;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Schedule>()
                .HasOne(s => s.Activity)
                .WithMany()
                .HasForeignKey(s => s.ActivityId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Schedule>()
                .HasOne(s => s.Camper)
                .WithMany(c => c.Schedules)
                .HasForeignKey(s => s.CamperId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Camper>().OwnsOne(c => c.Contacts);
            modelBuilder.Entity<Activity>().OwnsOne(a => a.Instructor);
        }
    }
}