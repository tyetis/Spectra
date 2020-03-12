using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spectra.Components
{
    public class ControlsColumn<T> : BaseColumn<T>
    {
        public List<BaseControl<T>> Controls { get; set; } = new List<BaseControl<T>>();

        public ControlsColumn()
        {

        }

        public override string Render(T n)
        {
            Controls.ForEach(d => d.Data = n);
            return string.Join("", Controls.Select(s => s.Render()));
        }
    }
}
