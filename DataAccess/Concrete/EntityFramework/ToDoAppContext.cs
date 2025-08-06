using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class ToDoAppContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

           optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=ToDoApp2;Trusted_Connection=True;");


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Assignment>()
                .HasOne(a => a.AssignmentList);

            modelBuilder.Entity<AssignmentList>().HasOne(a => a.User);

        }



        public DbSet<Assignment> Assignment { get; set; }
        public DbSet<AssignmentList> AssignmentList { get; set; }
        public DbSet<User> User { get; set; }
    }
}
