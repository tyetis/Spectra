using Spectra.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;

namespace Spectra.Factory
{
    public class LinkControlFactory<T>
    {
        private Link<T> LinkComponent { get; set; }

        public LinkControlFactory(Link<T> linkComponent)
        {
            LinkComponent = linkComponent;
        }

        public LinkControlFactory<T> Url(string url)
        {
            LinkComponent.Url = url;
            return this;
        }
        public LinkControlFactory<T> Text(string text)
        {
            LinkComponent.Text = text;
            return this;
        }
        public LinkControlFactory<T> AddParam(string key, Func<T, object> func)
        {
            LinkComponent.Parameters.Add(key, func);
            return this;
        }
    }
}
