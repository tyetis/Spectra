using Spectra.Builders;
using Spectra.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spectra.Factory
{
    public class ControlsColumnFactory<T>
    {
        private ControlsColumn<T> Column { get; set; }

        public ControlsColumnFactory(ControlsColumn<T> column)
        {
            Column = column;
        }

        public void Link(Action<LinkControlFactory<T>> action)
        {
            Link<T> linkComponent = new Link<T>(null);
            action(new LinkControlFactory<T>(linkComponent));
            Column.Controls.Add(linkComponent);
        }
        public void Button(Action<ButtonControlFactory<T>> action)
        {
            Button<T> btnComponent = new Button<T>(null);
            action(new ButtonControlFactory<T>(btnComponent));
            Column.Controls.Add(btnComponent);
        }
    }
}
