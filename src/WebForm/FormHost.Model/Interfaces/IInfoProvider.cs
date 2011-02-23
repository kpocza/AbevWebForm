using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FormHost.Model.Forms;

namespace FormHost.Model.Interfaces
{
    public interface IInfoProvider
    {
        WebDTVContent GetFormDataBy(DocTypeVersion dtv);
    }
}
