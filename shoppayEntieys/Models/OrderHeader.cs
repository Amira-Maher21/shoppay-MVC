using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace shoppayEntieys.Models
{
	public class OrderHeader
	{
		public int OrderHeaderId { get; set; }

		[ValidateNever]
		public ApplicationUser applicationUser { get; set; }
		public string ApplicationUserId { get; set; }


		public DateTime OrderDate { get; set; } = DateTime.Now;
		public DateTime ShippingDate { get; set; } = DateTime.Now;

		public decimal TotalPrice { get; set; }= 0;

		public string? OrderStatus { get; set; } 
		public string? PaymentStatus { get; set; }


		public string? TrackingNumber { get; set; }

		public string? Carrier { get; set;}  

		public DateTime PymentDate { get; set; }

		//Stripe Properties
		public string? PymentIntentId { get; set; }
		public string? SessionId { get; set; }

		//Data of User
 		public string Name { get; set; }
		public string Address { get; set; }
		public string city { get; set; }
		public string Phone { get; set; }
	}
}

 
