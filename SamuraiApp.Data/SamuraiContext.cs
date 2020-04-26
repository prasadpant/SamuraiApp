using Microsoft.EntityFrameworkCore;
using SamuraiApp.Domain;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Logging;



namespace SamuraiApp.Data
{
    public class SamuraiContext : DbContext
    {
        
        


       public static readonly LoggerFactory MyConsoleLoggerFactory
                    = new LoggerFactory(new[] {
                                   new ConsoleLoggerProvider((category, level)
                                       => category == DbLoggerCategory.Database.Command.Name
                                           && level == LogLevel.Information, true) });

        public DbSet<Samurai> Samurais { get; set; }

        public DbSet<Quote> Quotes { get; set; } 

        public DbSet<Battle> Battles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //var logger = optionsBuilder.UseLoggerFactory(MyConsoleLoggerFactory);
            //var sensitiveData = logger.EnableSensitiveDataLogging(true);
            //sensitiveData.UseSqlServer("Server = LENOVO-VEERAM; Database = SamuraiAppData; Trusted_Connection = True; ");
                        
            // Second Commit
            optionsBuilder
                .UseLoggerFactory(MyConsoleLoggerFactory)
                .EnableSensitiveDataLogging(true)
                .UseSqlServer("Server = LENOVO-VEERAM; Database = SamuraiAppData; Trusted_Connection = True; ");

            //TestClass testClassNamePerNaga  = new TestClass();
            //testClassNamePerNaga.add().subtract(10,5);
            
                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SamuraiBattle>().HasKey(s => new { s.SamuraiId, s.BattleId });

        }
    }
}
