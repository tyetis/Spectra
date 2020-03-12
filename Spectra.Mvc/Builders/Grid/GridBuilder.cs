using Spectra.Components;
using Spectra.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spectra.Builders
{
    public class GridBuilder<T> : BaseComponentBuilder<GridBuilder<T>>
    {
        private Grid<T> Grid { get; set; }

        public GridBuilder(Grid<T> grid) : base(grid)
        {
            Grid = grid;
        }

        public GridBuilder<T> Columns(Action<GridColumnFactory<T>> action)
        {
            action(new GridColumnFactory<T>(Grid));
            return this;
        }
        public GridBuilder<T> DataSource(IList<T> data)
        {
            Grid.Data = data;
            return this;
        }
        public GridBuilder<T> RowTemplate(Func<T, object> template)
        {
            Grid.RowTemplate = template;
            return this;
        }
        public GridBuilder<T> Pagination(Action<PaginationSettings> settings)
        {
            Grid.PaginationSettings.Enabled = true; 
            settings(Grid.PaginationSettings);
            return this;
        }
        public GridBuilder<T> Filterable()
        {
            Grid.IsFilterable = true;
            return this;
        }
        public GridBuilder<T> @Class(string @class)
        {
            Grid.Class = @class;
            return this;
        }
        public GridBuilder<T> Style(string style)
        {
            Grid.Style = style;
            return this;
        }
    }
}
