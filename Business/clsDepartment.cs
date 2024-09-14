using System;
using System.Data;
using ClinicManagement_DataAccess;

namespace ClinicManagement_Business
{
    public class clsDepartment
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public short DepartmentID { set; get; }
        public string DepartmentName { set; get; }
        public string Location { set; get; }

        public clsDepartment()
        {
            this.DepartmentID = -1;
            this.DepartmentName = "";
            this.Location = "";
            Mode = enMode.AddNew;
        }
        private clsDepartment(short DepartmentID, string DepartmentName, string Location)
        {
            this.DepartmentID = DepartmentID;
            this.DepartmentName = DepartmentName;
            this.Location = Location;
            Mode = enMode.Update;
        }
        private bool _AddNewDepartment()
        {
            this.DepartmentID = (short)clsDepartmentData.AddNewDepartment(this.DepartmentName, this.Location);
            return (this.DepartmentID != -1);
        }
        private bool _UpdateDepartment()
        {
            return clsDepartmentData.UpdateDepartment(this.DepartmentID, this.DepartmentName, this.Location);
        }
        public static bool DeleteDepartment(short DepartmentID)
        {
            return clsDepartmentData.DeleteDepartment(DepartmentID);
        }
        public static bool DoesDepartmentExist(string DepartmentName)
        {
            return clsDepartmentData.DoesDepartmentExist(DepartmentName);
        }
        public static clsDepartment Find(short DepartmentID)
        {
            string DepartmentName = "";
            string Location = "";

            bool IsFound = clsDepartmentData.GetDepartmentByID(DepartmentID, ref DepartmentName, ref Location);

            if (IsFound)
                return new clsDepartment(DepartmentID, DepartmentName, Location);
            else
                return null;
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewDepartment())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateDepartment();
            }
            return false;
        }
        public static DataTable GetDepartments()
        {
            return clsDepartmentData.GetAllDepartments();
        }
    }
}
