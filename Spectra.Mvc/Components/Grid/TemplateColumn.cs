using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Spectra.Components
{
    public class TemplateColumn<T> : BaseColumn<T>
    {
        public TemplateColumn(Func<T, object> template)
        {
            this.Template = template;
        }
        public string Text { get; set; }

        public override string Render(T n)
        {
            return this.Template(n).ToString();
        }
    }
}