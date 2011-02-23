using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FormHost.Model.Interfaces;
using FormHost.Model.Forms;
using FormHost.DataAccess;
using FormHost.Model.Fillings;

namespace FormHost.Logic
{
    internal class FillServiceImpl : FormHostService, IFillService
    {
        public FillServiceImpl(DataContext dc, IInfoProvider ip)
            : base(dc, ip)
        {
        }

        public Fills ListFills()
        {
            return DataContext.Fills.ListAll(f => f.Active, "ActualVersion.DocumentType.Organization", "User");
        }

        public Fill GetFillContent(int id)
        {
            return DataContext.Fills.Get(id, "Content", "ActualVersion.DocumentType.Organization", "StartVersion", "User");
        }

        public Fill Save(Fill fill)
        {
            int fId = fill.Id;
            if (fill.Id == 0)
            {
                fill.User = DataContext.Users.Get(1);
                fill.StartVersion = DataContext.DocTypeVersions.Get(fill.StartVersion.Id);
                fill.ActualVersion = fill.StartVersion;
                fill.StartTime = Configuration.Now;
                fill.FinishTime = null;
                fill.SendInTime = null;
                fill.Active = true;
                fId = DataContext.Fills.AddWithSave(fill);
            }
            else
            {
                var f = GetFillContent(fill.Id);
                f.Content.EnyK = fill.Content.EnyK;
                DataContext.Save();
            }
            return GetFillContent(fId);
        }
    }

    public class FillService : FormHostServiceFacade<IFillService>, IFillService
    {
        public FillService(IInfoProvider infoProvider)
            : base(infoProvider)
        {
            Impl = new FillServiceImpl(this.DataContext, this.InfoProvider);
        }

        public Fills ListFills()
        {
            return DoRet(impl => impl.ListFills());
        }

        public Fill GetFillContent(int id)
        {
            return DoRet(impl => impl.GetFillContent(id));
        }

        public Fill Save(Fill fill)
        {
            return DoRet(impl => impl.Save(fill));
        }
    }
}
