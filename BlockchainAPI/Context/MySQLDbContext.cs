
using TransactionsAPI.Entities.Users;
using Microsoft.EntityFrameworkCore;
using TransactionsAPI.Entities.Users;

namespace TransactionsAPI.Context
{
    public class MySQLDbContext : DbContext
    {
        public DbSet<UserProfile> UserProfile { get; set; }
        public DbSet<Bank> Bank { get; set; }
        public DbSet<Transaction> Transaction { get; set; }

        public MySQLDbContext(DbContextOptions<MySQLDbContext> options) :  base(options)  { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            populateDatabase(modelBuilder);
        }

        private void populateDatabase(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder
                .Entity<Bank>()
                .HasData(new Bank
                {
                    id=1,
                    nameBank= "Finandina",
                });
            modelBuilder
                .Entity<UserProfile>()
                .HasData(new UserProfile
                {
                    account= 1234567890,
                    name= "Marlon Osorio",
                    dni= 123456789,
                    email= "marlon@gmail.com",
                    fkBank= 1
                },
                   new UserProfile
                   {
                       account= 1234567899,
                       name= "Carlos Lopez",
                       dni= 1111111111,
                       email= "carlos@correo.com",
                       fkBank= 1,
                   });
            
        }
    }
}