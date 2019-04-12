using System;
using System.Collections.Generic;
using System.Text;
using LibraryManager.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManager.DAL.EntityConfigurations
{
    public class GenreConfiguration
    {
        public void Initialize(ModelBuilder builder, EntityTypeBuilder<Genre> cfg)
        {
            cfg.Property(x => x.Id).IsRequired();
            cfg.Property(x => x.GenreName).IsRequired().HasMaxLength(50);
            
        }
    }
}
