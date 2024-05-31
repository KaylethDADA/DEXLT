using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Dal.EntityFramework
{
    public class TelegramBotDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<CustomField<string>> CustomFields { get; set; }

        public TelegramBotDbContext(DbContextOptions<TelegramBotDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql("User ID=postgres;Password=1488;Host=localhost;Port=5432;Database=postgres;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TelegramBotDbContext).Assembly);
        }
    }
}
