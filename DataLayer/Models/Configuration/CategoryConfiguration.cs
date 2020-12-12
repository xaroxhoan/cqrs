using DataLayer.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Models.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
          builder.HasOne(c=>c.Parent).WithMany(c => c.Parents).HasForeignKey(c=>c.ParentId)
           .OnDelete(DeleteBehavior.NoAction) ;
        }
    }
}



