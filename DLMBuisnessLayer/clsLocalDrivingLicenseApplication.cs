using DLMDataAccessLayer;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLBuisnesLayer
{
    public class clsLocalDrivingLicenseApplication : clsApplication
    {
        // Enum to define application mode (Add or Update)
        public enum enMode { AddMode = 1, UpdateMode = 2 };

        // Current mode of the application (Add by default)
        enMode Mode = enMode.AddMode;

        // Properties of the local driving license application
        public int LocalLicenseID { get; set; }  // Unique ID for local license
        public int LicenseClassID { get; set; } // ID for license class
        public clsLicenseClasses LicenseClassInfo; // License class information object




        // Default constructor initializing default values
        public clsLocalDrivingLicenseApplication()
        {
            this.LocalLicenseID = -1; // Indicates an uninitialized ID
            this.LicenseClassID = -1;// Indicates an uninitialized ID
            Mode = enMode.AddMode;   // Default mode is AddMode
        }

        // Parameterized constructor for initializing an existing application
        public clsLocalDrivingLicenseApplication(
            int localDrivingLicenseApplicationID, int applicationID, int applicantPersonID, DateTime applicationDate,
            int applicationTypeID, enApplicationStatus applicationStatus, DateTime lastStatusDate, float paidFees,
            int createdByUserID, int licenseClassID)
        {
            this.LocalLicenseID = localDrivingLicenseApplicationID;
            this.ApplicationID = applicationID;
            this.ApplicantPersonID = applicantPersonID;
            this.ApplicationDate = applicationDate;
            this.ApplicationTypeID =(int) applicationTypeID;
            this.ApplicationStatus = applicationStatus;
            this.LastStatusDate = lastStatusDate;
            this.PaidFees = paidFees;
            this.CreatedByUserID = createdByUserID;
            this.LicenseClassID = licenseClassID;
            this.LicenseClassInfo = clsLicenseClasses.Find(licenseClassID); // Find license class info by ID

            Mode = enMode.UpdateMode;
        }




        public static DataTable GetAllApplications()
        {
            return clsLocalDrivingLicenseApplicationData.GetAllApplications();
        }

        private bool _Add()
        {
            this.LocalLicenseID = clsLocalDrivingLicenseApplicationData
                .AddNewLocalDrivingLicenseApplication(this.ApplicationID, this.LicenseClassID);

            // Return true if a valid ID is assigned, indicating success
            return this.LocalLicenseID != 0;
        }

        private bool _Update()
        {
            return clsLocalDrivingLicenseApplicationData
                .UpdateLicenseApplication(this.LocalLicenseID, this.ApplicationID, this.LicenseClassID);
        }

        public static clsLocalDrivingLicenseApplication FindLocalDrivingLicenseAppByLocalLicenseID(int LocalLicenseDrivingID)
        {
            int ApplicationID = -1, LicenseClassID = -1;

            bool IsFound = clsLocalDrivingLicenseApplicationData.GetLocalDrivingLicenseApplicationByLicenseID
                (ref LocalLicenseDrivingID, ref ApplicationID, ref LicenseClassID);

            if (IsFound)
            {
              //  Fetch base application details
                  clsApplication Application = clsApplication.FindBaseApplication(ApplicationID);

                return new clsLocalDrivingLicenseApplication
                    (LocalLicenseDrivingID, Application.ApplicationID, Application.ApplicantPersonID,
                     Application.ApplicationDate, Application.ApplicationTypeID, Application.ApplicationStatus,
                     Application.LastStatusDate, Application.PaidFees, Application.CreatedByUserID, LicenseClassID);

            }
            else
            {
                return null;
            }
        }
        public static clsLocalDrivingLicenseApplication FindLocalDrivingLicenseAppByAppID(int LocalLicenseDrivingID)
        {
            int ApplicationID = -1, LicenseClassID = -1;

            // Retrieve license application data by application ID
            bool IsFound = clsLocalDrivingLicenseApplicationData.GetLocalDrivingLicenseApplicationByLicenseID
                 (ref LocalLicenseDrivingID, ref ApplicationID, ref LicenseClassID);

            if (IsFound)
            {
                // Fetch base application details
                clsApplication Application = clsApplication.FindBaseApplication(ApplicationID);

                // Return a new instance of clsLocalDrivingLicenseApplication with retrieved data
                return new clsLocalDrivingLicenseApplication
                    (LocalLicenseDrivingID, Application.ApplicationID, Application.ApplicantPersonID,
                     Application.ApplicationDate, Application.ApplicationTypeID, Application.ApplicationStatus,
                     Application.LastStatusDate, Application.PaidFees, Application.CreatedByUserID, LicenseClassID);
            }
            else
            {
                // Return null if not found
                return null;
            }
        }

        public bool Save()
        {
            // Set the mode in the base class
            base.Mode = (clsApplication.enMode)Mode;

            // Call base Save method and return false if it fails
            if (!base.Save())
                return false;

            // Perform operation based on the current Mode
            switch (Mode)
            {
                case enMode.AddMode:
                    return _Add(); // Call Add method for AddMode

                case enMode.UpdateMode:
                    return _Update(); // Call Update method for UpdateMode
            }

            // Return false if no valid Mode is set
            return false;
        }
    }
}
