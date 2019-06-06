using Microsoft.EntityFrameworkCore;
using RecruitmentTask.Core;
using RecruitmentTask.Data;
using System;

namespace RecruitmentTask.Tests
{
    public class DatabaseFixture : IDisposable
    {
        public DbContextOptions<AppDbContext> options { get; set; }
        public AppDbContext Context { get; set; }
        public DatabaseFixture()
        {
            options = new DbContextOptionsBuilder<AppDbContext>()
                .EnableSensitiveDataLogging()
                .UseInMemoryDatabase(databaseName: "test database")
                .Options;

            // Insert seed data into the database using one instance of the context
            using (var context = new AppDbContext(options))
            {
                context.Products.Add(new Product
                {
                    Id = 1,
                    Name = "name1",
                    Description = "description1",
                    Category = Category.Toy,
                    Price = 10M

                });
                context.Products.Add(new Product
                {
                    Id = 2,
                    Name = "name2",
                    Description = "description2",
                    Category = Category.Sport,
                    Price = 20M

                });
                context.Products.Add(new Product
                {
                    Id = 3,
                    Name = "name3",
                    Description = "description3",
                    Category = Category.Toy,
                    Price = 30M

                });
                context.SaveChanges();
            }

            Context = new AppDbContext(options);
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
