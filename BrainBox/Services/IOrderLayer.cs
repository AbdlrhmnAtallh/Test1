using BrainBox.Models;

namespace BrainBox.Services
{
    public interface IOrderLayer
    {
        void Add(Order order);
        List<Order> All();
        void Edit(Order order);
        void Remove(Order order);
    }
}