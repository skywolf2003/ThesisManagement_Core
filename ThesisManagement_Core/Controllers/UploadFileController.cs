using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using ThesisManagement_Core.Utility;

namespace ThesisManagement_Core.Controllers
{
    public class UploadFileController : MvcController
    {
        public ActionResult UploadFile()
        {
            string filename = string.Empty;
            //HttpPostedFileBase uploadFile = Request.Files["uploadFile"] as HttpPostedFileBase;
            string path = AppSetting.GetFileUploadTempPath;
            bool result = UploadFileService.UploadFile(/*uploadFile,*/ path, out filename);
            return Json(new { result = result, filename = filename });
        }

        [HttpGet]
        public void DownLoad(string filename)
        {
            //string path = Server.MapPath(AppSetting.GetFileUploadPath) + filename;
            //FileInfo fi = new FileInfo(path);
            //if (fi.Exists)
            //{
            //    Response.Clear();
            //    Response.AddHeader("Content-Disposition", "attachment;filename=" + Server.UrlEncode(filename));
            //    Response.AddHeader("Content-Length", fi.Length.ToString());
            //    Response.ContentType = "application/octet-stream;charset=utf-8";
            //    Response.WriteFile(fi.FullName);
            //    Response.Flush();
            //    Response.Close();
            //}
        }

        /// <summary>
        /// 删除附件
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DelFile()
        {
            bool result = false;
            try
            {
                int detailId = int.Parse(Request.Form["detailId"]);
                if (detailId > 0)
                {
                    result = UploadFileService.DelFileByDetailId(detailId);
                }
            }
            catch (Exception ex)
            {
                result = false;
            }
            return Json(new { result = result });
        }
    }
}