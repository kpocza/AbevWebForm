using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Common;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;
using FormHost.Model.Common;
using FormHost.Model.Fillings;
using FormHost.Model.Forms;

namespace FormHost.DataAccess
{
    public class CNDDbContext : DbContext
    {
        public CNDDbContext(string connStr, DbCompiledModel model)
            : base(connStr, model)
        {
            Setup();
        }


        private void Setup()
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ValidateOnSaveEnabled = true;
            ((System.Data.Entity.Infrastructure.IObjectContextAdapter)this).ObjectContext.ContextOptions.ProxyCreationEnabled = false;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Fill> Fills { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<DocTypeVersion> DocTypeVersions { get; set; }
 }
}
