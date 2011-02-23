using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FormHost.Model.Common;
using FormHost.Model.Base;
using FormHost.Model.Forms;

namespace FormHost.Model.Fillings
{
    public class Fill : IDomainEntity
    {
        public int Id { get; set; }
        public User User { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? FinishTime { get; set; }
        public DateTime? SendInTime { get; set; }
        public DocTypeVersion StartVersion { get; set; }
        public DocTypeVersion ActualVersion { get; set; }
        public bool Active { get; set; }

        public FillContent Content { get; set; }
    }

    public class Fills : DomainEntityContainer<Fill>
    {
    }
}
