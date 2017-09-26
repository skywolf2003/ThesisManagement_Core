using System.Collections;
using System.Configuration;

namespace ThesisManagement_Core.Utility
{
    public class AppSetting
    {
        public static string CookieName
        {
            get { return ConfigurationManager.AppSettings["CookieName"]; }
        }
        public static string CurrentUserNameCookieName
        {
            get { return ConfigurationManager.AppSettings["CurrentUserNameCookieName"]; }
        }

        public static string CurrentUserIdCookieName
        {
            get { return ConfigurationManager.AppSettings["CurrentUserIdCookieName"]; }
        }
        public static string CurrentUserMenu
        {
            get { return ConfigurationManager.AppSettings["CurrentUserMenu"]; }
        }
        private static Hashtable hsConfigKevValue = new Hashtable();

        public static string GetConfigKeyValue(string key)
        {
            if (hsConfigKevValue.ContainsKey(key))
            {
                return hsConfigKevValue[key] == null ? string.Empty : hsConfigKevValue[key].ToString();
            }
            else
            {
                string value = ConfigurationManager.AppSettings[key];
                if (value != null)
                    hsConfigKevValue.Add(key, value);
                return value;
            }
        }

        public static string GetFileUploadTempPath
        {
            get { return ConfigurationManager.AppSettings["UploadFileTempPath"]; }
        }

        public static string GetFileUploadPath
        {
            get { return ConfigurationManager.AppSettings["UploadFilePath"]; }
        }

        public static string OpenAudit
        {
            get { return ConfigurationManager.AppSettings["OpenAudit"]; }
        }
    }
}
