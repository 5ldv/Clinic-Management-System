using System;
using System.Configuration;

namespace ClinicManagement_DataAccess
{
    static class clsDataAccessSettings
    {
        public static string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectingString"].ToString();
    }
}
