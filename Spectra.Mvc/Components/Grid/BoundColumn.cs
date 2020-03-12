using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Spectra.Components
{
    public class BoundColumn<T> : BaseColumn<T>
    {
        public BoundColumn(Expression<Func<T, object>> expression)
        {
            base.Expression = expression;
            base.Name = GetMemberName();
        }
        public string Text { get; set; }

        public override string Render(T n)
        {
            object rendered = Template != null ? Template(n) : 
                              Expression.Compile()(n);
            if (Format != null)
                return string.Format((IFormatProvider)CultureInfo.CurrentCulture, Format, rendered);
            else
                return rendered?.ToString();
        }

        public override string FilterRender(HtmlHelper htmlHelper)
        {
            string SelectedValue = htmlHelper.ViewContext.HttpContext.Request.QueryString[Name];
            if(FilterSource != null)
            {
                SelectListItem item = FilterSource.FirstOrDefault(n => n.Value == SelectedValue);
                if(item != null) item.Selected = true;
                return htmlHelper.DropDownList(base.Name, FilterSource, "Seçiniz", new { @class = "form-control" }).ToString();
            }

            if (GetMemberType() == typeof(int))
                return htmlHelper.TextBox(Name, SelectedValue, new { type = "number", @class = "form-control" }).ToString();
            else if (GetMemberType() == typeof(string))
                return htmlHelper.TextBox(Name, SelectedValue, new { @class = "form-control" }).ToString();
            else if (GetMemberType() == typeof(DateTime))
                return htmlHelper.TextBox(Name, SelectedValue, new { @class = "form-control" }).ToString();
            else if (GetMemberType() == typeof(bool))
                return htmlHelper.CheckBox(Name, SelectedValue == "1").ToString();
            else return "";
        }
    }
}
