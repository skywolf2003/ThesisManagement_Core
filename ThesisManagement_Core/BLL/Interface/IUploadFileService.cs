namespace ThesisManagement_Core.BLL.Interface
{
    public interface IUploadFileService
    {
        bool UploadFile(/*HttpPostedFileBase postedFile,*/ string uploadPath, out string filename);

        bool DelFileByDetailId(int detialId);
    }
}
