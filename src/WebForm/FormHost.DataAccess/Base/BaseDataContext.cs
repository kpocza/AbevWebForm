using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using System.Runtime.CompilerServices;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace FormHost.DataAccess.Base
{
    public abstract class BaseDataContext
    {
        public DbContext DB { get; protected internal set; }
        public System.Data.Objects.ObjectContext OC { get { return ((IObjectContextAdapter)DB).ObjectContext; } }
        protected DbTransaction _tran;

        protected void SetOC(DbContext db)
        {
            DB = db;
        }

        public void BeginTransaction()
        {
            if (this.OC.Connection.State == System.Data.ConnectionState.Broken)
            {
                this.OC.Connection.Close();
            }

            if (this.OC.Connection.State != System.Data.ConnectionState.Open)
            {
                this.OC.Connection.Open();
            }
            _tran = this.OC.Connection.BeginTransaction();
        }

        public void CommitTransaction()
        {
            try
            {
                _tran.Commit();
            }
            finally
            {
                _tran = null;
                this.DB.Database.Connection.Close();
            }
        }

        public void RollbackTransaction()
        {
            try
            {
                _tran.Rollback();
            }
            finally
            {
                _tran = null;
                this.DB.Database.Connection.Close();
            }
        }

        public void Save()
        {
            DB.SaveChanges();
        }
    }
}
