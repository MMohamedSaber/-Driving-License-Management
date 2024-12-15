using System;
using System.Data;
using DLMDataAccessLayer;

namespace DVLBuisnesLayer
{
    public class clsDrivers
    {
        enum enMode { AddNewMod=1,UpdateMode=2}
          enMode Mode=enMode.AddNewMod;
        public int DriverID { get; set; }
        public int PersonID { get; set; }
        public int CreatedByUser { get; set; }
        public DateTime CreatedDate { get; set; }

        public clsDrivers()
        {
            DriverID = 0;
            PersonID = 0;
            CreatedByUser = 0;
            CreatedDate = DateTime.MinValue;
            Mode = enMode.AddNewMod;
        }

        public clsDrivers(int driverID, int personID, int createdByUser, DateTime createdDate)
        {
            DriverID = driverID;
            PersonID = personID;
            CreatedByUser = createdByUser;
            CreatedDate = createdDate;
            Mode = enMode.UpdateMode;

        }

        public static DataTable GetDriverRowByDriverID(int DriverID)
        {
            return clsDriversData.GetDriverRowByDriverID(DriverID);
        }

        // Add New Driver
        private bool _AddNewDriver()
        {
            this.DriverID = clsDriversData.AddNewDriver(this.PersonID, this.CreatedByUser, this.CreatedDate);
            return this.DriverID != 0;
        }

        // Get Driver by ID
        public static clsDrivers GetDriverByID(int driverID)
        {
            int personID = 0;
            int createdByUser = 0;
            DateTime createdDate = DateTime.MinValue;

            bool isFound = clsDriversData.FindByID(driverID, ref personID, ref createdByUser, ref createdDate);

            if (isFound)
            {
                return new clsDrivers(driverID, personID, createdByUser, createdDate);
            }
            else
            {
                return null;
            }
        }

        // Update Driver
        private bool UpdateDriver()
        {
            return clsDriversData.UpdateDriver(this.DriverID, this.PersonID, this.CreatedByUser, this.CreatedDate);
        }

        // Delete Driver
        public static bool DeleteDriver(int driverID)
        {
            return clsDriversData.DeleteDriver(driverID);
        }


        

        // Get All Drivers
        public static DataTable GetAllDrivers()
        {
            return clsDriversData.GetAllDrivers();
        }

        // Save Method
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNewMod:
                    if(_AddNewDriver())
                    {
                       Mode= enMode.UpdateMode;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                    // Add new driver logic
                case enMode.UpdateMode:
                    return UpdateDriver();  // Update existing driver logic
                
            }
            return false;
        }
    }
}
