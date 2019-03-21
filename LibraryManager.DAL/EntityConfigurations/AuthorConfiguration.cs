using System;
using System.Collections.Generic;
using System.Text;
using LibraryManager.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManager.DAL.EntityConfigurations
{
    public class AuthorConfiguration 
    {
        public void Initialize(ModelBuilder builder, EntityTypeBuilder<Author> cfg)
        {
            cfg.Property(x => x.Id).IsRequired();
            cfg.Property(x => x.NumberOfWrittenBooks).IsRequired();
            cfg.Property(x => x.Firstname).HasMaxLength(100).IsRequired();
            cfg.Property(x => x.Lastname).HasMaxLength(100).IsRequired();

            Initialize(builder, cfg);
        }
    }
}
