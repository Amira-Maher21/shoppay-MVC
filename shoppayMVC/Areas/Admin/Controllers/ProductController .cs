using Aspose.Cells.Drawing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using shoppayEntieys.Dto;
using shoppayEntieys.Models;
using shoppayEntieys.Repository;

namespace shoppayMVC.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment )
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        #region  Create
        //Admin/Product/ViewCreate
        [HttpGet]
        public IActionResult ViewCreate()
        {
            ProductDto ProductDto = new ProductDto()
            {
                product = new product(),
                CategoryList = _unitOfWork.Categorie.GetAll().Select(x => new SelectListItem
                {
                    Text = x.CategoryName,
                    Value = x.CategoryId.ToString()
                })

            };
            return View(ProductDto);
        }
        //Product/SaveProduct

        [HttpPost]
        public IActionResult ViewCreate(ProductDto ProductDto, IFormFile file)
        {



            string RootPath = _webHostEnvironment.WebRootPath;
            if (file != null)
            {
                string filename = Guid.NewGuid().ToString();
                var Uplode = Path.Combine(RootPath, @"Images/Products");
                var ext = Path.GetExtension(file.FileName);

                using (var filestrem = new FileStream(Path.Combine(Uplode, filename + ext), FileMode.Create))
                {
                    file.CopyTo(filestrem);

                }
                ProductDto.product.Image = @"Images/Products/" + filename + ext;
            }

            // _.categories.Add(catg);
            _unitOfWork.product.Add(ProductDto.product);

            // _Context.SaveChanges();
            _unitOfWork.Complete();

            TempData["Creeate"] = "Data Has Creeate Succesfully";
            return RedirectToAction("index");


            //return View(ProductDto.product);

        }

        #endregion

        #region GetAll
        //Product/Create     
        [HttpGet]
        public IActionResult index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Getdata()
        {
            var Prod = _unitOfWork.product.GetAll(Includeword: "Category");

            return Json(new { data = Prod });
        }
        #endregion


        #region Edit
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ProductDto productDto = new ProductDto()
            {
                product = _unitOfWork.product.GetFirstorDefault(d => d.productId == id),
                CategoryList = _unitOfWork.Categorie.GetAll().Select(d => new SelectListItem
                {
                    Text = d.CategoryName,
                    Value = d.CategoryId.ToString()
                })
            };
            return View(productDto);
        }

        [HttpPost]
        public IActionResult Edit(ProductDto productDto, IFormFile? file)
        {
            
                string RootPath = _webHostEnvironment.WebRootPath;
            if (file != null)
            {
                string filename = Guid.NewGuid().ToString();
                var Uplode = Path.Combine(RootPath, @"Images/Products");
                var ext = Path.GetExtension(file.FileName);


                // Delete old image if exists
                if (productDto.product.Image != null)
                {
                    var oldimg = Path.Combine(RootPath, productDto.product.Image.TrimStart('\\'));
                    if (System.IO.File.Exists(oldimg))
                    {
                        System.IO.File.Delete(oldimg);
                    }
                }


                // Upload new image
                using (var filestrem = new FileStream(Path.Combine(Uplode, filename + ext), FileMode.Create))
                {
                    file.CopyTo(filestrem);

                }
                productDto.product.Image = @"Images/Products/" + filename + ext;
            }


            _unitOfWork.product.Update(productDto.product);
            _unitOfWork.Complete();


            TempData["Update"] = "Data has Updated Successfully";
            return RedirectToAction("index");
         }

        #endregion



        #region delete

        [HttpDelete]
        public IActionResult Delete(int? id)
        {

            var productIndb = _unitOfWork.product.GetFirstorDefault(d => d.productId == id);
            if (productIndb == null)
            {
                return Json(new { success = false, Message = "Error while Deleting" });
            }
            _unitOfWork.product.Remove(productIndb);
            //Remove image
            var oldimg =Path.Combine(_webHostEnvironment.WebRootPath, productIndb.Image.TrimStart('\\'));
            if (System.IO.File.Exists(oldimg))
            {
                System.IO .File.Delete(oldimg);
            }
            //save
            _unitOfWork.Complete ();
            return Json(new { success = true, Message = "file has been Deleted" });
        }

        #endregion

    }
}
