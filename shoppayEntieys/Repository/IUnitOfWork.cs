using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shoppayEntieys.Repository
{
    public interface IUnitOfWork:IDisposable
    {
        IcategorieRepository Categorie { get; }
        IProductRepository product { get; }
        IshoppingCartRepository IshoppingCart { get; } 

        IOrderDetailRepository OrderDetail { get; }

        IOrderHeaderRepository OrderHeader { get; }
		IApplicationUserRepository ApplicationUser {  get; }
		int Complete();
    }
}
