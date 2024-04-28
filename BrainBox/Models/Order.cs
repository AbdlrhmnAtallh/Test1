using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrainBox.Models
{
	[Table("Order", Schema = "dbo")]
	public class Order
    {
        [Key]
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? OrderName { get; set; }
        public string? ClientName { get; set; }
        
        public decimal TotalPrice { get; set; }
    }
}
