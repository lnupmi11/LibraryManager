using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
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
            cfg.HasKey(x => x.Id);
            cfg.Property(x => x.Title).HasMaxLength(100).IsRequired();
            cfg.Property(x => x.NumberOfPages).IsRequired();
        }
    }
}
