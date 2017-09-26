using Microsoft.AspNetCore.Mvc;
using ThesisManagement_Core.BLL.Interface;
using ThesisManagement_Core.Utility;

namespace ThesisManagement_Core.Controllers
{
    public abstract class MvcController : Controller
    {
        protected static CommonLogger log = new CommonLogger();

        public string ErrorMessage { get; set; }
        protected readonly IThesisService ThesisService;
        protected readonly IUploadFileService UploadFileService;
        
        protected MvcController()
        {
            ErrorMessage = "内部错误请联系管理员！";
        }
        public MvcController(IThesisService thesisService, IUploadFileService uploadFileService)
        {
            this.ThesisService = thesisService;
            this.UploadFileService = uploadFileService;
        }

    }
}