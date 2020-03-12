using Spectra.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spectra.Builders
{
    public class PaginationBuilder<T>: BaseComponentBuilder<PaginationBuilder<T>>
    {
        private Pagination Pagination { get; set; }

        public PaginationBuilder(Pagination pagination) : base(pagination)
        {
            Pagination = pagination;
        }
    }
}
