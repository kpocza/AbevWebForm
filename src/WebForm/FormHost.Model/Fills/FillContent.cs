using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FormHost.Model.Base;

namespace FormHost.Model.Fillings
{
    public class FillContent : IDomainEntity
    {
        public int Id { get; set; }

        public byte[] EnyK { get; set; }
    }

    public class FillContents : DomainEntityContainer<FillContent>
    {
    }
}
