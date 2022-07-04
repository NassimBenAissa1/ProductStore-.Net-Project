using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PS.Domain
{
    public class Provider:Concept
    {


        //public string ConfirmPassword { get; set; }
         public DateTime DateCreated { get; set; }


        public string Email { get; set; }


        [Key]
        public int ProviderKey { get; set; }


        public Boolean IsApproved { get; set; }


        //public string Paswword { get; set; }
        private string password;

        [DataType(DataType.Password)]
        [Required(ErrorMessage ="required")]
        [MinLength(8,ErrorMessage ="min lenghy 8 char")]
        public string Password
        {
            get { return password; }
            set
            {
                if (value.Length < 20 && value.Length > 5)
                {
                    password = value;
                }
                else Console.WriteLine("enter a valid password !");
            }
        }
        private string confirmPassword;

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "required")]
        [MinLength(8, ErrorMessage = "min lenghy 8 char")]
        [NotMapped]
        [Compare("password",ErrorMessage ="must match password")]  //ta5rar fi ay wa7da min methodes
        public string ConfirmPassword
        {
            get { return confirmPassword; }
            set
            {
                if (value == password)
                {
                    confirmPassword = value;
                }
                else Console.WriteLine("re-enter Confirm password !");
            }
        }

        public string UserName { get; set; }

        public virtual List<Product> Products { get; set; } = new List<Product>();

        public static void SetIsApproved(Provider p)
        {
            //if(p.password== p.confirmPassword)
            //{
            //    p.isApproved = true;
            //}
            //else
            //{
            //    p.isApproved = false;
            //}
            //houni par refrence yetsama ahawka 3leh ca changé 
            p.IsApproved = (p.password == p.confirmPassword);
        }
        public static void SetIsApproved(string password, string confirmation, Boolean IsApproved)
        {
            // IsApproved = password.Equals(confirmation);
            IsApproved = (password == confirmation);
            //to9e3ed false 5ater passage par valuer ( on a passé des valeurs ) ya5le9 image ba3ed ma 5edemena biha yarja3 lil aslou(garde sa vameur initial
        }

        //polymorphisme

        //  public bool Login(String user,String password)
        //   {
        //       return user == UserName && password==Password;

        //   }



        public bool Login(String user, String password,String email=null)
        {
            if(email==null)
                   return user == UserName && password==Password;

                return user == UserName && password == Password && email == Email;

        }

        public override void getDetails()
        {
            Console.WriteLine("nom"+UserName);
            //  for(int i=0; i<Products.Count; i++)
            //  {
            //       Console.WriteLine(Products[i]);
            // }
            foreach(Product p in Products)
            Console.WriteLine(p);
        }


        /**
         * displays products selon l'attribut passé 
         */
        public void GetProdcuts(string filtertype,string filterValue)
        {
            switch(filtertype)
            {
                case "Name":
                    foreach(Product p in Products)
                        if(p.Name.Equals(filterValue))
                         Console.WriteLine(p);
                    break;


                case "DateProd":
                    foreach (Product p in Products)
                        if (p.DateProd == DateTime.Parse(filterValue))
                             Console.WriteLine(p);

                    break;

                case "Price":
                    foreach (Product p in Products)
                        if (p.Price == double.Parse(filterValue))
                            Console.WriteLine(p);

                    break;
            }

        }
        public void GetProducts()
        {

        }

    }
}
