using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_Recrutement_Link.Domain.Domain
{
    public static class ServiceFactory
    {
        public static Hasher GetHasher()
        {
            return new SHA1Hasher();
        } 
    }
}
