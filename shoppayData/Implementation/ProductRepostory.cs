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
    public class ProductRepostory : GenericRepository<product>,IProductRepository
    {
        private readonly ShopDbcontext _context;
        public ProductRepostory(ShopDbcontext context) : base(context)
        {
            _context = context;
        }

    

        public void Update(product product)
        {
            var ProductInDb = _context.products.FirstOrDefault(m => m.productId == product.productId);
            if (ProductInDb != null)
            {
                ProductInDb.productName = product.productName;
                ProductInDb.productDescription = product.productDescription;
                ProductInDb.price = product.price;
                ProductInDb.Image = product.Image;
                ProductInDb.CategoryId = product.CategoryId;
                
            }
        }
    }
}
