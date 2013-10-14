using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Linq;

namespace RestApiDemo.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a user name.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter a password.")]
        public string Password { get; set; }
        
        [Required(ErrorMessage = "Please enter your full name.")]
        public string FullName { get; set; }

        public string Location { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }
    }

    public class UserDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        // This override method detects new or updated records, and sets
        // DateCreated and DateModified accordingly.
        public override int SaveChanges()
        {            
            var entityQuery =
                from e in ChangeTracker.Entries<User>()
                where 
                    e.State == EntityState.Added ||
                    e.State == EntityState.Modified
                select e;

            foreach (var e in entityQuery)
            {
                if (e.State == EntityState.Added) 
                {                        
                    e.Entity.DateCreated = DateTime.Now;
                }
                    
                if (e.State == EntityState.Added ||
                    e.State == EntityState.Modified) 
                {
                    e.Entity.DateModified = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }
    }
}
