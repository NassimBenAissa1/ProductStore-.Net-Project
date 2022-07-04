using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Domain
{
   public class Biological : Product
    {
        //public Biological(string herbs,int productId, string name, double price, DateTime dateProd, string description, int quantity, Category category, List<Provider> providers) : base(productId, name, price, dateProd, description, quantity, category, providers)
        //{
        //    Herbs = herbs;
        //na7ina constructeur bech najmou netsarefou fihom
        //}

        public string Herbs { get; set; }

        public override void GetMyType()
            //heritage
        {
            base.GetMyType();
            Console.Write("biologique\n");
        }
    }
}
