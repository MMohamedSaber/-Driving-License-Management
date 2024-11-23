using DLMDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DVLBuisnesLayer
{
    public class clsApplicationType
    {

        public int ID { set; get; }
        public string ApplicationTypeName { set; get; }
        public double Fees { set; get; }

        public clsApplicationType()
        {
            this.ID = -1;
            this.ApplicationTypeName = string.Empty;
            this.Fees = 0;
        }
        public clsApplicationType(int id, string ApplicationTitle, double money) 
        { 
         ID = id;
         ApplicationTypeName = ApplicationTitle;
         Fees = money;
        
        } 


        public static DataTable GettApplicationType()
        {
            return clsApplicationTypeDataAccess.GetAllApplicationTypes();
        }

        public static clsApplicationType Find(int  id)
        {
            string ApplicationTitle = "";
            double money = -1;

            if (clsApplicationTypeDataAccess.FindByID(ref id, ref ApplicationTitle, ref money))
            {
                return new clsApplicationType(id, ApplicationTitle, money);
            }
            else
            {
                return null;
            }
        }


       private bool _UpdateAppType()
        {

            return clsApplicationTypeDataAccess.UpdateAppType(this.ID,this.ApplicationTypeName,this.Fees);
        }
        public bool Save()
        {

            return _UpdateAppType();


        }
    }
}
