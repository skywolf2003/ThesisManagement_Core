using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ThesisManagement_Core.Models;
using ThesisManagement_Core.Utility;
using System.Collections;

namespace ThesisManagement_Core.Controllers
{
    public class HomeController : MvcController
    {
        public IActionResult Index()
        {
            ViewBag.Specialty = ThesisService.GetSpecialties();
            return View();
        }

        public IActionResult Save()
        {
            bool result = false;
            string msg = "";
            try
            {
                result = false;// ThesisService.save(Request.Params, out msg);
            }
            catch (Exception e)
            {
                log.WriteLog(e.Message, e, CommonLoggerLevel.Error);
            }
            return Json(new { result = result, msg = msg });
        }

        [HttpGet]
        public IActionResult Login()
        {
            ViewBag.returnUrl = Request.Query["returnUrl"];
            ContextService.SetCookie(String.Empty, String.Empty);
            return View();
        }

        [HttpPost]
        public IActionResult DoLogin()
        {
            int status = (int)RequestStatus.Failed;
            try
            {
                var username = Request.Form["username"];
                var password = Request.Form["password"];
                if (ThesisService.Login(username, password))
                {
                    status = (int)RequestStatus.Successed;
                }
            }
            catch (Exception ex)
            {
                log.WriteLog(ex.Message, ex);
            }

            return Json(new { status = status, returnUrl = Request.Form["returnUrl"] });
        }

        #region 用户登出
        [HttpGet]
        public IActionResult Logout()
        {
            int status = (int)RequestStatus.Failed;

            try
            {
                if (ThesisService.Logout())
                {
                    status = (int)RequestStatus.Successed;
                }
            }
            catch (Exception ex)
            {
                log.WriteLog(ex.Message, ex);
            }

            return Json(new { Status = status });
        }
        #endregion

        //[Security]
        public ActionResult Management()
        {
            ViewBag.totalPage = ThesisService.FindTotalPage();
            return View();
        }

        //[Security]
        public ActionResult DeleteThesisInfo()
        {
            bool ret = false;
            int id = int.Parse(Request.Form["id"]);
            ret = ThesisService.DeleteThesisInfo(id);
            return Json(new { result = ret });
        }

        //[Security]
        public ActionResult SpecialInfo()
        {
            ViewBag.Special = ThesisService.FindSpecialResult();
            return View();
        }

        //[Security]
        public ActionResult FindSpecialResult()
        {
            int totalPage = 1;
            int pageSize = int.Parse(Request.Form["pageSize"]);
            int currentPage = int.Parse(Request.Form["page"]);
            String name = Request.Form["name"];
            String ticketNum = Request.Form["ticketNum"];
            String phone = Request.Form["phone"];
            Hashtable ht = new Hashtable();
            ht.Add("name", name);
            ht.Add("ticketNum", ticketNum);
            ht.Add("phone", phone);
            List<ThesisInfoViewModel> thesisInfos = ThesisService.FindPageResult(pageSize, currentPage, ht, out totalPage);
            return Json(new { totalPage = totalPage, data = thesisInfos });
        }

        //[Security]
        public ActionResult EditSpecialInfo()
        {
            bool ret = false;
            int id = Request.Form.Keys.Contains("id") ? 0 : int.Parse(Request.Form["id"]);
            String name = Request.Form["name"];
            ret = ThesisService.EditSpecialInfo(id, name);
            return Json(new { result = ret });
        }

        //[Security]
        public ActionResult DeleteSpecialInfo()
        {
            bool ret = false;
            int id = Request.Form.Keys.Contains("id") ? 0 : int.Parse(Request.Form["id"]);
            ret = ThesisService.DeleteSpecialInfo(id);
            return Json(new { result = ret });
        }
    }
}
