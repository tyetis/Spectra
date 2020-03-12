using Spectra.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spectra.Builders
{
    public class TemplateColumnBuilder<T> : BaseColumnBuilder<T, BoundColumnBuilder<T>>
    {
        public TemplateColumnBuilder(BaseColumn<T> column) : base(column)
        {

        }
    }
}
