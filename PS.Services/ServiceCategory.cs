using PS.data;
using PS.Data.Infrastructure;
using PS.Domain;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Services
{
    public class ServiceCategory : Service<Category>, IServiceCategorycs

    {
        public ServiceCategory(IUnitOfWork uow):base(uow)
        {

        }
    }
}
