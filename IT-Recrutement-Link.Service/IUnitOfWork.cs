using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_Recrutement_Link.Service
{
    public interface IUnitOfWork<T> where T :class
    {
        void Add(T entity);
        void Commit();
        
    }
}
