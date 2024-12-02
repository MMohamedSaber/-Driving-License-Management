using DLMDataAccessLayer;
using System;
using System.Data;

namespace DVLBuisnesLayer
{
    public class clsLicenseClasses
    {
        public int LicenseClassID { get; set; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public int MinimumAllowedAge { get; set; }
        public int DefaultValidityLength { get; set; }
        public float ClassFees { get; set; }

        // Constructor
        public clsLicenseClasses() { }

        public clsLicenseClasses(
            int licenseClassID,
            string className,
            string classDescription,
            int minimumAllowedAge,
            int defaultValidityLength,
            float classFees)
        {
            LicenseClassID = licenseClassID;
            ClassName = className;
            ClassDescription = classDescription;
            MinimumAllowedAge = minimumAllowedAge;
            DefaultValidityLength = defaultValidityLength;
            ClassFees = classFees;
        }

        // Get all License Classes
        public static DataTable GetAllLicenseClasses()
        {
            return clsLicenseClassesDataAccess.GetAllLicenseClasses();
        }

        // Find License Class by ID
        public static clsLicenseClasses Find(int licenseClassID)
        {
            string className = "";
            string classDescription = "";
            int minimumAllowedAge = 0;
            int defaultValidityLength = 0;
            float classFees = 0;

            bool isFound = clsLicenseClassesDataAccess.GetLicenseClassByID(
                licenseClassID,
                ref className,
                ref classDescription,
                ref minimumAllowedAge,
                ref defaultValidityLength,
                ref classFees);

            if (isFound)
            {
                return new clsLicenseClasses(
                    licenseClassID,
                    className,
                    classDescription,
                    minimumAllowedAge,
                    defaultValidityLength,
                    classFees);
            }
            else
            {
                return null;
            }
        }

        // Insert a new License Class using instance properties
        public bool Add()
        {
            return clsLicenseClassesDataAccess.AddNewLicenseClass(
                this.ClassName,
                this.ClassDescription,
                this.MinimumAllowedAge,
                this.DefaultValidityLength,
                this.ClassFees);
        }

        // Update an existing License Class using instance properties
        public bool Update()
        {
            return clsLicenseClassesDataAccess.UpdateLicenseClass(
                this.LicenseClassID,
                this.ClassName,
                this.ClassDescription,
                this.MinimumAllowedAge,
                this.DefaultValidityLength,
                this.ClassFees);
        }

        // Delete a License Class
        public static bool Delete(int licenseClassID)
        {
            return clsLicenseClassesDataAccess.DeleteLicenseClass(licenseClassID);
        }
    }
}
