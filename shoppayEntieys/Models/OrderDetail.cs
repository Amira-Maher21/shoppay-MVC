using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shoppayEntieys.Models
{
	public class OrderDetail
	{
		public int OrderDetailId { get; set; }

		public int Count { get; set; }

		[Column(TypeName = "decimal(18, 2)")]
		public decimal Price { get; set; }


		[ValidateNever]
		public OrderHeader OrderHeader { get; set; }
		public int OrderHeaderId { get; set; }

		[ValidateNever]
		public product product { get; set; }
		public int productId { get; set; }

	}
}
