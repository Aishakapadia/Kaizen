//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Web;

//namespace VenporV2.AppCode
//{
//    public class Auth
//    {
//        private static Auth auth;
//        Database db;
//        public static Auth getInstance()
//        {
//            if (auth == null)
//            {
//                auth = new Auth();
//            }
//            return auth;
//        }
//        private Auth()
//        {
//            db = Database.getInstance();
//        }
//        public Boolean Login(String username, String password, ref string message)
//        {
//            //var Query = "SELECT * FROM vendor_information WHERE vendor = '" + username + "' AND password = '" + password + "'";
//            var Query = "SELECT * FROM vendor_information WHERE vendor = @vendor AND password = @password";
//            SqlCommand cmd = new SqlCommand();
//            cmd.Parameters.AddWithValue("@vendor", username);
//            cmd.Parameters.AddWithValue("@password", password);
//            var table = db.GetTable(Query, cmd, ref message);
//            if (message != "")
//            {
//                HttpContext.Current.Session["loggedin"] = "0";
//                return false;

//            }
//            else if (table.Rows.Count < 1)
//            {
//                HttpContext.Current.Session["loggedin"] = "0";
//                return false;
//            }
//            else
//            {
//                DataRow row = table.Rows[0];
//                //bool isAccountLock = false;// Convert.ToBoolean(row["IsAccountLock"]);
//                //isAccountLock = row["IsAccountLock"].ToString() != "" ? Convert.ToBoolean(row["IsAccountLock"]) : false;
//                //DateTime LastSuccessLogin = row["LastSuccessLogin"].ToString() != "" ? Convert.ToDateTime(row["LastSuccessLogin"]) : DateTime.Now.AddDays(-91);
//                //if (isAccountLock)
//                //{
//                //    message = "The account is locked. Please contact administrator for account unlock.";
//                //    return false;

//                //}
//                //else if (LastSuccessLogin <= DateTime.Now.AddDays(-90))
//                //{
//                //    updateAccountLock(row["vendor"].ToString(), false, ref message);
//                //    message = "The account is locked. Please contact administrator for account unlock.";
//                //    return false;
//                //}
//                //else if (Convert.ToString(row["Password"]) != Convert.ToString(row["UpdatePassword"])) 
//                //{
//                //    HttpContext.Current.Session["vendorId"] = row["vendor"].ToString();
//                //    HttpContext.Current.Session["UpdatePassword"] = true;
//                //}
//                //else if (Convert.ToString(row["Password"]) == Convert.ToString(row["UpdatePassword"]) && Convert.ToDateTime(row["UpdatePasswordDate"]) <= DateTime.Now.AddDays(-90))
//                //{
//                //    HttpContext.Current.Session["vendorId"] = row["vendor"].ToString();
//                //    HttpContext.Current.Session["UpdatePassword"] = true;
//                //}
//                //else
//                //{
//                //    updateUserSuccesLoginDate(row["vendor"].ToString(), false, ref message);
//                //}

//                HttpContext.Current.Session["vendor"] = row["vendor"].ToString();
//                HttpContext.Current.Session["loggedin"] = "1";
//               //HttpContext.Current.Session["IsPasswordChange"] = Convert.ToBoolean(row["IsPasswordChangeRequired"].ToString());

//                return true;
//            }
//        }
//        public void updateUserSuccesLoginDate(string Id, bool isAdmin, ref string message)
//        {
//            string query = " Update vendor_information set LastSuccessLogin=@LastSuccessLogin where vendor=@vendorId";
//            SqlCommand command = new SqlCommand();
//            if (isAdmin)
//            {
//                query = " Update adminuser set LastSuccessLogin=@LastSuccessLogin   where username=@username";
//                command.Parameters.AddWithValue("@username", Id);
//            }
//            else
//            {
//                command.Parameters.AddWithValue("@vendorId", Id);
//            }
//            command.CommandText = query;
//            command.Parameters.AddWithValue("@LastSuccessLogin", DateTime.Now);

//            db.ExecuteNonQuery(command);

//        }

//        public void updateUserPassword(string Id, bool isAdmin,string Password, ref string message)
//        {
//            string query = " Update vendor_information set Password=@Password where vendor=@vendorId";
//            SqlCommand command = new SqlCommand();
//            if (isAdmin)
//            {
//                query = " Update adminuser set Password=@Password  where username=@username";
//                command.Parameters.AddWithValue("@username", Id);
//            }
//            else
//            {
//                command.Parameters.AddWithValue("@vendorId", Id);
//            }
//            command.CommandText = query;
//            command.Parameters.AddWithValue("@Password", Password);

