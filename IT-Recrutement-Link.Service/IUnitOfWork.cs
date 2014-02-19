﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_Recrutement_Link.Service
{
    public interface IUnitOfWork
    {
        void Add<T>(T entity) where T : class;
        void Commit();
        
    }
}
