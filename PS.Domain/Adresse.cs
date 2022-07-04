using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Domain
{
    [Owned]
   public  class Adresse
    {

    
        public int StreetAdress { get; set; }
        public string City { get; set; }

    }
}
