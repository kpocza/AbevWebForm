using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FormHost.Model.Forms
{
    public class WebDTVContent
    {
        public DocTypeVersion DocTypeVersion { get; set; }

        public string HTML { get; set; }
        public string JavaScriptUrl { get; set; }
        public string CSSUrl { get; set; }
    }
}
