using Immobilien.DataAccess.Abstract;
using Immobilien.DataAccess.Context;
using Immobilien.DataAccess.Repositories;
using Immobilien.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Immobilien.DataAccess.EntityFramework
{
    public class EfCounterDal : GenericRepository<Counter>, ICounterDal
    {
        public EfCounterDal(ImmobilienContext context) : base(context)
        {
        }
    }
}
