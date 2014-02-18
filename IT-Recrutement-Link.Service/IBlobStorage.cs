using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace IT_Recrutement_Link.Service
{
    public interface IBlobStorage
    {
        string upLoad(FileStream stream);
    }
}
