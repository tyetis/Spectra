using Spectra.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spectra.Builders
{
    public abstract class BaseColumnBuilder<T, TResult> where TResult : class
    {
        protected BaseColumn<T> Column { get; set; }

        public BaseColumnBuilder(BaseColumn<T> column)
        {
            Column = column;
        }

        public TResult Title(string title)
        {
            Column.Title = title;
            return this as TResult;
        }
        public TResult HtmlAttributes(object attributes)
        {
            Column.HtmlAttributes = attributes;
            return this as TResult;
        }
        public TResult HeaderHtmlAttributes(object attributes)
        {
            Column.HeaderHtmlAttributes = attributes;
            return this as TResult;
        }
    }
}
