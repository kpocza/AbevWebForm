using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using FormHost.Model.Common;
using System.ComponentModel.DataAnnotations;
using FormHost.Model;
using FormHost.Model.Fillings;

namespace FormHost.DataAccess.CodeFirst
{
    public class FillConfig : EntityTypeConfiguration<Fill>
    {
        public FillConfig()
        {
            HasKey(t => t.Id);
            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.StartTime);
            Property(t => t.FinishTime);
            Property(t => t.SendInTime);
            Property(t => t.Active);

            HasRequired(t => t.User);
            HasRequired(t => t.StartVersion);
            HasRequired(t => t.ActualVersion);

            HasRequired(t => t.Content);

            this.ToTable("dbo.Fill");
        }
    }

    public class FillContentConfig : EntityTypeConfiguration<FillContent>
    {
        public FillContentConfig()
        {
            HasKey(t => t.Id);
            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.EnyK).IsRequired().HasColumnType("varbinary(max)");

            this.ToTable("dbo.FillContent");
        }
    }
}
