using System;
using System.Collections.Generic;
using System.Data;
using DLMDataAccessLayer;  // Assuming this is your data access layer for database interaction

namespace DVLBuisnesLayer
{
    public class clsDetain
    {

        enum enMode {AddMode=1,UpdateMode=2}
        enMode Mode=enMode.AddMode;

        public int DetainID { get; set; }
        public int LicenseID { get; set; }
        public DateTime DetainDate { get; set; }
        public float FineFees { get; set; }
        public int CreatedbyUserID { get; set; }
        public bool IsReleased { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int ReleasedByUserID { get; set; }
        public int ReleasApplicationID { get; set; }

        // Constructor
        public clsDetain()
        {
            this.DetainID = -1;
            this.LicenseID = -1;
            this.DetainDate = DateTime.Now;
            this.FineFees = 0;
            this.CreatedbyUserID = -1;
            this.IsReleased = false;
            this.ReleaseDate = DateTime.Now;
            this.ReleasedByUserID = -1;
            this.ReleasApplicationID = -1;
        }



        // Constructor with parameters for easy initialization
        private clsDetain(int detainID, int licenseID, DateTime detainDate, float fineFees,
                          int createdbyUserID, bool isReleased, DateTime? releaseDate,
                          int releasedByUserID, int releasApplicationID)
        {
            this.DetainID = detainID;
            this.LicenseID = licenseID;
            this.DetainDate = detainDate;
            this.FineFees = fineFees;
            this.CreatedbyUserID = createdbyUserID;
            this.IsReleased = isReleased;
            this.ReleaseDate = releaseDate;
            this.ReleasedByUserID = releasedByUserID;
            this.ReleasApplicationID = releasApplicationID;
        }
        private bool _AddNewDetain()
        {
            // Call DataAccess Layer to create a new detain record
            this.DetainID = clsDetainData.AddNewDetain(
                this.LicenseID, this.DetainDate, this.FineFees,
                this.CreatedbyUserID, this.IsReleased, this.ReleaseDate,
                this.ReleasedByUserID, this.ReleasApplicationID);

            return (this.DetainID != 0);
        }

        private bool _UpdateDetain()
        {
            // Call DataAccess Layer to update the existing detain record
            return clsDetainData.UpdateDetainById(this.DetainID, this.LicenseID, this.DetainDate,
                this.FineFees, this.CreatedbyUserID, this.IsReleased, this.ReleaseDate,
                this.ReleasedByUserID, this.ReleasApplicationID);
        }

        public static clsDetain FindDetainByID(int detainID)
        {
            int licenseID = -1;
            DateTime detainDate = DateTime.Now;
            float fineFees = 0;
            int createdByUserID = -1;
            bool isReleased = false;
            DateTime releaseDate = DateTime.Now;
            int releasedByUserID = -1;
            int releaseApplicationID = -1;

            bool isFound = clsDetainData.FindDetainByID(
                 detainID, ref licenseID, ref detainDate, ref fineFees,
                ref createdByUserID, ref isReleased, ref releaseDate,
                ref releasedByUserID, ref releaseApplicationID);

            if (isFound)
                // Return the detain object with the correct data
                return new clsDetain(detainID, licenseID, detainDate, fineFees, createdByUserID, isReleased, releaseDate, releasedByUserID, releaseApplicationID);
            else
                return null;
        }

        public static clsDetain FindDetainByLicenseID(int licenseID)
        {
            int detainID = -1;
            DateTime detainDate = DateTime.Now;
            float fineFees = 0;
            int createdByUserID = -1;
            bool isReleased = false;
            DateTime? releaseDate = DateTime.Now;
            int releasedByUserID = -1;
            int releaseApplicationID = -1;

            bool isFound = clsDetainData.FindDetainByLicenseID(
                 licenseID, ref detainID, ref detainDate, ref fineFees,
                ref createdByUserID, ref isReleased, ref releaseDate,
                ref releasedByUserID, ref releaseApplicationID);

            if (isFound)
                // Return the detain object with the correct data
                return new clsDetain(detainID, licenseID, detainDate, fineFees, createdByUserID, isReleased, releaseDate, releasedByUserID, releaseApplicationID);
            else
                return null;
        }

        public bool Delete()
        {
            // Call DataAccess Layer to delete the detain record by DetainID
            return clsDetainData.DeleteDetainById(this.DetainID);
        }

        public static bool IsLicenseDetained(int LicenseID)
        {
            return clsDetainData.IsLicenseDetainedByLicenseID(LicenseID);


        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddMode:
                    if (_AddNewDetain())
                    {
                        Mode = enMode.UpdateMode;
                        return true;
                    }else
                    {
                        return false;
                    }
                case enMode.UpdateMode:
                    return _UpdateDetain();
                
            }

            return false;

        }
            
    public static DataTable GettAllDetainedLicese()
        {
            return clsDetainData.GetAllDetainTable();
        }
    }
}
