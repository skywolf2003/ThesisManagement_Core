using CookieManager;
using Microsoft.AspNetCore.Mvc;
using ThesisManagement_Core.BLL.Interface;
using ThesisManagement_Core.Utility;

namespace ThesisManagement_Core.Controllers
{
    public abstract class MvcController : Controller
    {
        protected static CommonLogger log = new CommonLogger();

        protected string ErrorMessage { get; set; }
        protected readonly IThesisService ThesisService;
        protected readonly IUploadFileService UploadFileService;
        protected readonly ContextService ContextService;
        protected MvcController()
        {
            ErrorMessage = "内部错误请联系管理员！";
            //this.ThesisService = Locator.Resolve<IThesisService>();
            //this.UploadFileService = Locator.Resolve<IUploadFileService>();
        }
        //protected MvcController(IThesisService thesisService, IUploadFileService uploadFileService)
        //{
        //    ErrorMessage = "内部错误请联系管理员！";
        //    this.ThesisService = thesisService;
        //    this.UploadFileService = uploadFileService;
        //}

    }
}