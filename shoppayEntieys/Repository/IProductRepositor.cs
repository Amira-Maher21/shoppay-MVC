using shoppayEntieys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shoppayEntieys.Repository
{
    public interface IProductRepository:IgenericRepository<product>
    {
        void Update(product product);


    }
}
