using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using IT_Recrutement_Link.Domain.Entities;
using IT_Recrutement_Link.DataAccess.Configuration;

namespace IT_Recrutement_Link.DataAccess
{
    public class Context : DbContext
    {
        public Context():base(){}
        public DbSet<Student> Students { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public virtual void Commit() 
        {
            base.SaveChanges();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder) 
        {
            modelBuilder.Configurations.Add(new StudentConfiguration());
            modelBuilder.Configurations.Add(new CompanyConfiguration());
            modelBuilder.Configurations.Add(new JobConfiguration());
        }
    }
}
