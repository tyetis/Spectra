using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Spectra.Components
{
    public class Button<T> : BaseControl<T>
    {
        public string Click { get; set; }
        public string Text { get; set; }
        public string @Class { get; set; }

        public Button(HtmlHelper htmlHelper):base(htmlHelper)
        {

        }
        public override string Render()
        {
            return $"<button type=\"button\" class=\"{ @Class }\" onclick=\"{ Click }\">{ Text }</button>";
        }
    }
}
