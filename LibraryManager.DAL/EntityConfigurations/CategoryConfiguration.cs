using System;
using System.Collections.Generic;
using System.Text;
using LibraryManager.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManager.DAL.EntityConfigurations
{
    public class CategoryConfiguration
    {
        public void Initialize(ModelBuilder builder, EntityTypeBuilder<Category> cfg)
        {
            cfg.Property(x => x.Id).IsRequired();
            cfg.Property(x => x.CategoryName).IsRequired().HasMaxLength(50);

            Initialize(builder, cfg);
        }
    }
}
