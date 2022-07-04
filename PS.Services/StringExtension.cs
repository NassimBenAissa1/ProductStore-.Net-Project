using PS.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Services
{
   public static class StringExtension
    {
        public static void UpperName(this string s)  
        {
            string c = s[0].ToString();

            s = c.ToUpper() + s.Substring(1);
            Console.WriteLine(s);
            
        }

        public static void UpperNameProvider(this Provider p)  
        {
            p.UserName = p.UserName.ToUpper();

        }

        public static bool IntCategory(this Product p,Category c)
        {
            return p.Name.Equals(c.Name); 

        }
    }
}
