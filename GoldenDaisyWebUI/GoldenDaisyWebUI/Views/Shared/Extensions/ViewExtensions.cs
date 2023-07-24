using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GoldenDaisyWebUI.Extensions
{
    public static class ViewExtensions
    {
        public static bool UserIsAuthenticated(this IHtmlHelper htmlHelper)
        {
            return htmlHelper.ViewContext.HttpContext.User.Identity.IsAuthenticated;
        }
    }
}
