using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Core.Entities
{
    public class StudyPersonEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public DateTime? BirthDate { get; set; }
    }

    public class StudyPersonEntityConfiguration : IEntityTypeConfiguration<StudyPersonEntity>
    {
        public void Configure(EntityTypeBuilder<StudyPersonEntity> entity)
        {
            entity.ToTable("StudyPerson");
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Name);
            entity.Property(e => e.Address);
            entity.Property(e => e.BirthDate);
        }
    }
}
