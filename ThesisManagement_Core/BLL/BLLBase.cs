using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThesisManagement_Core.DAL.Model;
using ThesisManagement_Core.Utility;

namespace ThesisManagement_Core.BLL
{
    public class BLLBase
    {
        protected static CommonLogger log = new CommonLogger();
        internal ThesisContext DBThesis = null;
        public BLLBase()
        {
            DBThesis = new ThesisContext();
        }
    }
}
