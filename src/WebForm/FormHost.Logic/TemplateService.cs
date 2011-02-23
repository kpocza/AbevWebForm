using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FormHost.Model.Interfaces;
using FormHost.Model.Forms;
using FormHost.DataAccess;

namespace FormHost.Logic
{
    internal class TemplateServiceImpl : FormHostService, ITemplateService
    {
        public TemplateServiceImpl(DataContext dc, IInfoProvider ip)
            : base(dc, ip)
        {
        }

        public Organizations ListOrganizations()
        {
            return DataContext.Organizations.ListAll(o => o.Active);
        }

        public DocTypeVersions ListLastDocVersionsOfOrganization(Organization org)
        {
            var now = Configuration.Now;

            return DataContext.DocTypeVersions.ListAll(d => d.DocumentType.Organization.Id == org.Id && d.DocumentType.Organization.Active &&
                d.DocumentType.ValidFrom <= now && d.DocumentType.ValidTo >= now &&
                d.Active && d.IsLast, "DocumentType.Organization");
        }

        public WebDTVContent GetContent(int docTypeId)
        {
            var now = Configuration.Now;

            var dtv = DataContext.DocTypeVersions.Get(d => d.DocumentType.Id == docTypeId &&
                d.DocumentType.ValidFrom <= now && d.DocumentType.ValidTo >= now &&
                d.Active && d.IsLast, "DocumentType.Organization");

            return InfoProvider.GetFormDataBy(dtv);
        }
    }

    public class TemplateService : FormHostServiceFacade<ITemplateService>, ITemplateService
    {
        public TemplateService(IInfoProvider infoProvider)
            : base(infoProvider)
        {
            Impl = new TemplateServiceImpl(this.DataContext, this.InfoProvider);
        }

        public Organizations ListOrganizations()
        {
            return DoRet(impl => impl.ListOrganizations());
        }

        public DocTypeVersions ListLastDocVersionsOfOrganization(Organization org)
        {
            return DoRet(impl => impl.ListLastDocVersionsOfOrganization(org));
        }

        public WebDTVContent GetContent(int docTypeId)
        {
            return DoRet(impl => impl.GetContent(docTypeId));
        }
    }
}
