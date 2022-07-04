using PS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PS.Services
{
    public class ManageProduct 

    {

        public List<Product> lsProduct { get; set; }

        public Func<char, List<Product>> FindProduct; 
        public Action<Category> ScanProduct;   

        public List<Product> Methode1(char c)
        {
            var req = from p in lsProduct
                      where p.Name.StartsWith(c)
                      select p;
            return req.ToList();
        }

        public List<Product> Methode2(char c)
        {
            var req = from p in lsProduct
                      where p.Name.EndsWith(c)
                      select p;
            return req.ToList();
        }
        public ManageProduct()
        {
            FindProduct = Methode1; 
            FindProduct = Methode2;
            FindProduct = c =>
            {
                var req = from p in lsProduct
                          where p.Name.StartsWith(c)
                          select p;
                return req.ToList();
            };  //mthode sans nom

            ScanProduct = cat =>
            {
                var req = from p in lsProduct
                          where p.Category.CategoryId == cat.CategoryId
                          select p;
                foreach (Product p in req)
                {
                    Console.WriteLine(p);
                }

            };


        }

        public IEnumerable<Chemical> GetChemicals(double price)
        {
            var req = from p in lsProduct.OfType<Chemical>()
                      where p.Price >= price
                      select p;
            var req2 = lsProduct.Where(p => p.Price > price).OfType<Chemical>();
            return req2.Take(5);
          
        }

        public double GetAveragePrice()
        {
            return lsProduct.Average(p => p.Price); 
        }
        public double GetMaxPrice()
        {
            return lsProduct.Max(p => p.Price); //ken bil mapda exression héthouma 
        }

        public Product GetMaxProductPrice()
        {
            var maxprice = lsProduct.Max(p => p.Price);
            return lsProduct.Where(p => p.Price == maxprice).First();
        }





        public int GetCountProduct(string city)
        { 
            //var req1 = from p in lsProduct.OfType<Chemical>()
            //           where p.City.Equals(city)
            //           select p;

            //return req1.Count();
            var req2 = lsProduct.OfType<Chemical>().Where(p => p.Adresse.City.Equals(city));
            return req2.Count(); //jasser
        }

        public IEnumerable<Chemical> GetChemicalCity()
        {
            //var req1 = from p in lsProduct.OfType<Chemical>()
            //           orderby p.City descending
            //           select p;
            //return req1;
            var req2 = lsProduct.OfType<Chemical>().OrderBy(p => p.Adresse.City);
            return req2; //jasser
        }

        public IEnumerable<IGrouping<String, Chemical>> GetChemicalGroupByCity()
        {
            //var req1 = from p in lsProduct.OfType<Chemical>()
            //           orderby p.City  //ordre mouhem 
            //           group p by p.City ;
            //  foreach(var g in req1)
            //{
            //    Console.WriteLine(g.Key);    
            //    foreach (var v in g)
            //    {
            //        Console.WriteLine(v);
            //    }

            //}
            //return req1;   


            var req2 = lsProduct.OfType<Chemical>().OrderByDescending(p => p.Adresse.City).GroupBy(p => p.Adresse.City);
            return req2; 
        }
    }
}
