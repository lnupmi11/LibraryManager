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
            cfg.HasKey(x => x.Id);
            cfg.Property(x => x.UserName).IsRequired().HasMaxLength(50);
            cfg.Property(x => x.PasswordHash).IsRequired().HasMaxLength(25);
            cfg.Property(x => x.FirstName).HasMaxLength(100).IsRequired();
            cfg.Property(x => x.LastName).HasMaxLength(100).IsRequired();
        }
    }
}
