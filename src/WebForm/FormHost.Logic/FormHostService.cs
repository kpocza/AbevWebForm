using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FormHost.Model.Interfaces;
using FormHost.DataAccess;

namespace FormHost.Logic
{
    public class FormHostService : IFormHostService
    {
        protected FormHostService()
        {
        }

        public FormHostService(DataContext dc, IInfoProvider ip)
        {
            this.DataContext = dc;
            this.InfoProvider = ip;
        }

        public DataContext DataContext { get; set; }
        public IInfoProvider InfoProvider { get; protected set; }
    }

    public class FormHostServiceFacade<T> : FormHostService
        where T: IFormHostService
    {
        public FormHostServiceFacade(IInfoProvider ip)
        {
            this.DataContext = new DataContext();
            this.InfoProvider = ip;
        }
        public T Impl { get; set; }
        protected bool RunInTransaction { get; set; }

        protected TRet DoRet<TRet>(Func<T, TRet> action) where TRet : class
        {
            try
            {
                OnBeginOperationWithTran();
                var ret = action(Impl);
                OnSuccessfullOperation();
                return ret;
            }
            catch (Exception ex)
            {
                throw OnFailedOperation(ex);
            }
        }

        protected void DoAction(Action<T> action)
        {
            try
            {
                OnBeginOperationWithTran();
                action(Impl);
                OnSuccessfullOperation();
            }
            catch (Exception ex)
            {
                throw OnFailedOperation(ex);
            }
        }

        protected void OnBeginOperation()
        {
            OnBeginOperation(false);
        }

        protected void OnBeginOperationWithTran()
        {
            OnBeginOperation(true);
        }

        protected void OnBeginOperation(bool runInTransaction)
        {
            RunInTransaction = runInTransaction;
            if (runInTransaction)
            {
                DataContext.BeginTransaction();
            }
        }
        protected void OnSuccessfullOperation()
        {
            if (RunInTransaction)
            {
                DataContext.CommitTransaction();
            }
        }
        protected FoundationException OnFailedOperation(Exception ex)
        {
            if (RunInTransaction)
            {
                DataContext.RollbackTransaction();
            }
            if (ex is BaseException)
            {
                return new FoundationException(ex.Message, ex);
            }
            else
            {
                return new FoundationException("System error", ex);
            }
        }
        protected FoundationException OnFailedOperation()
        {
            if (RunInTransaction)
            {
                DataContext.RollbackTransaction();
            }
            return new FoundationException();
        }
    }
    public class BaseException : Exception
    {
        public BaseException()
        {
        }

        public BaseException(string msg)
            : base(msg)
        {
        }

        public BaseException(Exception innerException)
            : base(string.Empty, innerException)
        {
        }

        public BaseException(string msg, Exception innerException)
            : base(msg, innerException)
        {
        }
    }
    public class FoundationException : BaseException
    {
        public FoundationException()
        {
        }
        public FoundationException(string msg)
            : base(msg)
        {
        }

        public FoundationException(Exception innerException)
            : base(innerException)
        {
        }

        public FoundationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
