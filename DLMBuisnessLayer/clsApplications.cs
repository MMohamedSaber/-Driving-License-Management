using DLMDataAccessLayer;
using System;
using System.Data;
using System.Runtime.Remoting.Messaging;

namespace DVLBuisnesLayer
{
    // Enum for mode
   public enum   enMode
    {
        Add = 1,
        Update = 2
    }

    public class clsApplications
    {
        public enum enApplicationStatus { New = 1, Canceled = 2, Completed = 3 }

        public enum enApplicationType
        {
            NewDrivingLicense = 1, RenewDrivingLicense = 2, ReplaceLostDrivingLicense = 3,
            ReplaceDamagedDrivingLicense = 4, ReleaseDetainedDrivingLicense = 5, NewInterNationalLicense = 6, RetakeTest = 7
        }

        public enum enMode
        {
            Add = 1,
            Update = 2
        }
        public  enMode Mode { get; set; }

        public int ApplicationID { get; set; }
        public int PersonID { get; set; }
        public clsPerson PersonInfo;
        public DateTime ApplicationDate { get; set; }
        public int ApplicationTypeID { get; set; }
        public clsApplicationType ApplicationTypeInfo;
        public enApplicationStatus AppStatus { get; set; }
        string StatusText
        {  get
            {
                switch (AppStatus)
                {
                    case enApplicationStatus.New:
                        return "New";
                    case enApplicationStatus.Canceled:
                        return "Canceled";
                    case enApplicationStatus.Completed:
                        return "Completed";
                    default:
                        return "UnKnown";

                }
            }
         }
        public DateTime LastStatusDate { get; set; }
        public float PaidFees { get; set; }
        public int CreatedByUser { get; set; }
        public clsUsers CreatedByUserInfo;

        // Empty constructor for Add mode
        public clsApplications()
        {
            ApplicationID = 0;
            PersonID = 0;
            ApplicationDate = DateTime.Now;
            ApplicationTypeID = 0;
            AppStatus = 0;
            LastStatusDate = DateTime.Now;
            PaidFees = 0;
            CreatedByUser = 0;
            Mode = enMode.Add;
        }

        // Constructor for Update mode
        public clsApplications(int applicationID, int personID, DateTime dateTime, int applicationTypeID,
                               enApplicationStatus status, DateTime lastStatusDate, float paidFees, int createdByUser)
        {
            this.ApplicationID = applicationID;
            this.PersonID = personID;
            this.ApplicationDate = dateTime;
            this.ApplicationTypeInfo = clsApplicationType.Find(applicationTypeID);
            this.AppStatus = status;
            this.LastStatusDate = lastStatusDate;
            this.PaidFees = paidFees;
            this.CreatedByUserInfo = clsUsers.Find(createdByUser);
            Mode = enMode.Update;
        }


        public static DataTable GetAllApplications()
        {
            return clsApplicationData.GetAllApplications();
        }

        // Read: Retrieve an application by ID
        public static clsApplications FindBaseApplication(int applicationID)
        {
            int perosnID = -1, applicationtype = -1; byte Status=1 ;
            DateTime dateTime=new DateTime(), LastStatus=new DateTime();
            float paidFees=0;
            int createdByUser = -1;

            bool IsFound = false;
            IsFound=clsApplicationData.GetApplicationById(ref applicationID, ref perosnID, ref dateTime, ref applicationtype, ref Status,
                ref LastStatus, ref paidFees, ref createdByUser);

            if(IsFound)
            {
                return new clsApplications( applicationID,  perosnID,  dateTime,  applicationtype,(enApplicationStatus)Status,
                 LastStatus,  paidFees,  createdByUser);
            }
            else
            {
                return null;
            }


        }

        // Create: Add a new application
        private bool  _Add()
        {

            this.ApplicationID = clsApplicationData.CreateApplication(this.PersonID,this.ApplicationDate,
                this.ApplicationTypeID, (byte)this.AppStatus, this.LastStatusDate, this.PaidFees, this.CreatedByUser);

            return this.ApplicationID != 0;
        }

        // Update: Modify an existing application
        public bool Update( )
        {
            // TODO: Implement the logic for updating an existing application
            return clsApplicationData.UpdateApplicationById( this.ApplicationID,this.PersonID, this.ApplicationDate, this.ApplicationTypeID,
              (byte)this.AppStatus, this.LastStatusDate, this.PaidFees, this.CreatedByUser);
        }

        // Delete: Remove an application by ID
        public bool Delete(int applicationID)
        {
            return clsApplicationData.DeleteApplicationById(applicationID);
                            
        }

        public bool Cancel()
        {
            return clsApplicationData.UpdateStatusByApplicationIDAndNewStatus(this.ApplicationID,2);
        }

        public bool setComplete()
        {
            return clsApplicationData.UpdateStatusByApplicationIDAndNewStatus(ApplicationID,3);
        }


        public static bool GetActiveApplicationIDForLicense(int applicationPersonID,int licenseClassID)
        {
            bool Found= clsApplicationData.CheckApplicationByPersonAndLicense(applicationPersonID,licenseClassID);
            return Found;
            
        }

         //OverLoaded-- still empty
        public static  bool DoesPersonHaveActiveApplication(int applicationTypeID,int applicationtype)
        {
            return true;
        }

        //still empty
        public bool DoesPersonHaveActiveApplication(int applicationTypeID)
        {
            return true;
        }
        public static bool DoesApplicationExist(int applicationID)
        {
           return clsApplicationData.DoesApplicationExist(applicationID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.Add:
                    if (_Add())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:

                    return Update();
              

            }
            return false;
        }
    }
}
