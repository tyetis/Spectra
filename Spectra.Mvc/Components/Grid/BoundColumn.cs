using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Spectra.Components
{
    public class BoundColumn<T> : BaseColumn<T>
    {
        public BoundColumn(Expression<Func<T, object>> expression)
        {
            base.Expression = expression;
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

        public override string FilterRender()
        {
            if (GetMemberType() == typeof(int))
                return "<input type='number' class='form-control' onchange='alert(change)'/>";
            else if (GetMemberType() == typeof(string))
                return "<input type='text' class='form-control'/>";
            else if (GetMemberType() == typeof(DateTime))
                return "<input type='text' class='form-control' value='tarih'/>";
            else if (GetMemberType() == typeof(bool))
                return "<select><option>Seçiniz</option></select>";
            else return "";
        }
    }
}
