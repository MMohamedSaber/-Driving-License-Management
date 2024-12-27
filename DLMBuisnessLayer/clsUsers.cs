using DLMDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLBuisnesLayer
{
    public class clsUsers
    {

        public int UserID { get; set; } 
        public int PersonID { get; set; }
        public clsPerson PersonInfo;
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

        enum enMode { AddMode=1,UpdateMode=2}
        private enMode _Mode;
        public clsUsers()
        {
            UserID = -1;
            PersonID = -1;
            UserName = string.Empty;
            Password = string.Empty;
          IsActive=false;
            _Mode=enMode.AddMode;
    }

        public clsUsers(int userID,int personID,string userName,string password,bool isActive)
        {
            UserID=userID; 
            PersonID=personID; 
            PersonInfo=clsPerson.Find(PersonID);
            UserName=userName; 
            Password=password; 
            IsActive=isActive;
            _Mode = enMode.UpdateMode;
        }
        public static bool Find(string username, string password)
        { 
          return clsUsersDataAccess.IsUserExistByUserNameAndPassword(username, password);
        }

        public static clsUsers Find(string userName)
        {

            string  Password = "";
            int UserId = -1, personID=-1;
            bool isActive = false;
            clsUsersDataAccess.GetUserInfoByUserName(ref personID, ref UserId, ref userName, ref Password, ref isActive);

            return new clsUsers(UserId, personID, userName, Password, isActive);
        }

        public static clsUsers Find(int personID)
        {
             string UserName = "",Password="";
            int UserId = -1;
            bool isActive = false;
            clsUsersDataAccess.GetUserInfoByPersonID( ref personID, ref UserId,ref UserName,ref Password,ref isActive);

            return new clsUsers(UserId, personID, UserName, Password, isActive);


        }

        public static clsUsers FindByUsernameAndPassword(string UserName, string Password)
        {
            int UserID = -1;
            int PersonID = -1;

            bool IsActive = false;

            bool IsFound =clsUsersDataAccess.GetUserInfoByUsernameAndPassword
                                (UserName, Password, ref UserID, ref PersonID, ref IsActive);

            if (IsFound)
                //we return new object of that User with the right data
                return new clsUsers(UserID, PersonID, UserName, Password, IsActive);
            else
                return null;
        }


        public static DataTable GettAllUsers()
        {
            return clsUsersDataAccess.GettAllDataUsers();
        }

        public static bool IsUserExist(int UserID)
        {
            return clsUsersDataAccess.IsUserExist(UserID);
        }


        private bool _AddNewUser()
        {
           this.UserID=clsUsersDataAccess.AddNewUser(this.PersonID,this.UserName,this.Password,this.IsActive); 

            return this.UserID != -1;
        }

        private bool _UpdateUser()
        {

            return clsUsersDataAccess.UpdateUser(this.UserID,this.PersonID,this.UserName,this.Password,this.IsActive);


        }

        public static bool DeleteUser(int UserID)
        {
            return clsUsersDataAccess.DeleteUser(UserID);

        }
         public static bool RightPassword(string UserName ,string Password)
        {

            return clsUsersDataAccess.IsCorrectPassword(UserName, Password);

        }
        public bool Save()
        {

            switch (_Mode)
            {
                case enMode.AddMode:
                    
                    if (_AddNewUser())
                    {
                      _Mode = enMode.UpdateMode;
                    return true;
                    }
                    else 
                    {
                        return false; 
                    }
                case enMode.UpdateMode:

                    return _UpdateUser();
            }
            return false;


        }

    }
}
