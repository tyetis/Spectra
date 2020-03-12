using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;

namespace Spectra.Components
{
    public class Grid<T> : BaseComponent
    {
        public List<BaseColumn<T>> Columns { get; set; } = new List<BaseColumn<T>>();
        public Func<T, object> RowTemplate { get; set; }
        public PaginationSettings PaginationSettings { get; set; } = new PaginationSettings();
        public bool IsFilterable { get; set; }
        public string CellClass { get; set; }
        public IList<T> Data { get; set; }

        public Grid(HtmlHelper htmlHelper) : base(htmlHelper)
        {

        }
        public override string Render()
        {
            string html = $@"<table id=""{ Id }"" class=""{ Class }"" style=""{ Style }"">
                            <thead>
                              <tr>
                                { columnsrender() }
                              </tr>
                              { (IsFilterable ? rowfilter() : "") }
                             </thead>
                             <tbody>
                                { (RowTemplate != null ? rowtemplate(Data) : rowrender(Data)) }
                             <tbody>
                            </table>";
            if(PaginationSettings.Enabled)
            {
                html += new Pagination(HtmlHelper, PaginationSettings).Render();
            }
            return html;
        }

        private string rowrender(IList<T> data)
        {
            return string.Join("", data.Select(r =>
            {
                return string.Format("<tr>{0}</tr>", string.Join("", Columns.Select(c =>
                {
                    return renderCell(c.Render(r), c.HtmlAttributes);
                })));
            }));
        }
        private string rowtemplate(IList<T> data)
        {
            return string.Join("", data.Select(r =>
            {
                return RowTemplate(r);
            }));
        }
        private string columnsrender()
        {
            return string.Join("", Columns.Select(n => $"<th>{ n.Title }</th>"));
        }
        private string rowfilter()
        {
            return string.Format("<tr>{0}</tr>", string.Join("", Columns.Select(c =>
            {
                return string.Format("<td>{0}</td>", c.FilterRender(HtmlHelper));
            })));
        }
        private string renderCell(string row, object htmlAttributes)
        {
            IDictionary<string, object> _htmlAttributes = new RouteValueDictionary(htmlAttributes);
            var tagBuilder = new TagBuilder("td");
            tagBuilder.MergeAttributes(_htmlAttributes);
            tagBuilder.SetInnerText("{0}");
            return string.Format(tagBuilder.ToString(TagRenderMode.Normal), row);
        }
    }
}
