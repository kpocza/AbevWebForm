using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using FormHost.Model.Common;
using System.ComponentModel.DataAnnotations;

namespace FormHost.DataAccess.CodeFirst
{
    public class UserConfig : EntityTypeConfiguration<User>
    {
        public UserConfig()
        {
            HasKey(t => t.Id);
            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Name).HasMaxLength(80).IsRequired();

            this.ToTable("dbo.User");
        }
    }
}
