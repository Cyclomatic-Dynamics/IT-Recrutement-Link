using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_Recrutement_Link.Service
{
    class EntityNotFoundException<T> :Exception
    {
        public EntityNotFoundException(int id)
            : base("Entity of Type " + typeof(T).Name + " with id : " + id + "was not found")
        {
        }
    }
}
