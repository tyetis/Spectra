using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Spectra.Components
{
    public abstract class BaseComponent
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string @Class { get; set; }
        public string Style { get; set; }

        protected HtmlHelper HtmlHelper { get; set; }

        public BaseComponent(HtmlHelper htmlHelper)
        {
            HtmlHelper = htmlHelper;
        }

        public abstract string Render();
    }
}
