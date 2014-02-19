using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using IT_Recrutement_Link.Domain.Entities;

namespace IT_Recrutement_Link.DataAccess.Configuration
{
    public class JobConfiguration : EntityTypeConfiguration<Job>
    {
        public JobConfiguration()
        {
            ToTable("Jobs");
            //HasMany(s => s.WithRequired(c => c.Companies)).Map();
        }
    }
}
