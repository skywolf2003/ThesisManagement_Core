using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ThesisManagement_Core.BLL.Interface;

namespace ThesisManagement_Core.BLL.Impl
{
    public class UploadFileService : BLLBase, IUploadFileService
    {
        #region 上传文件
        public bool UploadFile(/*HttpPostedFileBase postedFile,*/ string uploadPath, out string filename)
        {
            bool result = false;
            filename = string.Empty;
        //    try
        //    {
        //        if (postedFile != null && postedFile.ContentLength > 0 && !string.IsNullOrWhiteSpace(uploadPath))
        //        {
        //            string uploadFullPath = AppDomain.CurrentDomain.BaseDirectory + uploadPath;
        //            if (!System.IO.Directory.Exists(uploadFullPath))
        //            {
        //                System.IO.Directory.CreateDirectory(uploadFullPath);
        //            }
        //            string extend = Path.GetExtension(postedFile.FileName.ToLower());
        //            filename = DateTime.Now.ToString("yyyyMMddHHssmm") + extend;
        //            postedFile.SaveAs(uploadFullPath + filename);
        //            result = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        log.WriteLog("UploadFile Service occer an exception as follow: ", ex);
        //        result = false;
        //    }
            return result;
        }
        #endregion

        #region 删除附件
        public bool DelFileByDetailId(int detialId)
        {
            bool result = false;
            try
            {
                //if (detialId > 0)
                //{
                //    t_details detail = DBScmsKPI.t_details.FirstOrDefault(f => f.id == detialId);
                //    detail.attachment = "";
                //    if (DBScmsKPI.SaveChanges() > 0)
                //        result = true;
                //}
            }
            catch (Exception ex)
            {
                log.WriteLog("Del File Service occer an exception as follow: ", ex);
                result = false;
            }
            return result;
        }
        #endregion
    }
}
