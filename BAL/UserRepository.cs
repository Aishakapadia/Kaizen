using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UFS_Application.DAL;

namespace UFS_Application.BAL
{
    public class UserRepository
    {
        public UFSEntitiess context;
        bool result = false;
        public UserRepository()
        {
            context = new UFSEntitiess();
        }

        public bool CheckPassword(string username, string password)
        {
            var result = context.Users.Where(a => a.UserName.ToUpper() == username.ToUpper() && a.Password == password).FirstOrDefault();
            return result != null ? true : false; ;
        }
        public User GetUserByUserNameAndPassword(string username, string password)
        {
            return context.Users.Include("AccountType").Include("Region").Where(a => a.UserName == username).FirstOrDefault();
        }
        public User GetUserByUserId(int userid)
        {
            return context.Users.Include("AccountType").Include("Region").Where(a => a.UserId == userid).FirstOrDefault();
        }

        public List<User> GetAllUsers()
        {
            return context.Users.Include("AccountType").Include("Region").ToList();
        }
        public bool UserNameAlreadyExists(string username)
        {
            var userExists= context.Users.Where(a => a.UserName.ToUpper() == username.ToUpper()).FirstOrDefault();
            return userExists != null ? true : false;
        }

        public bool AddUser(User user, ref string returnMessage)
        {
            try
            {
                result = false;
                if (UserNameAlreadyExists(user.UserName))
                { returnMessage = "User name already exists.";  return false; }
                
                using (context)
                {
                    context.Users.Add(user);
                    returnMessage = "User has been saved successfully.";
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                returnMessage = ex.Message;
                return false;
            }
        }


        public bool UpdateUser(User user, ref string returnMessage)
        {

            using (context)
            {
                var userObj = context.Users.Where(a => a.UserId == user.UserId).FirstOrDefault();
                if (userObj != null)
                {
                    userObj.EmailAddress = user.EmailAddress;
                    userObj.AccountTypeId = user.AccountTypeId;
                    userObj.FirstName = user.FirstName;
                    userObj.LastName = user.LastName;
                    userObj.RegionId = user.RegionId;
                    userObj.IsActive = user.IsActive;
                }
                context.SaveChanges();
                returnMessage = "User has been updated";
                return true;
            }


        }

        public bool UpdatePassword(User user, ref string returnMessage)
        {

            using (context)
            {
                var userObj = context.Users.Where(a => a.UserId == user.UserId).FirstOrDefault();
                if (userObj != null)
                {
                    userObj.EmailAddress = user.EmailAddress;
                    userObj.AccountTypeId = user.AccountTypeId;
                    userObj.FirstName = user.FirstName;
                    userObj.LastName = user.LastName;
                    userObj.RegionId = user.RegionId;
                    userObj.IsActive = user.IsActive;
                }
                context.SaveChanges();
                returnMessage = "User has been updated";
                return true;
            }


        }


    }
}