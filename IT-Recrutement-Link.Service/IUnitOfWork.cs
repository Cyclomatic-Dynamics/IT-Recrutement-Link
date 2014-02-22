using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_Recrutement_Link.Service
{
    public interface IUnitOfWork
    {
        void Add<T>(T entity) where T : class;
        void Remove<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        T FindById<T>(int id) where T : class;
        T FindOne<T>(string strId) where T : class;
        void Commit();
        
    }
}
