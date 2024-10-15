﻿using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAcesss.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(x => x.CategoryName).HasMaxLength(30);
            builder.HasIndex(x => x.CategoryName).IsUnique();
            builder.HasMany(pc => pc.ProductCategories)
                     .WithOne(p => p.Category)
                     .HasForeignKey(p => p.CategoryId)
                     .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
