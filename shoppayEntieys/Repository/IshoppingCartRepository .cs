using shoppayEntieys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shoppayEntieys.Repository
{
    public interface IshoppingCartRepository : IgenericRepository<ShoppinCart>
    {
		int IncreaseCount(ShoppinCart shoppinCart, int Count);
		int decreaseCount(ShoppinCart shoppinCart, int Count);

		IEnumerable<ShoppinCart> GetAll(Func<ShoppinCart, bool> filter, string Includeword = null);



	}
}
