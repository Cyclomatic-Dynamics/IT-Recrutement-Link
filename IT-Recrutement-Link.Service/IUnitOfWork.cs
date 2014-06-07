using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;



namespace IT_Recrutement_Link.Service
{
    public interface IUnitOfWork
    {
        void Add<T>(T entity) where T : class;
        void Remove<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        T FindById<T>(int id) where T : class;
        IList<T> FindMany<T>(Expression<Func<T, bool>> where) where T : class;
        IList<T> FindAll<T>() where T : class;
        void Commit();
        
    }
}
