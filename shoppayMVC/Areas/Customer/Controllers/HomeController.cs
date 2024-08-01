using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shoppayEntieys.Models;
using shoppayEntieys.Repository;
using System.Security.Claims;

namespace shoppayMVC.Areas.Customer.Controllers
{
	[Area("Customer")]
	public class HomeController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		public HomeController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		#region getall
		public IActionResult Index()
		{
			var product = _unitOfWork.product.GetAll();
			return View(product);
		}
		#endregion

		#region Details
		//asp-route-Cartid="@Model.ShoppinCartId
		public IActionResult Details(int Id)
		{
			var product = _unitOfWork.product.GetFirstorDefault(d => d.productId == Id);
			if (product == null)
			{
				return NotFound(); // Handle the case where the product doesn't exist
			}

			ShoppinCart shoppinCart = new ShoppinCart()
			{
				productId = product.productId, // Ensure this is set correctly
				Count = 1,
				product = product // Include the product entity
			};
			return View(shoppinCart);
		}

		#endregion

		#region ShoppinCart

		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize]
		public IActionResult Details(ShoppinCart shoppinCart)
		{
			var claimsIdentity = (ClaimsIdentity)User.Identity;
			var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
			if (claim == null)
			{
				return Unauthorized(); // Handle the case where the user is not authenticated
			}

			shoppinCart.ApplicationUserId = claim.Value;

			// Ensure the ProductId is correctly set
			var product = _unitOfWork.product.GetFirstorDefault(p => p.productId == shoppinCart.productId);
			if (product == null)
			{
				return NotFound(); // Handle the case where the product doesn't exist
			}
			ShoppinCart Cartobj = _unitOfWork.IshoppingCart.GetFirstorDefault(
				U=>U.ApplicationUserId == claim.Value && U.productId == shoppinCart.productId
				);
            if (Cartobj == null)
            {
				_unitOfWork.IshoppingCart.Add(shoppinCart);
            }
            else
            {
				_unitOfWork.IshoppingCart.IncreaseCount(Cartobj, shoppinCart.Count);
            }

            try
			{
				_unitOfWork.Complete();
			}
			catch (DbUpdateException ex)
			{
				// Log the exception details
				Console.WriteLine(ex.InnerException?.Message);
				// Optionally, handle specific exceptions or rethrow
				throw;
			}

			return RedirectToAction("Index");
		}

		#endregion
	}
}
