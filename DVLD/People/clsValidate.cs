using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DVLD
{
    internal class clsValidate
    {
        public static bool ValidateEmail(string Email)
        {
            var pattren = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            var regex = new Regex(pattren);
            return regex.IsMatch(Email);
        }
    }
}
