using Microsoft.EntityFrameworkCore;
using PS.data.MyConfiguration;
using PS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PS.data
{
    public class PSContext:DbContext
    {

        public DbSet<Product> Products { get; set; } 

        public DbSet<Biological> Biologicals { get; set; }
        public DbSet<Chemical> Chemicals { get; set; }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Achat> Achats { get; set; }

        public DbSet<Client> Clients { get; set; }
       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
                                       Initial Catalog=ProductStoreDB2;
                                       Integrated Security=true;
                                       MultipleActiveResultSets=true");  //usemysql  //ProductStoreDB esm base //par
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
           // modelBuilder.ApplyConfiguration(new ChemicalConfiguration()); min cours


            //   modelBuilder.Entity<Category>().ToTable("myCategories").HasKey(c => c.CategoryId);
            //   modelBuilder.Entity<Category>().Property(c => c.Name).IsRequired().HasMaxLength(50);


            //configure inheritance table per type
            modelBuilder.Entity<Chemical>().ToTable("Chemical");
            modelBuilder.Entity<Biological>().ToTable("Biological");

            //config table porteuse de donnée 
            modelBuilder.Entity<Achat>().HasKey(c => new { c.ClientFK, c.ProductFK, c.DateAchat });


            //definir configuration par rapport tous les models
            var properties = modelBuilder.Model.GetEntityTypes().
                SelectMany(e => e.GetProperties()).Where(p => p.Name.StartsWith("Name") &&
                  p.ClrType == typeof(string));
            foreach(var p in properties)
            {
                p.SetColumnName("Myname");
            }

            //var stringproperties = modelBuilder.Model.GetEntityTypes().
            //   SelectMany(e => e.GetProperties()).Where(p =>  p.ClrType == typeof(string));
            //foreach (var p in stringproperties)
            //{
            //    p.IsNullable=false;
            //}



            base.OnModelCreating(modelBuilder);  
        }











          }
}
