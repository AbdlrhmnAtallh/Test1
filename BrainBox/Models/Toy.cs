namespace BrainBox.Models
{
    public class Toy
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Discription { get; set; }
        
        public decimal Price { get; set; }
        public string GenderFor { get; set; }
        public bool InStock { get; set; }
        public  List<int> OrderId {get; set; }


    }
}
