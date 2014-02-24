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
using IT_Recrutement_Link.Service;
namespace IT_Recrutement_Link.DataAccess
{
    public class Context : DbContext, IUnitOfWork
    {
        private static string connectionString = "Server=tcp:m5v781rgwy.database.windows.net,1433;Database=main-db;User ID=it-rec-link-data@m5v781rgwy;Password=CyclomaticDynamics2;Trusted_Connection=False;Encrypt=True;Connection Timeout=30";
        //private static string connectionString = null;
        public DbSet<Student> Students { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public Context()
            : base(connectionString)
        {
            Database.SetInitializer<Context>(new ContextInitializer());      
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
            return  Set<T>().Find(id);
            
        }
        public IList<T> FindMany<T>(Expression<Func<T, bool>> where) where T : class
        {
            return Set<T>().Where<T>(where).ToList<T>();
        }
        public IList<T> FindAll<T>() where T : class
        {
            return Set<T>().ToList<T>();
        }
       
        
       
        private class ContextInitializer : CreateDatabaseIfNotExists<Context> { }
        
    }
}
