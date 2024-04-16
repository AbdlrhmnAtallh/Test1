namespace BrainBox.Models
{
    public class Context
    {
        public  List<Toy> Toys { get; set; }
        public  List<Order> Orders { get; set; }

        public Context()
        {
            Toys = new List<Toy>();
            Toy toy = new Toy();
            toy.Id = 001;
            toy.Name = "ToyA";
            toy.Price = 10;
            toy.Discription = " This Toy Added by system you can deleteit";
            toy.InStock = true;
            toy.OrderId = new List<int>();
            toy.OrderId.Add(001);
            Toys.Add(toy);

            Orders = new List<Order>();
            Order order = new Order();
            order.Id = 001;
            order.OrderNo = 1;
            order.TotalPrice = 0;
            order.ToysIds = new List<int>();
            order.ToysIds.Add(1);
            Orders.Add(order);

        }

    }
}
