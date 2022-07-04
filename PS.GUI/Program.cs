using PS.data;
using PS.Data.Infrastructure;
using PS.Domain;
using PS.Services;
using System;
using System.Collections.Generic;

namespace PS.GUI
{
    class Program
    {
        static void Main(string[] args)
        {

            Category c = new Category 
            
            {

                Name= "fraise"

            }
                ;

          



            Product p1 = new Product();
            p1.Name = "Pomme";
            p1.DateProd = new DateTime(2012, 11, 23);
            //   Console.WriteLine(p1.ToString());

            // Console.WriteLine(p1.Name.ToString());
            Category c1= new Category { Name = "legume" };

            p1.Category = c1;

            //intialiseur d'objet : 
            Product p2 = new Product
            {
                //bech direct te5dem bihom w te7ot 9ad ma te7eb fi 3outh ma constructeur yorbetek 

                Name = "fraise",
                Price = 1.5,
                Description = " mal à l'aise",
                DateProd = DateTime.Now


            };

            p2.Category = c;
          //  Console.WriteLine(p2.IntCategory(c));




            Provider provider = new Provider
            {
                Password = "aaaaaa",
                ConfirmPassword = "aaaaaa",
                UserName= "adcead",
                Email= "adcead",
                
                //get w set yede5mou min 8ir ma te9olehom
            };
            //Provider provider2 = new Provider
            //{
            //    Password = "adcead",
            //    ConfirmPassword = "adcead",
            //    UserName = "user2",
            //    Email = "bbbbb@gmail.com",
            //    IsApproved = true
            //    //get w set yede5mou min 8ir ma te9olehom
            //};


           //  Console.WriteLine(provider.IsApproved);
            //passage par reference
          //  Provider.SetIsApproved(provider);
           // Console.WriteLine(provider.IsApproved);


            //passage par valeur
            // Provider.SetIsApproved(provider.Password, provider.ConfirmPassword, provider.IsApproved);  //héthi 7abetech
            //Console.WriteLine(provider.IsApproved);
            //cw tab tab

            //forcer le passage par ref
            int i = 3;
            int j = 2;
            int k = 1;

            // p2.Calculer(i, j,ref k);
            // Console.WriteLine("k : "+k);

            //   Console.WriteLine("la methode login avec 2 params");
            //  Console.WriteLine(provider.Login("user1", "adcead"));   //yemchi ye5dem 3la instance provider kol

            //  Console.WriteLine("la methode login avec 3 params");
            //  Console.WriteLine(provider.Login("user1","adcead","user1@gmail.com"));


            //tester method getmytype
            Product product = new Product();
            Chemical chemical = new Chemical();

            chemical.Name = "azzaz";
            Biological biological = new Biological();

            biological.Name = "zzeze";
                
           // product.GetMyType();
           // chemical.GetMyType();
           // biological.GetMyType();

            // provider.Products = new List<Product>() { p1};
            provider.Products.Add(p1);

            provider.Products.Add(p2);
         // provider.getDetails();   

      //   provider.GetProdcuts("Name", "Pomme");
      //  provider.GetProdcuts("DateProd", "2012/11/23");

       //     Console.WriteLine("DisplayUsernameAndEmail");
           ManageProvider mp = new ManageProvider();
           mp.providers.Add(provider);
            //   mp.providers.Add(provider2);

            //  mp.DisplayUsernameAndEmail("user2");

            ////delegue test
            //ManageProduct mprod = new ManageProduct();
            //mprod.lsProduct = new List<Product> { p1, p2 };
            //foreach (Product prr in mprod.FindProduct('P'))

            //{
            //    Console.WriteLine(prr);

            //}

            ////  les methode d extension
            //string s = "bonjour";
            //Console.WriteLine(s.ToUpper());

            //s.UpperName();  //string extension



            //provider.UpperNameProvider();
            //Console.WriteLine(provider.UserName);


            //ki te7eb ta5le9 table min 8ir immigration ama moch mansou7 biha
            //   PSContext ctx = new PSContext();
            DataBaseFactory dbf = new DataBaseFactory();
            UnitOfWork uow = new UnitOfWork(dbf);
            ServiceProduct serviceProduct = new ServiceProduct(uow);
            ServiceCategory serviceCategory = new ServiceCategory(uow);

            serviceProduct.Add(p2);
          //  ctx.Products.Add(p1);
            // ctx.Chemicals.Add(chemical);
            // ctx.Biologicals.Add(biological);
          //  ctx.SaveChanges();

            //foreach (Product pr in serviceProduct.GetAll())
            //{
            //    Console.WriteLine("prodcut"+pr.Name+"category"+pr.Category.Name);
            //}

            serviceProduct.Commit();

        }
    }
}
