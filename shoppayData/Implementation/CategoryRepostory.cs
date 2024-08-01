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
    public class CategoryRepostory : GenericRepository<Category>,IcategorieRepository
    {
        private readonly ShopDbcontext _context;
        public CategoryRepostory(ShopDbcontext context) : base(context)
        {
            _context = context;
        }

        public void Update(Category category)
        {

            var categoryInDb = _context.categories.FirstOrDefault(m=>m.CategoryId == category.CategoryId);
            if (categoryInDb != null)
            {
                categoryInDb.CategoryName = category.CategoryName;
                categoryInDb .Description = category.Description;
                categoryInDb .CategoryTime = DateTime.Now;
            }

        }
    }
}
