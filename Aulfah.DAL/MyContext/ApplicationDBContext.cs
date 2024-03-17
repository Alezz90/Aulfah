using Aulfah.Models;
using Microsoft.EntityFrameworkCore;
using Aulfah.DAL.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Text.RegularExpressions;

namespace Aulfah.DataContex
{
    public class ApplicationDBContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {


        }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Products)
                .WithMany(e => e.category);

            modelBuilder.Entity<ApplicationUser>()
          .HasMany(u => u.Products)
          .WithMany(p => p.Users)
          .UsingEntity(j => j.ToTable("UserProduct"));

            modelBuilder.Entity<ApplicationUser>()
         .HasMany(u => u.Services)
         .WithMany(p => p.Users)
         .UsingEntity(j => j.ToTable("UserServices"));

            //modelBuilder.Entity<Service>()
            //      .HasOne(s => s.User)
            //      .WithMany(a => a.Service)
            //      .HasForeignKey(s => s.ArtistId)
            //      .OnDelete(DeleteBehavior.Restrict);



        }
        public DbSet<Product> Product { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Tracking> Track { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Category> Category { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

    }
}



