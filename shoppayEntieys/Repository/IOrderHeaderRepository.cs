using shoppayEntieys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shoppayEntieys.Repository
{
    public interface IOrderHeaderRepository : IgenericRepository<OrderHeader>
    {
        void Update(OrderHeader orderHeader);

        void UpdateOrderStatus(int id , string OrderStatus, string PaymentStatus);
    }
}
