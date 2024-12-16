using System;
using System.ComponentModel;
using System.Data;
using DLMDataAccessLayer;

namespace DVLBuisnesLayer
{
    public class clsInternationalLicense
    {
        public enum enMode { AddNew = 1, Update = 2 }
        public enMode Mode = enMode.AddNew;

        public int InternationalLicenseID { get; set; }
        public int ApplicationID { get; set; }
        public clsApplication ApplicationInfo
        {
            get { return clsApplication.FindBaseApplication(ApplicationID); }
        }
        public int DriverID { get; set; }
        public clsDrivers DriversInfo
        {
            get { return clsDrivers.GetDriverByID(DriverID); }
        }
        public int IssuedUseingLocalDrivingLicenseID { get; set; }
        public DateTime IssuedDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; }
        public int CreatedByUser { get; set; }
        public clsUsers UserInfo
        {
            get { return clsUsers.Find(CreatedByUser); }
        }

        // Default constructor for adding a new license
        public clsInternationalLicense()
        {
            this.InternationalLicenseID = -1;
            this.ApplicationID = -1;
            this.DriverID = -1;
            this.IssuedUseingLocalDrivingLicenseID = -1;
            this.IssuedDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now;
            this.IsActive = true;
            this.CreatedByUser = -1;

            Mode = enMode.AddNew;
        }

        // Constructor for updating an existing license
        private clsInternationalLicense(int internationalLicenseID, int applicationID, int driverID, int issuedUsingLocalLicenseID, DateTime issuedDate, DateTime expirationDate, bool isActive, int createdByUser)
        {
            this.InternationalLicenseID = internationalLicenseID;
            this.ApplicationID = applicationID;
            this.DriverID = driverID;
            this.IssuedUseingLocalDrivingLicenseID = issuedUsingLocalLicenseID;
            this.IssuedDate = issuedDate;
            this.ExpirationDate = expirationDate;
            this.IsActive = isActive;
            this.CreatedByUser = createdByUser;

            Mode = enMode.Update;
        }

        // Method to add a new international license
        private bool _AddNewInternationalLicense()
        {
            this.InternationalLicenseID = clsInternationalLicenseData.CreateInternationalLicense(
                this.ApplicationID,
                this.DriverID,
                this.IssuedUseingLocalDrivingLicenseID,
                this.IssuedDate,
                this.ExpirationDate,
                this.IsActive,
                this.CreatedByUser
            );

            return (this.InternationalLicenseID != -1);
        }

        // Method to update an existing international license
        private bool _UpdateInternationalLicense()
        {
            return clsInternationalLicenseData.UpdateInternationalLicenseById(
                this.InternationalLicenseID,
                this.ApplicationID,
                this.DriverID,
                this.IssuedUseingLocalDrivingLicenseID,
                this.IssuedDate,
                this.ExpirationDate,
                this.IsActive,
                this.CreatedByUser
            );
        }

        // Save method to handle both add and update
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewInternationalLicense())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateInternationalLicense();
            }

            return false;
        }

        // Method to delete an international license
        public bool Delete()
        {
            return clsInternationalLicenseData.DeleteInternationalLicenseById(this.InternationalLicenseID);
        }

        // Static method to find an international license by ID
        public static clsInternationalLicense Find(int internationalLicenseID)
        {
            int applicationID = -1;
            int driverID = -1;
            int issuedUsingLocalLicenseID = -1;
            DateTime issuedDate = DateTime.Now;
            DateTime expirationDate = DateTime.Now;
            bool isActive = true;
            int createdByUser = -1;

            bool isFound = clsInternationalLicenseData.GetInternationalLicenseById(
                ref internationalLicenseID,
                ref applicationID,
                ref driverID,
                ref issuedUsingLocalLicenseID,
                ref issuedDate,
                ref expirationDate,
                ref isActive,
                ref createdByUser
            );

            if (isFound)
            {
                return new clsInternationalLicense(
                    internationalLicenseID,
                    applicationID,
                    driverID,
                    issuedUsingLocalLicenseID,
                    issuedDate,
                    expirationDate,
                    isActive,
                    createdByUser
                );
            }
            else
            {
                return null;
            }
        }

        // Check if an international license exists by ID
        public static bool IsInternationalLicenseExist(int LocalLicenseID)
        {
            return clsInternationalLicenseData.IsInternationalLicenseExist(LocalLicenseID);
        }

        public static bool IsHaveLicenseOfClassThree(int LicenseID)
        {
            return clsInternationalLicenseData.IsHaveLicenseOfClassThree(LicenseID);
        }


        public static DataTable GetDriverRowByDriverID(int DriverID)
        {
            return clsInternationalLicenseData.GetDriverRowByDriverID(DriverID);
        }
    }
}
