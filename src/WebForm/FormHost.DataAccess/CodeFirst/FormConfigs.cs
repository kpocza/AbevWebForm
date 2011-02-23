using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using FormHost.Model.Common;
using System.ComponentModel.DataAnnotations;
using FormHost.Model.Forms;

namespace FormHost.DataAccess.CodeFirst
{
    public class OrganizationConfig : EntityTypeConfiguration<Organization>
    {
        public OrganizationConfig()
        {
            HasKey(t => t.Id);
            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Name).HasMaxLength(20).IsRequired();
            Property(t => t.Description).HasMaxLength(100).IsRequired();
            Property(t => t.Active);

            this.ToTable("dbo.Organization");
        }
    }

    public class DocumentTypeConfig : EntityTypeConfiguration<DocumentType>
    {
        public DocumentTypeConfig()
        {
            HasKey(t => t.Id);
            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Name).HasMaxLength(20).IsRequired();
            Property(t => t.Description).HasMaxLength(100).IsRequired();
            Property(t => t.Active);

            HasRequired(t => t.Organization);

            this.ToTable("dbo.DocumentType");
        }
    }

    public class DocTypeVersionConfig : EntityTypeConfiguration<DocTypeVersion>
    {
        public DocTypeVersionConfig()
        {
            HasKey(t => t.Id);
            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.VersionString).HasMaxLength(10).IsRequired();
            Property(t => t.Major);
            Property(t => t.Minor);
            Property(t => t.IsLast);
            Property(t => t.Active);

            HasRequired(t => t.DocumentType);

            this.ToTable("dbo.DocTypeVersion");
        }
    }
}
