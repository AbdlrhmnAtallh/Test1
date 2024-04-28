using BrainBox.Models;
namespace BrainBox.Services
{
    public class OrderLayer : IOrderLayer
    {
        //public static List<Order> Orders = new List<Order>();

        BrainBoxDbContext Context;
        public OrderLayer(BrainBoxDbContext _context)
        {
            Context = _context;
        }

        private decimal CalculateTotalPrice(List<int> toyIds)
        {
            // Calculate total price based on toy IDs or any other logic
            decimal totalPrice = 0;

            // Example logic: Summing prices of toys with given IDs
            foreach (var toyId in toyIds)
            {
                var toy = Context.Toys.FirstOrDefault(t => t.Id == toyId);
                if (toy != null)
                {
                    totalPrice += toy.Price;
                }
            }

            return totalPrice;
        }


        public void Add(Order order)
        {
            Context.Add(order);
            Context.SaveChanges();
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
            return Context.Orders.ToList();
        }

        public void Remove(Order order)
        {
            Context.Orders.Remove(order);
            Context.SaveChanges();
        }


    }
}
