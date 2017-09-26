using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThesisManagement_Core.Utility
{
    public enum CommonLoggerLevel
    {
        Info = 0,
        Error = 1,
        Debug = 2
    }

    [Serializable]
    public enum RequestStatus
    {
        Failed = 0,
        Successed = 1
    }

    [Serializable]
    public enum RequestMethod
    {
        GET = 0,
        POST = 1,
        PUT = 2,
        DELETE = 3
    }

    /// <summary>
    /// 是否首页列表位置
    /// </summary>
    public enum EnumHotType
    {
        No = 0,
        Yes = 1
    }
    /// <summary>
    /// 是否置顶
    /// </summary>
    public enum EnumTopType
    {
        No = 0,
        Yes = 1
    }
    /// <summary>
    /// 状态
    /// </summary>
    public enum EnumStatus
    {
        Normal = 0,
        Deleted = 1
    }
    /// <summary>
    /// 关联信息类型
    /// </summary>
    public enum EnumRelatedType
    {
        News = 0,
        TopNews = 1,
        Question = 2,
        Survey = 3,
        LuckyDraw = 4
    }
    /// <summary>
    /// 调查活动类型
    /// </summary>
    public enum EnumSurveyType
    {
        Question = 0,
        Survey = 1
    }
}
