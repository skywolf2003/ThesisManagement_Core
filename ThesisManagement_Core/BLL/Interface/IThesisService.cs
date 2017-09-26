using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using ThesisManagement_Core.DAL.Model;
using ThesisManagement_Core.Models;

namespace ThesisManagement_Core.BLL.Interface
{
    public interface IThesisService
    {
        IList<Specialty> GetSpecialties();
        bool save(NameValueCollection nvPparams, out string msg);
        int FindTotalPage();
        List<ThesisInfoViewModel> FindPageResult(int pagesize, int currentpage, Hashtable ht, out int totalPage);
        bool DeleteThesisInfo(int id);
        List<Specialty> FindSpecialResult();
        bool EditSpecialInfo(int id, String name);
        bool DeleteSpecialInfo(int id);
        bool Login(string username, string password);
        bool Logout();
    }
}
