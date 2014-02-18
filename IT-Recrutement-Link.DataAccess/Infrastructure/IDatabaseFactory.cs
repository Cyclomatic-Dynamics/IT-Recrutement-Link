using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_Recrutement_Link.DataAccess.Infrastructure
{
    interface IDatabaseFactory :IDisposable
    {
        Context Get();
    }
}
