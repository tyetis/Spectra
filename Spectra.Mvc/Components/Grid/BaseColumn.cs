using Spectra.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Spectra.Components
{
    public abstract class BaseColumn<T>
    {
        public Expression<Func<T, object>> Expression { get; set; }
        public Func<T, object> Template { get; set; }
        public string Title { get; set; }
        public int Width { get; set; }
        public string Format { get; set; }
        public object HtmlAttributes { get; set; }
        public object HeaderHtmlAttributes { get; set; }

        public virtual string Render(T n)
        {
            if (Template != null)
                return Expression.Compile()(n).ToString();
            else return Template(n).ToString();
        }

        public virtual string FilterRender()
        {
            return "";
        }
        public Type GetMemberType()
        {
            Type info = Helper.GetPropertyInfo(Expression);
            return info;
        }
    }
}
