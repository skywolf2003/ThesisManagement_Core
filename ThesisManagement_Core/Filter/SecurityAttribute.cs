using Microsoft.AspNetCore.Mvc.Filters;
using System;
using ThesisManagement_Core.Utility;

namespace ThesisManagement_Core.Filter
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class SecurityAttribute : ActionFilterAttribute
    {
        protected readonly ContextService ContextService;

        protected SecurityAttribute(ContextService ContextService)
        {
            this.ContextService = ContextService;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var userName = ContextService.GetCookie(AppSetting.CurrentUserNameCookieName);
            if (string.IsNullOrWhiteSpace(userName))
            {
            //    filterContext.Result =
            //            new RedirectToRouteResult(
            //                new RouteValueDictionary(
            //                    new
            //                    {
            //                        Controller = "Home",
            //                        action = "login",
            //                        returnUrl =
            //                            filterContext.HttpContext.User.Request.Url == null
            //                                ? ""
            //                                : filterContext.HttpContext.Request.Url.AbsoluteUri
            //                    }));
            }
            base.OnActionExecuting(filterContext);
        }
    }
}
