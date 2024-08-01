using shoppayData.Data;
using shoppayEntieys.Models;
using shoppayEntieys.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shoppayData.Implementation
{
    public class ApplicationUserRepostory : GenericRepository<ApplicationUser>, IApplicationUserRepository
	{
        private readonly ShopDbcontext _context;
        public ApplicationUserRepostory(ShopDbcontext context) : base(context)
        {
            _context = context;
        }

     }
}
