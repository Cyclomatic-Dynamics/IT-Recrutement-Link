using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using IT_Recrutement_Link.Domain.Entities;
using IT_Recrutement_Link.DataAccess.Configuration;
using System.Linq.Expressions;
namespace IT_Recrutement_Link.DataAccess
{
    public class Context : DbContext
    {
        public Context(){
            Database.SetInitializer<Context>(new ContextInitializer());      
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Job> Jobs { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder) 
        {
            modelBuilder.Configurations.Add(new StudentConfiguration());
            modelBuilder.Configurations.Add(new CompanyConfiguration());
            modelBuilder.Configurations.Add(new JobConfiguration());
        }
        public void Commit()
        {
            SaveChanges();
        }
        public void Add<T>(T entity) where T : class
        {
            Set<T>().Add(entity);
        }
        public void Remove<T>(T entity) where T : class
        {
            Set<T>().Remove(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            Set<T>().Attach(entity);
            Entry<T>(entity).State = EntityState.Modified;
        }
        public T FindById<T>(int id) where T : class
        {
            return Set<T>().Find(id);
        }
        public IList<T> FindMany<T>(Expression<Func<T, bool>> where) where T : class
        {
            return Set<T>().Where<T>(where).ToList<T>();
        }
        public IList<T> FindAll<T>() where T : class
        {
            return Set<T>().ToList<T>();
        }
        
       
        internal class ContextInitializer : DropCreateDatabaseAlways<Context> { }
        
    }
}
