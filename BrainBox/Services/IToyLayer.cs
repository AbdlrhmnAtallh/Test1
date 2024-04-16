using BrainBox.Models;

namespace BrainBox.Services
{
    public interface IToyLayer
    {
        void Add(Toy toy);
        List<Toy> All();
        void Edit(Toy toy);
        void remove(Toy toy);
    }
}