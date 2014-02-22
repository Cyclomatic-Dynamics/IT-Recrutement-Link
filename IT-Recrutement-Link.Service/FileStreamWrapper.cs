using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace IT_Recrutement_Link.Service
{
    public class FileStreamWrapper
    {
        public FileStream FileStream { 
            get; 
            private set; 
        }
        public FileStreamWrapper(FileStream fileStream)
        {
            this.FileStream = fileStream;
        }

    }
}
