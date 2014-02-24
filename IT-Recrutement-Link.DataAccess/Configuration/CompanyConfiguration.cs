using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using IT_Recrutement_Link.Domain.Entities;


namespace IT_Recrutement_Link.DataAccess.Configuration
{
    public class CompanyConfiguration : EntityTypeConfiguration<Company>
    {
        public CompanyConfiguration()
        {
            ToTable("Companies");
            HasKey(c => c.Id);
            Property(c => c.Name).HasMaxLength(50).IsRequired();
            Property(c => c.Email).IsRequired();
            Property(c => c.PasswordHash).IsRequired();
            Property(c => c.VideoUrl).HasMaxLength(100).IsRequired();
            Property(c => c.SlidesUrl).HasMaxLength(100).IsRequired();
            Property(c => c.Address).HasMaxLength(100).IsRequired();
            Property(c => c.CreationDate).IsRequired();
            Property(c => c.AcceptSpontanousApplication).IsRequired();
            Property(c => c.ActivitySectorName).IsRequired();
            Property(c => c.Address).HasMaxLength(100).IsRequired();
            Property(c => c.CompanySize).IsRequired();
            
        }
    }
}
