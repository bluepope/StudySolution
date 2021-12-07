using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.DatabaseTest.EfCore
{
    public class SampleModel
    {
        public int Col1 { get; set; }
        public string? Col2 { get; set; }
    }

    public class SampleConfiguration : IEntityTypeConfiguration<SampleModel>
    {
        public void Configure(EntityTypeBuilder<SampleModel> entity)
        {
            entity.ToTable("tblSample");
            entity.HasKey(e => e.Col1);

            entity.Property(e => e.Col1);
            entity.Property(e => e.Col2);
        }
    }
}
