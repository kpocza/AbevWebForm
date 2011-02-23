using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FormHost.Model.Forms;

namespace FormHost.Web.Models
{
    public class FormModel
    {
        public bool NewForm { get; set; }
        public int FillToLoad { get; set; }
        public WebDTVContent Content { get; set; }
    }
}