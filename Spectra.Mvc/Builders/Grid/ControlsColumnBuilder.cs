using Spectra.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spectra.Builders
{
    public class ControlsColumnBuilder<T> : BaseColumnBuilder<T, ControlsColumnBuilder<T>>
    {
        public ControlsColumnBuilder(BaseColumn<T> column) : base(column)
        {

        }
    }
}
