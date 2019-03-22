using System;
using System.Collections.Generic;
using System.Text;
using LibraryManager.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManager.DAL.EntityConfigurations
{
    public class UserConfiguration
    {
        public void Initialize(ModelBuilder builder, EntityTypeBuilder<User> cfg)
        {
            cfg.Property(x => x.Id).IsRequired();
            cfg.Property(x => x.Login).IsRequired().HasMaxLength(50);
            cfg.Property(x => x.Password).IsRequired().HasMaxLength(25);
            cfg.Property(x => x.FirstName).HasMaxLength(100).IsRequired();
            cfg.Property(x => x.LastName).HasMaxLength(100).IsRequired();

            Initialize(builder, cfg);
        }
    }
}
