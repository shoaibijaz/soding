using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soding.Entities.Models
{
    /// <summary>Act as data context class for whole project.</summary>
    public class SodingContext : DataContext
    {
        public SodingContext()
            : base("AppConnectionString")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        /// <summary>Changes the data context rules.</summary>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<SodingContext>(null);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Project> Projects { get; set; }
      
    }
}
