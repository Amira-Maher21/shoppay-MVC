using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shoppayEntieys.Models
{
    public class ShoppinCart
    {

        public int ShoppinCartId { get; set; }
        public int productId { get; set; }
        [ValidateNever]
        public product product { get; set; }

        [Range(1, 100, ErrorMessage = "you must enter value between 1 to 100")]
        public int Count { get; set; }
        public string ApplicationUserId { get; set; }
        [ValidateNever]
        public  ApplicationUser applicationUser{ get; set; }

    }
}
