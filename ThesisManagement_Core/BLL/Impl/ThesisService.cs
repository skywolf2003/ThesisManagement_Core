using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Web;
using ThesisManagement_Core.BLL.Interface;
using ThesisManagement_Core.DAL.Model;
using ThesisManagement_Core.Models;
using ThesisManagement_Core.Utility;

namespace ThesisManagement_Core.BLL.Impl
{
    public class ThesisService : BLLBase, IThesisService
    {
        private readonly ContextService ContextService;

        public ThesisService(ContextService ContextService)
        {
            this.ContextService = ContextService;
        }

        public IList<Specialty> GetSpecialties()
        {
            return DBThesis.Specialty.ToList();
        }

        public bool save(NameValueCollection nvParams, out string msg)
        {
            msg = "";
            bool result = false;
            try
            {
                String fileName = nvParams["fileName"];
                String fileName1 = nvParams["fileName1"];
                String UserName = nvParams["txtUserName"];
                int specId = int.Parse(nvParams["selSpec"]);
                Specialty specialty = DBThesis.Specialty.FirstOrDefault(f => f.Id == specId);
                String TicketNumber = nvParams["txtTicketNumber"];

                if (DBThesis.ThesisInfo.Count(c => c.TicketNumber.Equals(TicketNumber)) > 0)
                {
                    msg = "该准考证号已经上传完成论文，如果需要重新上传论文，请联系统管理员处理无效数据！";
                    result = false;
                }
                else
                {
                    //论文
                    String newThesisName = UserName + "_" + specialty.Name + "_" + TicketNumber + "_论文";
                    String newThesisFileName = newThesisName + Path.GetExtension(fileName);
                    String oldThesisFileName = fileName;
                    //查重报告

                    String newCheckReportName = UserName + "_" + specialty.Name + "_" + TicketNumber + "_查重报告";
                    String newCheckReportFileName = newCheckReportName + Path.GetExtension(fileName1);
                    String oldCheckReportFileName = fileName1;

                    ThesisInfo thesisInfo = new ThesisInfo()
                    {
                        UserName = UserName,
                        Specialty = specialty.Name,
                        TicketNumber = TicketNumber,
                        Phone = nvParams["txtPhone"],
                        CreateDate = DateTime.Now,
                        IsDelete = 0,
                        ThesisName = newThesisName,
                        ThesisFilelName = newThesisFileName,
                        CheckReportName = newCheckReportName,
                        CheckReportFileName = newCheckReportFileName,
                    };
                    DBThesis.ThesisInfo.Add(thesisInfo);

                    SaveFile(newCheckReportFileName, oldCheckReportFileName, AppSetting.GetFileUploadTempPath, AppSetting.GetFileUploadPath);
                    SaveFile(newThesisFileName, oldThesisFileName, AppSetting.GetFileUploadTempPath, AppSetting.GetFileUploadPath);
                    DBThesis.SaveChanges();
                    result = true;
                }

            }
            catch (Exception e)
            {
                log.WriteLog(e.Message, e, CommonLoggerLevel.Error);
            }
            return result;
        }

