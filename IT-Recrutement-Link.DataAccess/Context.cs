using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using IT_Recrutement_Link.Domain.Domain;

using System.Linq.Expressions;
using IT_Recrutement_Link.Service;
namespace IT_Recrutement_Link.DataAccess
{
    public class Context : DbContext, IUnitOfWork
    {
        private static string connectionString = "Server=tcp:m5v781rgwy.database.windows.net,1433;Database=main-db;User ID=it-rec-link-data@m5v781rgwy;Password=CyclomaticDynamics2;Trusted_Connection=False;Encrypt=True;Connection Timeout=30";
        private static string connectionStringTest = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=C:\\Users\\Chedy\\Desktop\\base.mdf;Integrated Security=True;Connect Timeout=30";
        //private static string connectionString = null;
        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }

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



        private class ContextInitializer : DropCreateDatabaseAlways<Context>
        {
            protected override void Seed(Context context)
            {
                base.Seed(context);
                context.Add<Student>(new Student
                {
                    Id = 1,
                    BirthDate = new DateTime(2000, 10, 10),
                    Email = "paul.london@student.com"
                    ,
                    Name = "Paul",
                    LastName = "London",
                    Diplomas = "Master",
                    Experiences = "1 year"
                });
                context.Add<Student>(new Student
                {
                    Id = 2,
                    BirthDate = new DateTime(2000, 10, 10),
                    Email = "cmpunk@student.com"
                    ,
                    Name = "Philip",
                    LastName = "Brooks",
                    Diplomas = "PhD",
                    Experiences = "2 year"
                });
                context.Add<Student>(new Student
                {
                    Id = 3,
                    BirthDate = new DateTime(2000, 10, 10),
                    Email = "undertaker@student.com"
                    ,
                    Name = "Mark",
                    LastName = "Callaway",
                    Diplomas = "Turing Award",
                    Experiences = "3 year"
                });
                context.Commit();
            }
        }

    }
}
