using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Spectra.Components
{
    public class Link<T> : BaseControl<T>
    {
        public string Url { get; set; }
        public string Text { get; set; }
        public Dictionary<string, Func<T, object>> Parameters = new Dictionary<string, Func<T, object>>();

        public Link(HtmlHelper htmlHelper):base(htmlHelper)
        {

        }
        public override string Render()
        {
            string u = "?" + string.Join("&", Parameters.Select(p => p.Key + "=" + p.Value(Data)));
            return $"<a href=\"{ Url + u }\">{ Text }</a>";
        }
    }
}
