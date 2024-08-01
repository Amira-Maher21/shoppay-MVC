using shoppayEntieys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shoppayEntieys.Repository
{
    public interface IOrderDetailRepository : IgenericRepository<OrderDetail>
    {
        void Update(OrderDetail OrderDetail);

     }
}
