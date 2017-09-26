using System.Collections.Generic;
using System.Web;

namespace ThesisManagement_Core.Utility
{
    public class ContextService
    {
        #region 设置Cookie
        public static void SetCookie(string name, string value)
        {
            //HttpCookie cookie = null;
            //if (HttpContext.Current.Request.Cookies[AppSetting.CookieName] == null)
            //{
            //    cookie = new HttpCookie(AppSetting.CookieName)
            //    {
            //        HttpOnly = true,
            //        Expires = System.DateTime.MinValue,
            //        Secure = System.Web.Security.FormsAuthentication.RequireSSL,
            //        Path = System.Web.Security.FormsAuthentication.FormsCookiePath
            //    };
            //    if (System.Web.Security.FormsAuthentication.CookieDomain != null)
            //    {
            //        cookie.Domain = System.Web.Security.FormsAuthentication.CookieDomain;
            //    }
            //}
            //else
            //{
            //    cookie = HttpContext.Current.Request.Cookies[AppSetting.CookieName];
            //}
            //if (cookie[name] != null)
            //{
            //    cookie.Values.Remove(name);
            //}
            //if (!string.IsNullOrWhiteSpace(name))
            //    cookie.Values.Add(name, value);
            //HttpContext.Current.Request.Cookies.Add(cookie);
            //HttpContext.Current.Response.Cookies.Add(cookie);
        }
        #endregion

        #region 获取Cookie
        public static string GetCookie(string name)
        {
            //var cookie = HttpContext.Current.Request.Cookies[AppSetting.CookieName];
            //return cookie == null ? "" : string.IsNullOrEmpty(cookie.Values[name]) ? "" : cookie.Values[name];
            return "";
        }
        #endregion

        #region 删除cookie
        public static void DeleteCookie(string name)
        {
            //var cookie = HttpContext.Current.Request.Cookies[AppSetting.CookieName];
            //if (cookie == null) return;
            //if (string.IsNullOrEmpty(name) || name == AppSetting.CookieName)
            //{
            //    cookie.Value = "";
            //    HttpContext.Current.Request.Cookies.Set(cookie);
            //    HttpContext.Current.Response.Cookies.Set(cookie);
            //}
            //else
            //{
            //    if (cookie.Values[name] != null)
            //    {
            //        cookie.Values.Remove(name);
            //    }
            //}
        }
        #endregion
    }
}