//            db.ExecuteNonQuery(command);

//        }

//        public void updateUserPassword(string Id, string Password, ref string message)
//        {
//            string query = " Update vendor_information set Password=@Password, UpdatePassword =@Password, UpdatePasswordDate=GETDATE() where vendor=@vendorId";
//            SqlCommand command = new SqlCommand();
//                command.Parameters.AddWithValue("@vendorId", Id);

//            command.CommandText = query;
//            command.Parameters.AddWithValue("@Password", Password);

//            db.ExecuteNonQuery(command);

//        }

//        public void updateAccountLock(string Id, bool isAdmin, ref string message)
//        {
//            string query = " Update vendor_information set IsAccountLock=@IsAccountLock, AccountLockDate=@AccountLockDate  where vendor=@vendorId";
//            SqlCommand command = new SqlCommand();
//            if (isAdmin)
//            {
//                query = " Update adminuser set IsAccountLock=@IsAccountLock, AccountLockDate=@AccountLockDate  where username=@username";
//                command.Parameters.AddWithValue("@username", Id);
//            }
//            else
//            {
//                command.Parameters.AddWithValue("@vendorId", Id);
//            }
//            command.CommandText = query;
//            command.Parameters.AddWithValue("@IsAccountLock", true);
//            command.Parameters.AddWithValue("@AccountLockDate", DateTime.UtcNow);



//            db.ExecuteNonQuery(command);

//        }
//        public Boolean AdminLogin(String username, String password, ref string message)
//        {
//            //var Query = "SELECT * FROM adminuser WHERE username = '" + username + "' AND password = '" + password + "'";
//            var Query = "SELECT * FROM adminuser WHERE username = @username AND password = @password";
//            SqlCommand cmd = new SqlCommand();
//            cmd.Parameters.AddWithValue("@username", username);
//            cmd.Parameters.AddWithValue("@password", password);
//            var table = db.GetTable(Query, cmd, ref message);
//            //var table = db.GetTable(Query, ref message);
//            if (table == null)
//            {
//                HttpContext.Current.Session["loggedin"] = "0";
//                return false;

//            }
//            if (table.Rows.Count < 1)
//            {
//                HttpContext.Current.Session["loggedin"] = "0";
//                return false;
//            }
//            DataRow row = table.Rows[0];
//            bool isAccountLock = false;// Convert.ToBoolean(row["IsAccountLock"]);
//            isAccountLock = row["IsAccountLock"].ToString() != "" ? Convert.ToBoolean(row["IsAccountLock"]) : false;
//            DateTime LastSuccessLogin = row["LastSuccessLogin"].ToString() != "" ? Convert.ToDateTime(row["LastSuccessLogin"]) : DateTime.Now.AddDays(-91);
//            if (isAccountLock)
//            {
//                message = "The account is locked. Please contact administrator for account unlock.";
//                return false;

//            }
//            else if (LastSuccessLogin <= DateTime.Now.AddDays(-90))
//            {
//                updateAccountLock(row["username"].ToString(), true, ref message);
//                message = "The account is locked. Please contact administrator for account unlock.";
//                return false;
//            }
//            else
//            {
//                updateUserSuccesLoginDate(row["username"].ToString(), true, ref message);
//                HttpContext.Current.Session["admin"] = row["username"].ToString();
//                HttpContext.Current.Session["adminloggedin"] = "1";
//                HttpContext.Current.Session["IsPasswordChange"] = Convert.ToBoolean(row["IsPasswordChangeRequired"].ToString());
//                return true;
//            }
//        }
        
//        public DataTable GetUsers( ref string message)
//        {
//            //var Query = "SELECT * FROM adminuser WHERE username = '" + username + "' AND password = '" + password + "'";
//            var Query = "Select * from [dbo].[vendor_information]";
//            SqlCommand cmd = new SqlCommand();
//            return db.GetTable(Query, cmd, ref message);


//        }


//        public void Logout()
//        {
//            HttpContext.Current.Session.Abandon();
//            HttpContext.Current.Session["loggedin"] = "0";
//        }
//    }
//}