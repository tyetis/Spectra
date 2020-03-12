using Spectra.Builders;
using Spectra.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Spectra.Factory
{
    public class GridColumnFactory<T>
    {
        private Grid<T> Grid { get; set; }

        public GridColumnFactory(Grid<T> grid)
        {
            Grid = grid;
        }

        public BoundColumnBuilder<T> Bound(Expression<Func<T, object>> expression)
        {
            BoundColumn<T> col = new BoundColumn<T>(expression);
            Grid.Columns.Add(col);
            return new BoundColumnBuilder<T>(col);
        }
        public BoundColumnBuilder<T> Controls(Action<ControlsColumnFactory<T>> expression)
        {
            ControlsColumn<T> col = new ControlsColumn<T>();
            expression(new ControlsColumnFactory<T>(col));
            Grid.Columns.Add(col);
            return new BoundColumnBuilder<T>(col);
        }
        public TemplateColumnBuilder<T> Template(Func<T, object> expression)
        {
            TemplateColumn<T> col = new TemplateColumn<T>(expression);
            Grid.Columns.Add(col);
            return new TemplateColumnBuilder<T>(col);
        }

    }
}
