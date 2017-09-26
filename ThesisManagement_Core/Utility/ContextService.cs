using CookieManager;
using Microsoft.AspNetCore.Http;
using System;
//using System.Security.Claims;
//using System.Security.Principal;

namespace ThesisManagement_Core.Utility
{
    public class ContextService
    {
        private readonly ICookieManager _cookieManager;
        private readonly ICookie _cookie;

        public ContextService(ICookieManager cookieManager, ICookie cookie/*, IHttpContextAccessor contextAccessor*/)
        {
            this._cookieManager = cookieManager;
            this._cookie = cookie;
        }

        #region 设置Cookie
        public void SetCookie(string name, string value)
        {
            string keystr = _cookie.Get(name);
            if (!string.IsNullOrWhiteSpace(name))
                _cookie.Set(name, value, new CookieOptions() { HttpOnly = true, Expires = DateTime.Now.AddDays(1) });
        }
        #endregion

        #region 获取Cookie
        public string GetCookie(string name)
        {
            return _cookie.Get(name);
            //var cookie = HttpContext.Current.Request.Cookies[AppSetting.CookieName];
            //return cookie == null ? "" : string.IsNullOrEmpty(cookie.Values[name]) ? "" : cookie.Values[name];
        }
        #endregion

        #region 删除cookie
        public void DeleteCookie(string name)
        {
            _cookie.Remove(name);
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
