using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IT_Recrutement_Link.DataAccess;
using System.Data.Entity;
using System.Linq.Expressions;


namespace IT_Recrutement_Link.DataAccess.Infrastructure
{
   public  class UnitOfWork<T> where T :class
    {
       private Context context;
       IDatabaseFactory dbfact;
       public IDbSet<T> dbSet;

       

       public void UnitOfWork(Context context )
       {
           this.context = context;
           dbset = context.Set<T>();
       }
       public void Add(T entity)
       {
           
           DbSet.Add(entity);
           context;
           
       }
       public void Update(T entity)
       {

       }
       public void Remove(T entity)
       {

       }
       public void Find(string name)
       {

       }
       public void Commit()
       {
           context.Commit();
       }
    }
}
