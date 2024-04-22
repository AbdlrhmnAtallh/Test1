using BrainBox.Common;
using System.ComponentModel.DataAnnotations;

namespace BrainBox.Models
{

    public enum GenderType
    {
        Boys,
        Girls,
        All
    }
    public class Toy
    {
        [Required(ErrorMessage ="Id is Required")]
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Name is Required")]
        [StringLength(50, ErrorMessage = "The Name Field Must Be a Maximum of 50 Characters")]
        [NoNumbers]
        public string Name { get; set; }
        [StringLength(100, ErrorMessage = "The Name Field Must Be a Maximum of 100 Characters")]
        public string? Discription { get; set; }
        [Required(ErrorMessage ="Price is Reqiured")]

        public decimal Price { get; set; }
        [EnumDataType(typeof(GenderType))]
        public string GenderFor { get; set; }
        public bool InStock { get; set; }
        public string? ImageFileName { get; set; }
        public IFormFile? Image { get; set; }
        public  List<int>? OrderId {get; set; }


    }
}
