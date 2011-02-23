using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration;
using System.Data.SqlClient;
using System.Configuration;
using FormHost.DataAccess.Base;
using FormHost.DataAccess.CodeFirst;
using System.Data.Entity;

namespace FormHost.DataAccess
{
    public class DataContext : BaseDataContext
    {
        private static object _lockObj = new object();
        private static DbModel _m;

        static DataContext()
        {
            //System.Data.Entity.Database.SetInitializer<CNDDbContext>(null);
        }

        public DataContext()
        {
            string connString = ConfigurationManager.ConnectionStrings["FormHost"].ConnectionString;

            lock (_lockObj)
            {
                if (_m == null)
                {
                    var builder = new DbModelBuilder();

                    RegisterConfigurations(builder);
                    var conn = new SqlConnection(connString);

                    _m = builder.Build(conn);
                    conn.Close();
                }
                var db = new CNDDbContext(connString, _m.Compile());
                SetOC(db);
            }

            Users = new UserRepository(this);
            Fills = new FillRepository(this);
            Organizations = new OrganizationRepository(this);
            DocumentTypes = new DocumentTypeRepository(this);
            DocTypeVersions = new DocTypeVersionRepository(this);
        }

        public UserRepository Users { get; private set; }
        public FillRepository Fills { get; private set; }
        public OrganizationRepository Organizations { get; private set; }
        public DocumentTypeRepository DocumentTypes { get; private set; }
        public DocTypeVersionRepository DocTypeVersions { get; private set; }

        private void RegisterConfigurations(DbModelBuilder builder)
        {
            builder.Configurations.Add(new UserConfig());
            builder.Configurations.Add(new FillConfig());
            builder.Configurations.Add(new FillContentConfig());
            builder.Configurations.Add(new OrganizationConfig());
            builder.Configurations.Add(new DocumentTypeConfig());
            builder.Configurations.Add(new DocTypeVersionConfig());
        }

        public string BuildScript()
        {
            return ((System.Data.Entity.Infrastructure.IObjectContextAdapter)this.DB).ObjectContext.CreateDatabaseScript();
        }

    }
}
