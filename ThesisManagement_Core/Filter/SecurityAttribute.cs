using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using ThesisManagement_Core.Utility;

namespace ThesisManagement_Core.Filter
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class SecurityAttribute : ActionFilterAttribute
    {
        protected static CommonLogger log = new CommonLogger();

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var userName = ContextService.GetCookie(AppSetting.CurrentUserNameCookieName);
            if (string.IsNullOrWhiteSpace(userName))
            {
                filterContext.Result =
                        new RedirectToRouteResult(
                            new RouteValueDictionary(
                                new
                                {
                                    Controller = "Home",
                                    action = "login",
                                    returnUrl =
                                        filterContext.HttpContext.Request.Url == null
                                            ? ""
                                            : filterContext.HttpContext.Request.Url.AbsoluteUri
                                }));
            }
            base.OnActionExecuting(filterContext);
        }
    }
}
