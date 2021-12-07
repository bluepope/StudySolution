using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.DatabaseTest.EfCore
{
    public class PostModel
    {
        public int PostId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }

        public int BlogId { get; set; }
        public BlogModel? Blog { get; set; }
    }

    public class PostConfiguration : IEntityTypeConfiguration<PostModel>
    {
        public void Configure(EntityTypeBuilder<PostModel> entity)
        {
            entity.ToTable("Post");
            entity.HasKey(e => e.PostId);

            entity.Property(e => e.PostId).ValueGeneratedOnAdd();
            entity.Property(e => e.Title).HasMaxLength(2000).IsRequired();
            entity.Property(e => e.Content).HasColumnName("Content");
            
            entity.HasOne(e => e.Blog).WithMany(e => e.Posts)
                .HasPrincipalKey(e => e.BlogId)
                .HasForeignKey(e => e.PostId);
        }
    }

}