        public void SaveFile(string newFileName, string oldFileName, string sourcPath, string targetPath)
        {
            string oldPic = AppDomain.CurrentDomain.BaseDirectory + sourcPath + oldFileName;
            string newPic = AppDomain.CurrentDomain.BaseDirectory + targetPath + newFileName;

            if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + targetPath.Substring(1)))
            {
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + targetPath.Substring(1));
            }

            File.Copy(oldPic, newPic, true);
        }

        public int FindTotalPage()
        {
            return DBThesis.ThesisInfo.Count();
        }

        public List<ThesisInfoViewModel> FindPageResult(int pagesize, int currentpage, Hashtable ht, out int totalPage)
        {
            totalPage = 1;
            String name = ht["name"].ToString();
            String phone = ht["phone"].ToString();
            String ticketNum = ht["ticketNum"].ToString();
            List<ThesisInfoViewModel> thesisInfoViewModels = new List<ThesisInfoViewModel>();
            IList<ThesisInfo> thesisInfos = DBThesis.ThesisInfo.Where(w => w.UserName.Contains(name)
                && w.Phone.Contains(phone) && w.TicketNumber.Contains(ticketNum)).OrderByDescending(o => o.CreateDate).ToList();

            if (thesisInfos != null)
            {
                totalPage = Convert.ToInt32(Math.Ceiling(thesisInfos.Count / (double)pagesize));
                thesisInfos = thesisInfos.Skip((currentpage - 1) * pagesize).Take(pagesize).ToList();
                foreach (ThesisInfo item in thesisInfos)
                {
                    ThesisInfoViewModel viewModel = new ThesisInfoViewModel()
                    {
                        Id = item.Id,
                        UserName = item.UserName,
                        Specialty = item.Specialty,
                        Phone = item.Phone,
                        TicketNumber = item.TicketNumber,
                        ThesisName = item.ThesisName,
                        CheckReportName = item.CheckReportName,
                        CreateDateSplite = item.CreateDate.ToString("yyyy-MM-dd") + "<br/>" + item.CreateDate.ToString("HH:mm:ss")
                    };
                    thesisInfoViewModels.Add(viewModel);
                }
            }
            return thesisInfoViewModels;
        }

        public bool DeleteThesisInfo(int id)
        {
            bool ret = false;
            ThesisInfo thesisInfo = DBThesis.ThesisInfo.FirstOrDefault(f => f.Id == id);
            if (thesisInfo != null)
            {
                String thesisFilelName = AppDomain.CurrentDomain.BaseDirectory + AppSetting.GetFileUploadPath + thesisInfo.ThesisFilelName;
                String checkReportFileName = AppDomain.CurrentDomain.BaseDirectory + AppSetting.GetFileUploadPath + thesisInfo.CheckReportFileName;
                if (File.Exists(thesisFilelName))
                {
                    File.Delete(thesisFilelName);
                }
                if (File.Exists(checkReportFileName))
                {
                    File.Delete(checkReportFileName);
                }
                DBThesis.ThesisInfo.Remove(thesisInfo);
                if (DBThesis.SaveChanges() > 0)
                {
                    ret = true;
                }
            }

            return ret;
        }

        public List<Specialty> FindSpecialResult()
        {
            return DBThesis.Specialty.ToList();
        }

        public bool EditSpecialInfo(int id, String name)
        {
            bool ret = false; ;
            Specialty specialty = null;
            if (id > 0)
            {
                specialty = DBThesis.Specialty.FirstOrDefault(f => f.Id == id);
                specialty.Name = name;
            }
            else
            {
                specialty = new Specialty();
                specialty.Name = name;
                DBThesis.Specialty.Add(specialty);
            }
            if (DBThesis.SaveChanges() > 0)
            {
                ret = true;
            }
            return ret;
        }

        public bool DeleteSpecialInfo(int id)
        {
            bool ret = false; ;
            Specialty specialty = DBThesis.Specialty.FirstOrDefault(f => f.Id == id);
            DBThesis.Specialty.Remove(specialty);
            if (DBThesis.SaveChanges() > 0)
            {
                ret = true;
            }
            return ret;
        }

        #region 登录
        public bool Login(string username, string password)
        {
            bool returnVal = false;

            try
            {
                SystemUser user = DBThesis.SystemUser.FirstOrDefault(f => f.UserName == username && f.UserPwd == password);
                if (user != null && user.Id > 0)
                {
                    ContextService.SetCookie(AppSetting.CurrentUserNameCookieName, HttpUtility.UrlEncode(user.UserName));
                    ContextService.SetCookie(AppSetting.CurrentUserIdCookieName, user.Id.ToString());
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
                log.WriteLog(ex.Message, ex, parameter: string.Format("登录失败【方法名:{0},账号:{1},密码:{2}】",
                    "ThesisService.Login(string email, string password)", username, password));
            }
            return returnVal;
        }
        #endregion

        #region 登出
        public bool Logout()
        {
            bool returnVal = false;
            try
            {
                ContextService.DeleteCookie("");
                returnVal = true;
            }
            catch (Exception ex)
            {
                log.WriteLog(ex.Message);
            }
            return returnVal;
        }
        #endregion
    }
}
