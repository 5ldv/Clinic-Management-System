using System;
using System.Data;
using ClinicManagementDB_DataAccess;

namespace ClinicManagementDB_Business
{
    public class clsAppointment
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int? AppointmentID { set; get; }
        public int PatientID { set; get; }
        public short DoctorID { set; get; }
        public DateTime AppointmentDate { set; get; }
        public byte AppointmentStatus { set; get; }
        public bool IsPaid { set; get; }
        public int? PaymentID { set; get; }
        public short CreatedByUserID { set; get; }
        public DateTime CreatedAt { set; get; }
        public short? UpdatedByUserID { set; get; }
        public DateTime? UpdatedAt { set; get; }

        public clsAppointment()
        {
            this.AppointmentID = null;
            this.PatientID = -1;
            this.DoctorID = -1;
            this.AppointmentDate = DateTime.Now;
            this.AppointmentStatus = 0;
            this.IsPaid = false;
            this.PaymentID = null;
            this.CreatedByUserID = -1;
            this.CreatedAt = DateTime.Now;
            this.UpdatedByUserID = null;
            this.UpdatedAt = null;
            Mode = enMode.AddNew;
        }
        private clsAppointment(int? AppointmentID, int PatientID, short DoctorID, DateTime AppointmentDate, byte AppointmentStatus, bool IsPaid, int? PaymentID, short CreatedByUserID, DateTime CreatedAt, short? UpdatedByUserID, DateTime? UpdatedAt)
        {
            this.AppointmentID = AppointmentID;
            this.PatientID = PatientID;
            this.DoctorID = DoctorID;
            this.AppointmentDate = AppointmentDate;
            this.AppointmentStatus = AppointmentStatus;
            this.IsPaid = IsPaid;
            this.PaymentID = PaymentID;
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedAt = CreatedAt;
            this.UpdatedByUserID = UpdatedByUserID;
            this.UpdatedAt = UpdatedAt;
            Mode = enMode.Update;
        }
        private bool _AddNewAppointment()
        {
            this.AppointmentID = (int?)clsAppointmentData.AddNewAppointment(this.PatientID, this.DoctorID, this.AppointmentDate, this.AppointmentStatus, this.IsPaid, this.PaymentID, this.CreatedByUserID, this.CreatedAt, this.UpdatedByUserID, this.UpdatedAt);
            return (this.AppointmentID != -1);
        }
        private bool _UpdateAppointment()
            => clsAppointmentData.UpdateAppointment(this.AppointmentID, this.PatientID, this.DoctorID, this.AppointmentDate, this.AppointmentStatus, this.IsPaid, this.PaymentID, this.CreatedByUserID, this.CreatedAt, this.UpdatedByUserID, this.UpdatedAt);
        public static clsAppointment Find(int? AppointmentID)
        {
            int PatientID = -1;
            short DoctorID = -1;
            DateTime AppointmentDate = DateTime.Now;
            byte AppointmentStatus = 0;
            bool IsPaid = false;
            int? PaymentID = null;
            short CreatedByUserID = -1;
            DateTime CreatedAt = DateTime.Now;
            short? UpdatedByUserID = null;
            DateTime? UpdatedAt = null;

            bool IsFound = clsAppointmentData.GetAppointmentByID(AppointmentID, ref PatientID, ref DoctorID, ref AppointmentDate, ref AppointmentStatus, ref IsPaid, ref PaymentID, ref CreatedByUserID, ref CreatedAt, ref UpdatedByUserID, ref UpdatedAt);

            if(IsFound)
                return new clsAppointment(AppointmentID, PatientID, DoctorID, AppointmentDate, AppointmentStatus, IsPaid, PaymentID, CreatedByUserID, CreatedAt, UpdatedByUserID, UpdatedAt);
            else
                return null;
        }
        public bool Save()
        {
            switch(Mode)
            {
                case enMode.AddNew:
                    if(_AddNewAppointment())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateAppointment();
            }
            return false;
        }
        public static bool DeleteAppointment(int? AppointmentID)
            => clsAppointmentData.DeleteAppointment(AppointmentID);
        public static bool DoesAppointmentExist(int? AppointmentID)
            => clsAppointmentData.DoesAppointmentExist(AppointmentID);
        public static DataTable GetAppointments()
            => clsAppointmentData.GetAllAppointments();
    }
}
