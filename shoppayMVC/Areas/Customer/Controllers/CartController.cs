using Aspose.Cells;
using Microsoft.AspNetCore.Mvc;
using shoppayEntieys.Dto;
using shoppayEntieys.Models;
using shoppayEntieys.Repository;
using SkiaSharp;
using System.Security.Claims;

namespace shoppayMVC.Areas.Customer.Controllers
{
	[Area("Customer")]
	//Customer/Cart/Sumary
	public class CartController : Controller
	{
		private IUnitOfWork _unitOfWork;
		public  ShoppinCartDto ShoppinCartDto { get; set; }

		public int TotalCarts { get; set; }
		public CartController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		[Area("Customer")]
		public IActionResult Index()
		{
			var claimsIdentity = (ClaimsIdentity)User.Identity;
			var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
			ShoppinCartDto = new ShoppinCartDto()
			{
				CartList = _unitOfWork.IshoppingCart.GetAll(u=>u.ApplicationUserId == claim.Value, Includeword:"product")
			};
			//  total cart
			foreach (var item in ShoppinCartDto.CartList)
			{
				ShoppinCartDto.TotalCarts += (item.Count + item.product.price);
			}
			return View(ShoppinCartDto);
		}

		public IActionResult plus(int cartid)
		{
			var shoppingcart = _unitOfWork.IshoppingCart.GetFirstorDefault(x => x.ShoppinCartId == cartid);
			if (shoppingcart != null)
			{
				_unitOfWork.IshoppingCart.IncreaseCount(shoppingcart, 1);
				_unitOfWork.Complete();
			}
			return RedirectToAction("Index");
		}

		public IActionResult minus(int cartid)
		{
			var shoppingcart = _unitOfWork.IshoppingCart.GetFirstorDefault(x => x.ShoppinCartId == cartid);
			if (shoppingcart != null)
			{
				if (shoppingcart.Count > 1)
				{
					_unitOfWork.IshoppingCart.decreaseCount(shoppingcart, 1);
				}
				else
				{
					_unitOfWork.IshoppingCart.Remove(shoppingcart);
				}
				_unitOfWork.Complete();
			}
			return RedirectToAction("Index");
		}


		[HttpPost]
		public IActionResult Remove(int cartid)
		{
			var shoppingcart = _unitOfWork.IshoppingCart.GetFirstorDefault(x => x.ShoppinCartId == cartid);
			if (shoppingcart != null)
			{
				_unitOfWork.IshoppingCart.Remove(shoppingcart);
				_unitOfWork.Complete();
			}
			return RedirectToAction("Index");
		}

		///Customer/Cart/Sumary
		[HttpPost]
		public IActionResult Sumary(ShoppinCartDto shoppinCartDto)
		{
			var claimsIdentity = (ClaimsIdentity)User.Identity;
			var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

			ShoppinCartDto shoppingCartDto = new ShoppinCartDto()
			{
				CartList = _unitOfWork.IshoppingCart
				.GetAll(u => u.ApplicationUserId == claim.Value,
				Includeword: "Product"),
				orderHeader = new()
			};

			shoppingCartDto.orderHeader.applicationUser = _unitOfWork.ApplicationUser.GetFirstorDefault(x => x.Id == claim.Value);

			shoppingCartDto.orderHeader.Name = shoppingCartDto.orderHeader.applicationUser.Name;
			shoppingCartDto.orderHeader.Address = shoppingCartDto.orderHeader.applicationUser.Address;
			shoppingCartDto.orderHeader.city = shoppingCartDto.orderHeader.applicationUser.city;
			shoppingCartDto.orderHeader.Phone = shoppingCartDto.orderHeader.applicationUser.PhoneNumber;

			// Calculate total cart
			foreach (var item in shoppingCartDto.CartList)
			{
				shoppingCartDto.TotalCarts += item.Count * item.product.price;
			}

			return View(shoppingCartDto);

  		}
	}
}
