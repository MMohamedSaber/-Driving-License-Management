using DLMDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cc
{
    public class clsUsers
    {

        public clsUsers()
        {
            
        }


        public static bool Find(string username, string password)
        { 
          return clsUsersDataAccess.IsUserExistByUserNameAndPassword(username, password);
        }


    }
}
