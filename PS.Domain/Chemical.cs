using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Domain
{
    public class Chemical : Product


    {
      


        //public Chemical(int productId, string name, double price, DateTime dateProd, string description, int quantity, Category category, List<Provider> providers) : base(productId, name, price, dateProd, description, quantity, category, providers)
        //{

        //}

        public string LabName { get; set; }

        public virtual Adresse Adresse { get; set; }
        public override void GetMyType()
        {
            base.GetMyType();  // pour hériter console.write du parentk.

            Console.WriteLine(" chemical");  //yafichi meta3 base wel jedida 
        }
    }
}
