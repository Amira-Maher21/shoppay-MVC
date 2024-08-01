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
    public class OrderHeaderRepostory : GenericRepository<OrderHeader>,IOrderHeaderRepository
	{
        private readonly ShopDbcontext _context;
        public OrderHeaderRepostory(ShopDbcontext context) : base(context)
        {
            _context = context;
        }

        public void Update(OrderHeader OrderHeader)
        {

            _context.orderHeaders.Update(OrderHeader);

        }

		 

		public void UpdateOrderStatus(int id, string OrderStatus, string PaymentStatus)
		{
         var OrderHeaderDB=  _context.orderHeaders.FirstOrDefault(x => x.OrderHeaderId == id);
  		if (OrderHeaderDB != null) 
            {
				OrderHeaderDB.OrderStatus = OrderStatus;
                if(PaymentStatus!= null )
                {
					OrderHeaderDB.PaymentStatus = PaymentStatus;

				}

			}
        
        }
	}
}
