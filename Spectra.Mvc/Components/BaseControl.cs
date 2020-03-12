using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Spectra.Components
{
    public abstract class BaseControl<T> : BaseComponent
    {
        public T Data { get; set; }
        public BaseControl(HtmlHelper htmlHelper) : base(htmlHelper)
        {

        }
    }
}
