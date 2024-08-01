using Aspose.Cells.Drawing;
using Microsoft.AspNetCore.Mvc;
using shoppayEntieys.Models;
using shoppayEntieys.Repository;

namespace shoppayMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        //Category/Index
        public IActionResult Index()
        {
            var categoy = _unitOfWork.Categorie.GetAll();
            return View(categoy);
        }
        //Category/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View(new Category());
        }
        //Category/Create

        //Category/SaveCategory

        [HttpPost]
        public IActionResult SaveCategory(Category catg)
        {
            if (catg.CategoryName != null)
            {
                // _.categories.Add(catg);
                _unitOfWork.Categorie.Add(catg);

                // _Context.SaveChanges();
                _unitOfWork.Complete();

                TempData["Creeate"] = "Data Has Creeate Succesfully";
                return RedirectToAction("Index");

            }
            else
            {
                return View("Create", catg);

            }

        }

        //Category/EditeCategory
        public IActionResult EditeCategory(int id)
        {

            //Category category = _Context.categories.FirstOrDefault(p => p.CategoryId == id);
            var category = _unitOfWork.Categorie.GetFirstorDefault(x => x.CategoryId == id);
            return View(category);
        }


        //Category/SaveEdite
        public IActionResult SaveEdite(int id, Category Create)
        {


            if (Create != null)
            {

                //category.CategoryName = Create.CategoryName;
                //   category.CategoryTime = Create.CategoryTime;
                //   category.Description = Create.Description;
                _unitOfWork.Categorie.Update(Create);
                // _Context.SaveChanges();
                _unitOfWork.Complete();

                TempData["Update"] = "Data Has Update Succesfully";

                return RedirectToAction("Index");



            }

            return View("EditeCategory", Create);

        }
        [HttpGet]
        public IActionResult DeleteCategory(int id)
        {
            if (id == null | id == 0)
            {
                NotFound();
            }
            // Category category = _Context.categories.FirstOrDefault(p => p.CategoryId == id);
            var category = _unitOfWork.Categorie.GetFirstorDefault(x => x.CategoryId == id);

            return View(category);
        }
        //SaveDelete

        [HttpPost]
        public IActionResult SaveDelete(int id)
        {
            var category = _unitOfWork.Categorie.GetFirstorDefault(x => x.CategoryId == id);

            if (category == null)
            {
                NotFound();
            }
            _unitOfWork.Categorie.Remove(category);
            // _Context.SaveChanges();
            _unitOfWork.Complete();
            TempData["Deletee"] = "Data Has Deletee Succesfully";
            return RedirectToAction("Index");
        }
    }
}
