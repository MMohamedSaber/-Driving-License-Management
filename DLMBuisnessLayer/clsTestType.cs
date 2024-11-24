using DLMDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLBuisnesLayer
{
    public class clsTestType
    {
        public int ID { set; get; }
        public string TestTitle { set; get; }
        public string TestDescription { set; get; }
        public double Fees { set; get; }

        clsTestType(int testTypeID, string title, string testDescription, double fees)
        {
            ID = testTypeID;
            TestTitle = title;  
            TestDescription= testDescription;
            Fees = fees;

        }
        public static DataTable GetAllTestType()
        {
            return clsTestTypeDataAccess.GetAllTestType();



        }

        public static clsTestType Find(int testTypeID)
        {
            string title = "", TestDescription = "";
            double Fees = -1;

            if (clsTestTypeDataAccess.GetTestType(ref testTypeID, ref title, ref TestDescription, ref Fees))
                return new clsTestType(testTypeID, title, TestDescription, Fees);
            else 
                return null;

        }
        private bool _UpdateAppType()
        {

            return clsTestTypeDataAccess.UpdateTestType(this.ID,this.TestTitle,this.TestDescription,this.Fees);
        }
        public bool Save()
        {

            return _UpdateAppType();


        }

    }
}
