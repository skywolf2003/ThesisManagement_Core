using System;
using System.Collections.Generic;

namespace ThesisManagement_Core.DAL.Model
{
    public partial class SystemUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserPwd { get; set; }
    }
}
