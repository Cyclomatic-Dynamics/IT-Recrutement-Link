using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_Recrutement_Link.Domain.Domain
{
    public interface Hasher
    {
        string Hash(string word);
    }
}
