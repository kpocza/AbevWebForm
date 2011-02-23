using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FormHost.Model.Interfaces
{
    public interface IFormHostService
    {
        IInfoProvider InfoProvider { get; }
    }
}
