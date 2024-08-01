using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shoppayEntieys.Models
{
    public class product
    {
        public int productId { get; set; }
        [Required]
        public string productName { get; set; }

        public string productDescription { get; set; }

        //Data Annotation 
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal price { get; set; }
        public string Image { get; set; }

        public Category Category { get; set; }

        [Required]
        public int CategoryId { get; set; }


    }
}
