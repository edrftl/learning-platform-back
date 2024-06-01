using Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Data
{
    public class PlatformDBContext : IdentityDbContext<User>
    {
        public PlatformDBContext() { }
        public PlatformDBContext(DbContextOptions options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Groups> Groups { get; set; }
        public DbSet<User> Studants { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<Groups>()
           .HasOne(g => g.Course)
           .WithMany(c => c.Groups)
           .HasForeignKey(g => g.CourseId)
           .OnDelete(DeleteBehavior.Restrict);



            

            // Ensure Categories are seeded before Courses
            modelBuilder.Entity<Category>().HasData(
                new Category() { Id = 1, Name = "Fitness" },
                new Category() { Id = 2, Name = "Math" },
                new Category() { Id = 3, Name = "English" },
                new Category() { Id = 4, Name = "Crypto" },
                new Category() { Id = 5, Name = "Front-End" },
                new Category() { Id = 6, Name = "Music" },
                new Category() { Id = 7, Name = "Back-End" },
                new Category() { Id = 8, Name = "Art" }
            );
            //modelBuilder.Entity<Groups>().HasData(
            //    new Groups() { Id=1, Name="SPD221", MaxPlaces = 20, CourseId = 1 }

            //);

            //modelBuilder.Entity<Course>().HasData(
            //    new Course
            //    {
            //        Id = 1,
            //        Name = "Introduction to Fitness",
            //        Description = "Discover the basics of fitness and exercise.",
            //        Price = 29.99f,
            //        Discount = 10,
            //        CategoryId = 1,
            //    },
            //    new Course
            //    {
            //        Id = 2,
            //        Name = "Algebra Fundamentals",
            //        Description = "Learn essential algebra concepts and techniques.",
            //        Price = 39.99f,
            //        Discount = 15,
            //        CategoryId = 2,
            //    },
            //    new Course
            //    {
            //        Id = 3,
            //        Name = "English Composition",
            //        Description = "Improve your writing skills with this comprehensive English course.",
            //        Price = 19.99f,
            //        Discount = 5,
            //        CategoryId = 3,
            //    },
            //    new Course
            //    {
            //        Id = 4,
            //        Name = "Introduction to Cryptography",
            //        Description = "Explore the principles and techniques of cryptography.",
            //        Price = 49.99f,
            //        Discount = 20,
            //        CategoryId = 4,
            //    },
            //    new Course
            //    {
            //        Id = 5,
            //        Name = "Front-End Web Development",
            //        Description = "Learn front-end web development technologies such as HTML, CSS, and JavaScript.",
            //        Price = 59.99f,
            //        Discount = 25,
            //        CategoryId = 5,
            //    },
            //    new Course
            //    {
            //        Id = 6,
            //        Name = "Music Theory Basics",
            //        Description = "Master the fundamentals of music theory and notation.",
            //        Price = 34.99f,
            //        Discount = 10,
            //        CategoryId = 6,
            //    },
            //    new Course
            //    {
            //        Id = 7,
            //        Name = "Introduction to Art History",
            //        Description = "Explore the history of art from ancient to contemporary times.",
            //        Price = 24.99f,
            //        Discount = 8,
            //        CategoryId = 8,
            //    },
            //    new Course
            //    {
            //        Id = 8,
            //        Name = "Back-End Web Development",
            //        Description = "Learn back-end web development technologies and frameworks.",
            //        Price = 69.99f,
            //        Discount = 30,
            //        CategoryId = 7,
            //    },
            //    new Course
            //    {
            //        Id = 9,
            //        Name = "Mathematical Logic",
            //        Description = "Study the principles of mathematical logic and reasoning.",
            //        Price = 44.99f,
            //        Discount = 12,
            //        CategoryId = 2,
            //    },
            //    new Course
            //    {
            //        Id = 10,
            //        Name = "Advanced English Grammar",
            //        Description = "Deepen your understanding of English grammar with advanced topics.",
            //        Price = 29.99f,
            //        Discount = 7,
            //        CategoryId = 3,
            //    }
            //);
        }
    }
}
