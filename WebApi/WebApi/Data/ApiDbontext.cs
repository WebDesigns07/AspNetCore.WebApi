using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Data
{
    /// <summary>
    /// Database access service
    /// </summary>
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> ops) : base(ops)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Change datatable base settings

            // Seed
            // TODO: 操作无效
            //string[] Summaries = new[]
            //{
            //        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            //};
            //var rng = new Random();
            //var weathers = Enumerable.Range(1, 5).Select(index => new Weather
            //{
            //    Id = index,
            //    Date = DateTime.Now.AddDays(index),
            //    TemperatureC = rng.Next(-20, 55),
            //    Summary = Summaries[rng.Next(Summaries.Length)]
            //}).ToArray();
            //modelBuilder.Entity<Weather>().HasData(weathers);
        }

        public DbSet<Weather> Weather { get; set; }
    }
}
