using PS.data;
using PS.Data.Infrastructure;
using PS.Domain;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PS.Services
{
    public class ServiceProduct : Service<Product>, IServiceProduct
    {
        public ServiceProduct(IUnitOfWork uow):base(uow)
        {

        }
        public void Deleteold()
        {
            Delete(p => (DateTime.Now -p.DateProd).TotalDays > 365);
        }

        public IEnumerable<Product> FindMost5ExpenseiceProds()
        {
            return GetMany().OrderByDescending(p => p.Price).Take(5);//first
        }

        public IEnumerable<Product> GetProductsByClient(Client c)
        {
            DataBaseFactory dbf = new DataBaseFactory();
            UnitOfWork uow = new UnitOfWork(dbf);
            ServiceAchat sa = new ServiceAchat(uow);
            return sa.GetMany(a => a.ClientFK == c.Cin).Select(a => a.Product);
        }

        public float UnavalaibleProductPercentage()
        {
            int nbPorduct = GetMany().Count();
            int nbUnavailable = GetMany(p => p.Quantity == 0).Count();
            return (float) (nbUnavailable / nbPorduct) * 100;
        }

    }
}
