using Spectra.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Spectra.Components
{
    public class Pagination : BaseComponent
    {
        public int pageSize { get; set; }
        public int TotalCount { get; set; }
        public int currentPage { get; set; }

        public Pagination(HtmlHelper htmlHelper, PaginationSettings Settings) : base(htmlHelper)
        {
            pageSize = Settings.PageSize;
            TotalCount = Settings.Total;
            currentPage = Settings.Current;
        }

        public override string Render()
        {
            int TotalPage = Helper.CalculateTotalPage(pageSize, TotalCount);

            string control = @"<div class=""pagingcontainer"">
                                <nav aria-label=""Page navigation"">
                                  <ul class=""pagination"">
                                      {0}
                                  </ul>
                                 </nav>
                               </div>";
            Func<bool, bool, string, string, string> PageLinkItem = (isActive, isdisabled, CurrentPage, Text) =>
            {
                return string.Format("<li class=\"page-item {0} {1}\"><a class=\"page-link\" href=\"{2}\" {4}>{3}</a></li>",
                               (isActive ? "active" : ""),
                               (isdisabled ? "disabled" : ""),
                               HtmlHelper.UrlWithParameter("CurrentPage", CurrentPage),
                               Text,
                               (isdisabled ? "onclick=\"return false\"" : ""));
            };

            string Items = "";
            int start = (currentPage - 3) >= 0 ? (currentPage - 3) : 0;
            int end = (currentPage + 3) < TotalPage ? (currentPage + 3 + 1) : TotalPage;
            Items += PageLinkItem(false, currentPage <= 0, "0", "<i class=\"fa fa-angle-double-left \"></i>");
            Items += PageLinkItem(false, currentPage <= 0, (currentPage - 1).ToString(), "<i class=\"fa fa-angle-left\"></i>");
            for (int i = start; i < end; i++)
                Items += PageLinkItem(currentPage == i, currentPage == i, i.ToString(), (i + 1).ToString());
            Items += PageLinkItem(false, currentPage >= (TotalPage - 1), (currentPage + 1).ToString(), "<i class=\"fa fa-angle-right\"></i>");
            Items += PageLinkItem(false, currentPage >= (TotalPage - 1), (TotalPage - 1).ToString(), "<i class=\"fa fa-angle-double-right\"></i>");

            Items += @"<li>
                        <select class=""form-control selPageSize"" name=""PageSize"">
                           <option " + (pageSize == 10 ? "selected" : "") + @">10</option>
                           <option " + (pageSize == 20 ? "selected" : "") + @">20</option>
                           <option " + (pageSize == 50 ? "selected" : "") + @">50</option>
                           <option " + (pageSize == 100 ? "selected" : "") + @">100</option>
                        </select>
                      </li>";
            Items += @"<li><div class=""labelTotalCount""><b>" + TotalCount + "</b> Toplam Kayıt</div></li>";

            control = string.Format(control, Items, TotalCount);
            return control;
        }
    }
}
