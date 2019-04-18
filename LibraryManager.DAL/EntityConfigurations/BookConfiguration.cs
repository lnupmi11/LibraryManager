using System;
using System.Collections.Generic;
using System.Text;
using LibraryManager.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManager.DAL.EntityConfigurations
{
    public class BookConfiguration
    {
        public  void Initialize(ModelBuilder builder, EntityTypeBuilder<Book> cfg)
        {
            cfg.Property(x => x.Id).IsRequired();
            cfg.Property(x => x.Author).IsRequired();
            cfg.Property(x => x.Title).HasMaxLength(100).IsRequired();
            cfg.Property(x => x.GenresCollection).IsRequired();
            cfg.Property(x => x.AvailableLanguagesCollection).IsRequired();
            cfg.Property(x => x.NumberOfPages).IsRequired();
        }
    }
}
