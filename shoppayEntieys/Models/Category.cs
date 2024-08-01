using System.ComponentModel.DataAnnotations;

namespace shoppayEntieys.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required]
        public string CategoryName { get; set; }
        public string Description { get; set; }

        public DateTime CategoryTime { get; set; }= DateTime.Now;
    }
}
