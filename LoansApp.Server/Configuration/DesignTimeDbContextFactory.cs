// ---------------------------------------
// Email: quickapp@ebenmonney.com
// Templates: www.ebenmonney.com/templates
// (c) 2024 www.ebenmonney.com/mit-license
// ---------------------------------------

using LoansApp.Server.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Reflection;

namespace LoansApp.Server.Configuration
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{env}.json", optional: true)
                .Build();

            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var migrationsAssembly = typeof(Program).GetTypeInfo().Assembly.GetName().Name;

            builder.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"], b => b.MigrationsAssembly(migrationsAssembly));;

            return new ApplicationDbContext(builder.Options);
        }
    }
}
