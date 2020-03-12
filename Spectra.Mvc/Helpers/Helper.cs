using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Spectra.Helpers
{
    public static class Helper
    {
        public static int CalculateTotalPage(int pageSize, int dataCount)
        {
            decimal t = dataCount;
            decimal d = t / pageSize;
            return Convert.ToInt32(Math.Ceiling(d));
        }
        public static Dictionary<string, string> ToDictionary(this NameValueCollection nvc)
        {
            return nvc.AllKeys.ToDictionary(k => k, k => nvc[k]);
        }
        public static string UrlWithParameter(this HtmlHelper helper, string Name, string Value)
        {
            Dictionary<string, string> param = helper.ViewContext.HttpContext.Request.QueryString.ToDictionary();
            if (param.Any(n => n.Key == Name))
                param[Name] = Value;
            else
                param.Add(Name, Value);

            string generatedLink = "?" + string.Join("&", param.Select(n => n.Key + "=" + n.Value));
            return helper.ViewContext.HttpContext.Request.Path + generatedLink;
        }

        public static Type GetPropertyInfo<TSource>(Expression<Func<TSource, object>> propertyLambda)
        {
            MemberExpression body = propertyLambda.Body as MemberExpression;

            if (body == null)
            {
                UnaryExpression ubody = (UnaryExpression)propertyLambda.Body;
                body = ubody.Operand as MemberExpression;
            }

            return body.Type;
        }
    }
}
