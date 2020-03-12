using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spectra.Components
{
    public class BaseComponentBuilder<TBuilder> : IHtmlString where TBuilder : class
    {
        private BaseComponent Component { get; set; }

        public BaseComponentBuilder(BaseComponent component)
        {
            Component = component;
        }

        public TBuilder Id(string id)
        {
            this.Component.Id = id;
            return this as TBuilder;
        }
        public TBuilder Name(string name)
        {
            this.Component.Name = name;
            return this as TBuilder;
        }

        public string ToHtmlString()
        {
            return Component.Render();
        }
    }
}
