using Microsoft.AspNetCore.Mvc.Rendering;
using shoppayEntieys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shoppayEntieys.Dto
{
    public class ProductDto
    {
        public product product { get; set; }
        public IEnumerable<SelectListItem> CategoryList { get; set; }
    }
}
