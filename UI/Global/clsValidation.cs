using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UI.Global
{
    internal class clsValidation
    {

        public static bool ValidateEmail(string Input)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            
            Regex regex = new Regex(pattern);

            return regex.IsMatch(Input);
        }
        public static bool ValidateNationalID(string Input)
        {
            string pattern = @"^\d{10}$";

            Regex regex = new Regex(pattern);

            return regex.IsMatch(Input);
        }
        public static bool ValidateName(string Input)
        {
            string pattern = @"^[a-zA-Z'-]{2,22}$";

            Regex regex = new Regex(pattern);

            return regex.IsMatch(Input);
        }
        public static bool ValidateInteger(string Input)
        {
            string pattern = @"^-?\d+$";

            Regex regex = new Regex(pattern);

            return regex.IsMatch(Input);
        }
        public static bool ValidateFloat(string Input)
        {
            string pattern = @"^-?\d+(\.\d+)?$";

            Regex regex = new Regex(pattern);

            return regex.IsMatch(Input);
        }

    }
}
