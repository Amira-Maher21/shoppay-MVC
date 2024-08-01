using Microsoft.EntityFrameworkCore;
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
    public class ShoppinCartRepostory : GenericRepository<ShoppinCart>,IshoppingCartRepository
    {
        private readonly ShopDbcontext _context;
        public ShoppinCartRepostory(ShopDbcontext context) : base(context)
        {
            _context = context;
        }

		public int decreaseCount(ShoppinCart shoppinCart, int Count)
		{
			shoppinCart.Count -= Count;
			return shoppinCart.Count;
		}

		public int IncreaseCount(ShoppinCart shoppinCart, int Count)
		{
			shoppinCart.Count += Count;
			return shoppinCart.Count;
		}
		public IEnumerable<ShoppinCart> GetAll(Func<ShoppinCart, bool> filter, string Includeword = null)
		{
			IQueryable<ShoppinCart> query = _context.shoppinCarts;

			if (!string.IsNullOrWhiteSpace(Includeword))
			{
				query = query.Include(Includeword);
			}

			if (filter != null)
			{
				query = query.Where(filter).AsQueryable();
			}

			return query.ToList();
		}
	}
}
