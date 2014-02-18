using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_Recrutement_Link.DataAccess.Infrastructure
{
    public class DatabaseFactory : IDisposable,IDatabaseFactory
    {
        private Context dataContext = null;
        public Context Get()
        {
            return dataContext ?? (dataContext = new Context());
        }
        protected override void DisposeCore() 
        {
            if (dataContext != null) dataContext.Dispose();
        }
    }
}
