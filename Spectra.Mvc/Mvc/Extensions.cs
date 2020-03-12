using Spectra.Builders;
using Spectra.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Spectra.Mvc
{
    public static class Extensions
    {
        public static GridBuilder<T> CreateGrid<T>(this HtmlHelper helper)
        {
            Grid<T> grid = new Grid<T>(helper);
            return new GridBuilder<T>(grid);
        }
    }
}
