using PS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PS.Services
{
    public class ManageProvider
    {
        //tawa bech ne5demou kil 3ebed
        /**
  * LinQ ( ychabah l sql)
  * 
  * Methode prédefinis (lambda expressions)
  * 
 */
        


        public List<Provider> providers { get; set; } = new List<Provider>();
       public List<Provider> GetProviderByName(string name)
        {//bech ne5demou bil link : sql inversé   //link teraja3 par default enumerable donc zidouha tolist()
            //List<Provider> req= (from p in providers
            //                    where p.UserName.Contains(name)
            //                    select p).ToList();
            //return req;
            var req2 = providers.Where(p => p.UserName.Contains(name));
            return req2.ToList();
        }


        public List<String> GetProviderEmailByName(string name)
        {//bech ne5demou bil link
         //List<String> req = (from p in providers
         //                      where p.UserName.Contains(name)
         //                      select p.Email).ToList();
         //return req;
            return  providers.Where(p => p.UserName.Contains(name)).Select(p=>p.Email).ToList();
           


        }

        public void DisplayUsernameAndEmail(String name) //void 5ater structure non connu
        {
            //var req = (from p in providers
            //                    where p.UserName.Contains(name)
            //                    select (p.UserName,p.Email)).ToList();
            //foreach(var p in req)
            //    Console.WriteLine(p);

            var req2 = providers.Where(p => p.UserName.Contains(name)).Select(p => (p.Email,p.UserName));
                 foreach(var p in req2)
                  Console.WriteLine(p);
                 //testé jaweha behi
        }
        public Provider GetFirstProviderByName(string name)
        {
            var req = (from p in providers
                       where p.UserName.StartsWith(name)
                       select p);
                     return req.First();
        }



    }
}
