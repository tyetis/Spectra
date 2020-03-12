using Spectra.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Spectra.Components
{
    public abstract class BaseColumn<T>
    {
        public Expression<Func<T, object>> Expression { get; set; }
        public Func<T, object> Template { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public int Width { get; set; }
        public string Format { get; set; }
        public object HtmlAttributes { get; set; }
        public object HeaderHtmlAttributes { get; set; }
        public IEnumerable<SelectListItem> FilterSource { get; set; }

        public virtual string Render(T n)
        {
            if (Template != null)
                return Expression.Compile()(n).ToString();
            else return Template(n).ToString();
        }

        public virtual string FilterRender(HtmlHelper htmlHelper)
        {
            return "";
        }
        public Type GetMemberType()
        {
            Type info = Helper.GetPropertyType(Expression);
            return info;
        }
        public string GetMemberName()
        {
            return Helper.GetPropertyName(Expression);
        }

    }
}
