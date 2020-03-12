using Spectra.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spectra.Factory
{
    public class ButtonControlFactory<T>
    {
        private Button<T> ButtonComponent { get; set; }

        public ButtonControlFactory(Button<T> buttonComponent)
        {
            ButtonComponent = buttonComponent;
        }

        public ButtonControlFactory<T> Click(string func)
        {
            ButtonComponent.Click = func;
            return this;
        }
        public ButtonControlFactory<T> Text(string text)
        {
            ButtonComponent.Text = text;
            return this;
        }

        public ButtonControlFactory<T> Class(string classes)
        {
            ButtonComponent.Class = classes;
            return this;
        }
    }
}
