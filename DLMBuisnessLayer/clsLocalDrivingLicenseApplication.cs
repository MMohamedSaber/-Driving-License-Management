using DLMDataAccessLayer;
using DVLBuisnesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cc
{
    public class clsLocalDrivingLicenseApplication : clsApplications
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
            this.ApplicationID = -1;
            this.LocalLicenseID = -1;// Indicates an uninitialized ID
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
            this.PersonID = applicantPersonID;
            this.ApplicationDate = applicationDate;
            this.ApplicationTypeID = applicationTypeID;
            this.AppStatus = applicationStatus;
            this.LastStatusDate = lastStatusDate;
            this.PaidFees = paidFees;
            this.CreatedByUser = createdByUserID;
            this.LicenseClassID = licenseClassID;
            this.LicenseClassInfo = clsLicenseClasses.Find(licenseClassID); // Find license class info by ID

            // Set mode to Update since the application is being initialized with existing data
            Mode = enMode.UpdateMode;
        }

        // Private method to handle adding a new license application
        private bool _Add()
        {
            this.LocalLicenseID = clsLocalDrivingLicenseApplicationData
                .AddNewLocalDrivingLicenseApplication(this.ApplicationID, this.LicenseClassID);

            // Return true if a valid ID is assigned, indicating success
            return this.LocalLicenseID != 0;
        }

        // Private method to handle updating an existing license application
        private bool _Update()
        {
            return clsLocalDrivingLicenseApplicationData
                .UpdateLicenseApplication(this.LocalLicenseID, this.ApplicationID, this.LicenseClassID);
        }

        // Find application by license ID
        public static clsLocalDrivingLicenseApplication FindLocalDrivingLicenseAppByLicenseID(int LocalLicenseDrivingID)
        {
            int ApplicationID = -1, LicenseClassID = -1;

            // Retrieve license application data by license ID
            bool IsFound = clsLocalDrivingLicenseApplicationData.GetLocalDrivingLicenseApplicationByLicenseID
                (ref LocalLicenseDrivingID, ref ApplicationID, ref LicenseClassID);

            if (IsFound)
            {
                // Fetch base application details
                clsApplications Application = clsApplications.FindBaseApplication(ApplicationID);

                // Return a new instance of clsLocalDrivingLicenseApplication with retrieved data
                return new clsLocalDrivingLicenseApplication
                    (LocalLicenseDrivingID, Application.ApplicationID, Application.PersonID,
                     Application.ApplicationDate, Application.ApplicationTypeID, Application.AppStatus,
                     Application.LastStatusDate, Application.PaidFees, Application.CreatedByUser, LicenseClassID);
            }
            else
            {
                // Return null if not found
                return null;
            }
        }

        // Find application by application ID
        public static clsLocalDrivingLicenseApplication FindLocalDrivingLicenseAppByAppID(int ApplicationID)
        {
            int LocalLicenseDrivingID = -1, LicenseClassID = -1;

            // Retrieve license application data by application ID
            bool IsFound = clsLocalDrivingLicenseApplicationData.GetLocalDrivingLicenseApplicationByApplicationID
                 (ref LocalLicenseDrivingID, ref ApplicationID, ref LicenseClassID);

            if (IsFound)
            {
                // Fetch base application details
                clsApplications Application = clsApplications.FindBaseApplication(ApplicationID);

                // Return a new instance of clsLocalDrivingLicenseApplication with retrieved data
                return new clsLocalDrivingLicenseApplication
                    (LocalLicenseDrivingID, Application.ApplicationID, Application.PersonID,
                     Application.ApplicationDate, Application.ApplicationTypeID, Application.AppStatus,
                     Application.LastStatusDate, Application.PaidFees, Application.CreatedByUser, LicenseClassID);
            }
            else
            {
                // Return null if not found
                return null;
            }
        }

        // Save method to handle Add or Update logic based on the current Mode
        public bool Save()
        {
            // Set the mode in the base class
            base.Mode = (clsApplications.enMode)Mode;

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
