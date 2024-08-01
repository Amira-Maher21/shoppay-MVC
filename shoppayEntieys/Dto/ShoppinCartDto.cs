using shoppayEntieys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shoppayEntieys.Dto
{
	public class ShoppinCartDto
	{
		public IEnumerable<ShoppinCart> CartList { get; set; }
		public OrderHeader orderHeader { get; set; }
		public decimal TotalCarts { get; set; }
	}
}
