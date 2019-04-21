using System;
using System.Collections.Generic;
using System.Text;
using LibraryManager.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManager.DAL.EntityConfigurations
{
    public class LanguageConfiguration
    {
        public void Initialize(ModelBuilder builder, EntityTypeBuilder<Language> cfg)
        {
            cfg.HasKey(x => x.Id);
            cfg.Property(x => x.LanguageName).IsRequired().HasMaxLength(50);

        }
    }
}
