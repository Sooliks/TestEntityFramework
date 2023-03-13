using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Npgsql;
using TestEntityFramework.DataBase.ModelConfiguration;
using TestEntityFramework.DataBase.Models;

namespace TestEntityFramework.DataBase
{
    public class AppContext : DbContext
    {
        public DbSet<Accounts> Accounts { get; set; }

        public AppContext() => Database.EnsureCreated();
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = new NpgsqlConnectionStringBuilder()
            {
                Host = "localhost",
                Database = "test",
                Port = 5432,
                Username = "postgres",
                Password = "-",
                ConvertInfinityDateTime = true,
                IncludeErrorDetails = true
            };
            optionsBuilder.UseNpgsql(connectionString.ConnectionString)
                .LogTo(str => Debug.WriteLine(str), new[] { RelationalEventId.CommandExecuted })
                .EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountsConfig());
        }
    }
}