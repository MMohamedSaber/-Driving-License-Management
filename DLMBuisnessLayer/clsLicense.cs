using System;
using System.Data;
using System.Runtime.CompilerServices;
using DLMDataAccessLayer;

namespace DVLBuisnesLayer
{
    public class clsLicense
    {

        enum enMode { AddNewLicense=1,UpdateLicense=2}

        enMode Mode=enMode.AddNewLicense;
        // Properties
        public int LicenseID { get; set; }
        public int ApplicationID { get; set; }
        public clsApplication ApplicationInfo;
        public int DriverID { get; set; }
        //public string ;
        public int LicenseClass { get; set; }
        public clsLicenseClasses LicenseClasseInfo;

        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; }
        public float PaidFees { get; set; }
        public bool IsActive { get; set; }
        public byte IssueReason { get; set; }
        public int CreatedByUserID { get; set; }
        public clsUsers UserInfo ;




        public clsLicense()
        {
            LicenseID = 0;
            ApplicationID = 0;
            DriverID = 0;
            LicenseClass = 0;
            IssueDate = DateTime.MinValue;
            ExpirationDate = DateTime.MinValue;
            Notes = string.Empty;
            PaidFees = 0;
            IsActive = false;
            IssueReason =0;
            CreatedByUserID = 0;
            Mode = enMode.AddNewLicense;
        }

        public clsLicense(int licenseID, int applicationID, int driverID, int licenseClass,
                         DateTime issueDate, DateTime expirationDate, string notes, float paidFees,
                         bool isActive, byte issueReason, int createdByUserID)
        {
            LicenseID = licenseID;
            ApplicationID = applicationID;
            ApplicationInfo = clsApplication.FindBaseApplication(ApplicationID);
            DriverID = driverID;
            LicenseClass = licenseClass;
            LicenseClasseInfo = clsLicenseClasses.Find(LicenseClass);
            IssueDate = issueDate;
            ExpirationDate = expirationDate;
            Notes = notes;
            PaidFees = paidFees;
            IsActive = isActive;
            IssueReason = issueReason;
            CreatedByUserID = createdByUserID;
            UserInfo = clsUsers.Find(CreatedByUserID);
            Mode = enMode.UpdateLicense;


        }









        // Add New License
        private bool _AddNewLicense()
        {
            this.LicenseID = clsLicenseData.AddNewLicense(this.ApplicationID, this.DriverID, this.LicenseClass, this.IssueDate, this.ExpirationDate,
                this.Notes, this.PaidFees, this.IsActive, this.IssueReason, this.CreatedByUserID);

            return this.LicenseID != 0;
        }

        // Get License by ID
        public static clsLicense GetLicenseByID(int licenseID)
        {
            int applicationID = 0;
            int driverID = 0;
            int licenseClass = 0;
            DateTime issueDate = DateTime.MinValue;
            DateTime expirationDate = DateTime.MinValue;
            string notes = string.Empty;
            float paidFees = 0;
            bool isActive = false;
            byte issueReason = 0;
            int createdByUserID = 0;

            bool isFound = clsLicenseData.FindByID(licenseID, ref applicationID, ref driverID, ref licenseClass,
                                                ref issueDate, ref expirationDate, ref notes, ref paidFees,
                                                ref isActive, ref issueReason, ref createdByUserID);

            if (isFound)
            {
                return new clsLicense(licenseID, applicationID, driverID, licenseClass,
                                                  issueDate, expirationDate, notes, paidFees,
                                                  isActive, issueReason, createdByUserID);
            }
            else
            {
                return null;
            }
        }


        public static clsLicense FindByApplicationID(int ApplicationID)
        {
            int LicenseID = -1;
            int driverID = 0;
            int licenseClass = 0;
            DateTime issueDate = DateTime.MinValue;
            DateTime expirationDate = DateTime.MinValue;
            string notes = string.Empty;
            float paidFees = 0;
            bool isActive = false;
            byte issueReason = 0;
            int createdByUserID = 0;

            bool isFound = clsLicenseData.FindByApplicationID(ApplicationID, ref LicenseID, ref driverID, ref licenseClass,
                                                ref issueDate, ref expirationDate, ref notes, ref paidFees,
                                                ref isActive, ref issueReason, ref createdByUserID);

            if (isFound)
            {
                return new clsLicense(LicenseID, ApplicationID, driverID, licenseClass,
                                                  issueDate, expirationDate, notes, paidFees,
                                                  isActive, issueReason, createdByUserID);
            }
            else
            {
                return null;
            }
        }

        // Update License
        private bool UpdateLicense()
        {
            return  clsLicenseData.UpdateLicense(this.LicenseID,this.ApplicationID, this.DriverID, this.LicenseClass, this.IssueDate, this.ExpirationDate,
                this.Notes, this.PaidFees, this.IsActive, this.IssueReason, this.CreatedByUserID);

        }

        // Delete License
        public static bool DeleteLicense(int licenseID)
        {
            return clsLicenseData.DeleteLicense(licenseID);
        }

        // Get All Licenses
        public static DataTable GetAllLicenses()
        {
            return clsLicenseData.GetAllLicenses();
        }

        public static bool HaveActiveLicense(int licenseId, int ApplicationID)
        {
            return clsLicenseData.IsLicenseExist(licenseId, ApplicationID);
        }

        // Save Method
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNewLicense:

                    if( _AddNewLicense())
                    {
                        Mode = enMode.UpdateLicense;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    
                case enMode.UpdateLicense:

                    return UpdateLicense();
            }

            return false;
        }

        public static  bool IsLicenseActive(int licenseID)
        {

            return clsLicenseData.ActiveLicenseByLicenseID(licenseID);

        }

    }
}
