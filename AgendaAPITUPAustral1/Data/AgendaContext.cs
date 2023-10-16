using AgendaAPITUPAustral1.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AgendaAPITUPAustral1.Data
{
    public class AgendaContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public AgendaContext(DbContextOptions<AgendaContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasData(
                    new User()
                    {
                        Email = "email@gmail.com",
                        Name = "user",
                        Id = 1,
                        Password = "pass"
                    },
                    new User()
                    {
                        Email = "email2@gmail.com",
                        Name = "user2",
                        Id = 2,
                        Password = "pass"
                    });

            modelBuilder.Entity<Contact>()
                .HasOne<User>(c => c.User);

            modelBuilder.Entity<User>()
                .HasMany<Contact>(u => u.Contacts)
                .WithOne(c => c.User);

            base.OnModelCreating(modelBuilder);
        }
    }
}
