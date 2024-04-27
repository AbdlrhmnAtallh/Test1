using BrainBox.Models;
namespace BrainBox.Services
{
    public class OrderLayer : IOrderLayer
    {
        public static List<Order> Orders = new List<Order>();

        //public OrderLayer()
        //{
        //    // Adding orders to the Orders list
        //    Orders.Add(new Order
        //    {
        //        Id = 1,
        //        OrderNo = 1001,
        //        ToysIds = new List<int> { 1, 3, 5 }, // Example toy IDs
        //        TotalPrice = CalculateTotalPrice(new List<int> { 1, 3, 5 }) // Example toy IDs
        //    });

        //    Orders.Add(new Order
        //    {
        //        Id = 2,
        //        OrderNo = 1002,
        //        ToysIds = new List<int> { 2, 4 }, // Example toy IDs
        //        TotalPrice = CalculateTotalPrice(new List<int> { 2, 4 }) // Example toy IDs
        //    });

        //    // Add more orders similarly...
        //}

        private decimal CalculateTotalPrice(List<int> toyIds)
        {
            // Calculate total price based on toy IDs or any other logic
            decimal totalPrice = 0;

            // Example logic: Summing prices of toys with given IDs
            foreach (var toyId in toyIds)
            {
                var toy = ToyLayer.Toys.FirstOrDefault(t => t.Id == toyId);
                if (toy != null)
                {
                    totalPrice += toy.Price;
                }
            }

            return totalPrice;
        }


        public void Add(Order order)
        {
            Orders.Add(order);
        }

        //public void Edit(Order order)
        //{
        //    var item = Orders.FirstOrDefault(e => e.Id == order.Id);
        //    item.OrderNo = order.OrderNo;
        //    item.TotalPrice = order.TotalPrice;
        //    item.Id = order.Id;
        //    item.ToysIds = order.ToysIds;
        //}

        public List<Order> All()
        {
            return Orders.ToList();
        }

        public void Remove(Order order)
        {
            Orders.Remove(order);
        }


    }
}
