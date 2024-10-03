using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using StationaryBrouchure.Server.Models;

namespace StationaryBrouchure.Server.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        
        // Seed data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CartItem>().ToTable("CartItems");

            // Add 19 products to the database
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Pen", Description = "A blue ink pen.", Price = 1.99, Color = "Blue", ImageUrl = "https://via.placeholder.com/150/0000FF/FFFFFF?text=Pen" },
                new Product { Id = 2, Name = "Notebook", Description = "A ruled notebook.", Price = 2.99, Color = "White", ImageUrl = "https://via.placeholder.com/150/FFFFFF/000000?text=Notebook" },
                new Product { Id = 3, Name = "Pencil", Description = "A wooden pencil.", Price = 0.99, Color = "Yellow", ImageUrl = "https://via.placeholder.com/150/FFFF00/000000?text=Pencil" },
                new Product { Id = 4, Name = "Eraser", Description = "A pink rubber eraser.", Price = 0.50, Color = "Pink", ImageUrl = "https://via.placeholder.com/150/FF69B4/FFFFFF?text=Eraser" },
                new Product { Id = 5, Name = "Highlighter", Description = "A fluorescent yellow highlighter.", Price = 1.49, Color = "Yellow", ImageUrl = "https://via.placeholder.com/150/FFFF00/000000?text=Highlighter" },
                new Product { Id = 6, Name = "Sticky Notes", Description = "Colorful sticky notes.", Price = 3.99, Color = "Assorted", ImageUrl = "https://via.placeholder.com/150/FF6347/FFFFFF?text=Sticky+Notes" },
                new Product { Id = 7, Name = "Binder Clips", Description = "Assorted binder clips.", Price = 2.50, Color = "Assorted", ImageUrl = "https://via.placeholder.com/150/808080/FFFFFF?text=Binder+Clips" },
                new Product { Id = 8, Name = "Tape Dispenser", Description = "A standard tape dispenser.", Price = 4.99, Color = "Black", ImageUrl = "https://via.placeholder.com/150/000000/FFFFFF?text=Tape+Dispenser" },
                new Product { Id = 9, Name = "Scissors", Description = "A pair of scissors.", Price = 3.49, Color = "Silver", ImageUrl = "https://via.placeholder.com/150/C0C0C0/000000?text=Scissors" },
                new Product { Id = 10, Name = "Ruler", Description = "A plastic ruler.", Price = 1.19, Color = "Transparent", ImageUrl = "https://via.placeholder.com/150/FFFFFF/000000?text=Ruler" },
                new Product { Id = 11, Name = "Marker", Description = "A black permanent marker.", Price = 1.29, Color = "Black", ImageUrl = "https://via.placeholder.com/150/000000/FFFFFF?text=Marker" },
                new Product { Id = 12, Name = "Globe", Description = "A world globe for reference.", Price = 15.99, Color = "Multicolor", ImageUrl = "https://via.placeholder.com/150/FF4500/FFFFFF?text=Globe" },
                new Product { Id = 13, Name = "Clipboard", Description = "A standard clipboard.", Price = 2.75, Color = "Brown", ImageUrl = "https://via.placeholder.com/150/8B4513/FFFFFF?text=Clipboard" },
                new Product { Id = 14, Name = "Fountain Pen", Description = "A luxury fountain pen.", Price = 25.99, Color = "Black", ImageUrl = "https://via.placeholder.com/150/000000/FFFFFF?text=Fountain+Pen" },
                new Product { Id = 15, Name = "Sketch Pad", Description = "An A4 sketch pad.", Price = 5.99, Color = "White", ImageUrl = "https://via.placeholder.com/150/FFFFFF/000000?text=Sketch+Pad" },
                new Product { Id = 16, Name = "Calculator", Description = "A basic calculator.", Price = 10.00, Color = "Gray", ImageUrl = "https://via.placeholder.com/150/808080/FFFFFF?text=Calculator" },
                new Product { Id = 17, Name = "Art Set", Description = "An art set with various colors.", Price = 20.00, Color = "Multicolor", ImageUrl = "https://via.placeholder.com/150/FF69B4/FFFFFF?text=Art+Set" },
                new Product { Id = 18, Name = "Color Pencils", Description = "A set of colored pencils.", Price = 7.99, Color = "Assorted", ImageUrl = "https://via.placeholder.com/150/FF6347/FFFFFF?text=Color+Pencils" },
                new Product { Id = 19, Name = "Whiteboard", Description = "A small whiteboard.", Price = 12.50, Color = "White", ImageUrl = "https://via.placeholder.com/150/FFFFFF/000000?text=Whiteboard" },
                new Product { Id = 20, Name = "Color Pencils", Description = "A set of colored pencils.", Price = 7.99, Color = "Assorted", ImageUrl = "https://via.placeholder.com/150/FF6347/FFFFFF?text=Color+Pencils" },
                new Product { Id = 21, Name = "Whiteboard", Description = "A small whiteboard.", Price = 12.50, Color = "White", ImageUrl = "https://via.placeholder.com/150/FFFFFF/000000?text=Whiteboard" }
         );
        }
    }
}
