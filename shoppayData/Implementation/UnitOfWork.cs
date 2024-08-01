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
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ShopDbcontext _context;
        public UnitOfWork(ShopDbcontext context) 
        {
            _context = context;

            Categorie = new CategoryRepostory(context);
            product = new ProductRepostory(context);
            ApplicationUser = new ApplicationUserRepostory(context);
            IshoppingCart = new ShoppinCartRepostory(context);
            OrderDetail = new OrderDetailRepostory(context);
            OrderHeader = new OrderHeaderRepostory(context);


        }

        public IcategorieRepository Categorie { get; private set; }

        public IProductRepository product { get; private set; }

        public IshoppingCartRepository IshoppingCart { get; private set; }

		public IOrderDetailRepository OrderDetail { get; private set; }

		public IOrderHeaderRepository OrderHeader { get; private set; }

		public IApplicationUserRepository ApplicationUser { get; private set; }

		public int Complete()
        {
          return  _context.SaveChanges();
        }

        public void Dispose()
        {
             _context.Dispose();
        }
    }
}
