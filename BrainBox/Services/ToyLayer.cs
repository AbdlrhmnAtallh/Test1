using BrainBox.Models;
namespace BrainBox.Services
{
    public class ToyLayer : IToyLayer
    {
        BrainBoxDbContext Context;
        //public static List<Toy> Toys = new List<Toy>();

       public ToyLayer(BrainBoxDbContext _context)
        {
            Context = _context;
        }


        public void Add(Toy toy)
        {
            Context.Add(toy);
            Context.SaveChanges();
        }

        public void Edit(Toy toy)
        {
            var item = Context.Toys.FirstOrDefault(e => e.Id == toy.Id);
            item.Name = toy.Name;
            item.Price = toy.Price;
            item.Discription = toy.Discription;
            item.InStock = toy.InStock;
        }

        public List<Toy> All()
        {
            return Context.Toys.ToList();
        }

        public void remove(Toy toy)
        {
            Context.Remove(toy);
            Context.SaveChanges();
        }
    }
}
