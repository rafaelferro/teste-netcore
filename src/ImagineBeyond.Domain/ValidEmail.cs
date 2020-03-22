using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ImagineBeyond.Domain
{
    public class ValidEmail
    {

        public bool valid(string email)
        {
            string e = email;

            Regex rg = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");

            if (rg.IsMatch(e))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
