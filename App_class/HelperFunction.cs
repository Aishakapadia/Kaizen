using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UFS_Application.App_class
{
    public class HelperFunction
    {
        public static string Dateformat(string date)
        {
            // return date != "" ? String.Format("{0:dd-MM-yyyy}", date) : "";
            return date != "" ? String.Format("{0:MM/dd/yyyy}", date) : "";
        }
        public static string Dateformat(DateTime date)
        {
            // return date != null ? String.Format("{0:dd-MM-yyyy}", date) : "";
            return date != null ? String.Format("{0:MM/dd/yyyy}", date) : "";
        }
    }
    public class SessionHelper
    {
        public UserSession getUserSession()
        {
            return ((UserSession)HttpContext.Current.Session[MisOp.SessionNames.S_User.ToString()]);

        }

    }
    public class UserSession
    {
        public int userid { get; set; }
        public string userName { get; set; }
        public string emailAddress { get; set; }
        public string AccountTye { get; set; }
        public string FirstName { get; set; }
        public int AccountTyeId { get; set; }
        public int AccountLevel { get; set; }
        public int RegionId { get; set; }
    }
}