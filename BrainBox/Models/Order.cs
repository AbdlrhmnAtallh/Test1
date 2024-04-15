namespace BrainBox.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int OrderNo { get; set; }
        public List<int> ToysIds { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
