using DotNetWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetWebAPI.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
         : base(options) { }
  
        public DbSet<Person> Person { get; set; }
        public DbSet<Contacts> Contacts { get; set; }
        
    }
}






      // protected override void OnModelCreating(ModelBuilder modelBuilder){
        //     modelBuilder.Entity<Person>().HasKey(k => k.Id);
        //     modelBuilder.Entity<Contacts>().HasKey("Id");
        //     base.OnModelCreating(modelBuilder);
        // }