using Spectra.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Spectra.Builders
{
    public class BoundColumnBuilder<T> : BaseColumnBuilder<T, BoundColumnBuilder<T>>
    {
        public BoundColumnBuilder(BaseColumn<T> column) : base(column)
        {

        }

        public BoundColumnBuilder<T> Template(Func<T, object> templateAction)
        {
            this.Column.Template = templateAction;
            return this;
        }

        public BoundColumnBuilder<T> Format(string format)
        {
            Column.Format = format;
            return this;
        }

        public BoundColumnBuilder<T> Filterable(IEnumerable<SelectListItem> source)
        {
            Column.FilterSource = source;
            return this;
        }
    }
}
