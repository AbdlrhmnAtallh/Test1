using System.ComponentModel.DataAnnotations;

namespace BrainBox.Models
{
    public class Order
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int OrderNo { get; set; }
        public List<int> ToysIds { get; set; }
        [Required]
        public decimal TotalPrice { get; set; }
    }
}
