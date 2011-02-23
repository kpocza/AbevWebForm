using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FormHost.Model.Base
{
    public abstract class DomainEntityContainer<T> : List<T>
        where T: IDomainEntity
    {
    }
}
