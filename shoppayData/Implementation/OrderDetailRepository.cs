using shoppayData.Data;
using shoppayEntieys.Models;
using shoppayEntieys.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace shoppayData.Implementation
{
    public class OrderDetailRepostory : GenericRepository<OrderDetail>, IOrderDetailRepository
	{
        private readonly ShopDbcontext _context;
        public OrderDetailRepostory(ShopDbcontext context) : base(context)
        {
            _context = context;
        }

		public void Update(OrderDetail OrderDetail)
		{
			_context.orderDetails.Update(OrderDetail);
		}
	}
}
