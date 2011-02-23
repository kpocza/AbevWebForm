using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FormHost.Model.Forms;

namespace FormHost.Model.Interfaces
{
    /// <summary>
    /// Dokumentum sablon szolgáltatás
    /// </summary>
    public interface ITemplateService : IFormHostService
    {
        /// <summary>
        /// Célszervezetek listája
        /// </summary>
        /// <returns></returns>
        Organizations ListOrganizations();

        /// <summary>
        /// A szervezet összes dokumentumtípusából az utolsó, aktív verziót adja vissza
        /// </summary>
        /// <param name="org"></param>
        /// <returns></returns>
        DocTypeVersions ListLastDocVersionsOfOrganization(Organization org);

        /// <summary>
        /// A dokumentum verzió webes állományait adja vissza
        /// </summary>
        /// <param name="docTypeVersionId"></param>
        /// <returns></returns>
        WebDTVContent GetContent(int docTypeId);
    }
}
