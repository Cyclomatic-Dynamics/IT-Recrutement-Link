using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using IT_Recrutement_Link.Domain.Entities;

namespace IT_Recrutement_Link.DataAccess.Configuration
{
    public class StudentConfiguration : EntityTypeConfiguration<Student>
    {
        public StudentConfiguration()
        {
            ToTable("Students");
            HasKey(s => s.Id);
            Property(s => s.Name).HasMaxLength(50).IsRequired();
            Property(s => s.LastName).HasMaxLength(50).IsRequired();
            Property(s => s.DateNaissance).IsRequired();

            Property(s => s.VideoUrl).HasMaxLength(100).IsRequired();
            Property(s => s.SlidesUrl).HasMaxLength(100).IsRequired();
            Property(s => s.ProfilePictureUrl).HasMaxLength(100).IsRequired();
            Property(s => s.CompetenceSectorName).IsRequired();
           

        }
    }
}
