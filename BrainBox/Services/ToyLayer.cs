using BrainBox.Models;
namespace BrainBox.Services
{
    public class ToyLayer : IToyLayer
    {
        public static List<Toy> Toys = new List<Toy>();

        public ToyLayer()
        {
            // Adding five toys of Toy class type
            Toys.Add(new Toy
            {
                Id = 1,
                Name = "Toy 1",
                Discription = "This toy added by system you can delete it",
                Price = 10.99m,
                GenderFor = GenderType.Boys.ToString(),
                InStock = true,
                OrderId = new List<int>()
            });

            Toys.Add(new Toy
            {
                Id = 2,
                Name = "Toy 2",
                Discription = "This toy added by system you can delete it",
                Price = 15.49m,
                GenderFor = GenderType.Girls.ToString(),
                InStock = false,
                OrderId = new List<int>()
            });

            // Add three more toys similarly...

            // Toy 3
            Toys.Add(new Toy
            {
                Id = 3,
                Name = "Toy 3",
                Discription = "This toy added by system you can delete it",
                Price = 12.99m,
                GenderFor = GenderType.All.ToString(),
                InStock = false,
                OrderId = new List<int>()
            });

            // Toy 4
            Toys.Add(new Toy
            {
                Id = 4,
                Name = "Toy 4",
                Discription = "This toy added by system you can delete it",
                Price = 8.99m,
                GenderFor = GenderType.Boys.ToString(),
                InStock = true,
                OrderId = new List<int>()
            });

            // Toy 5
            Toys.Add(new Toy
            {
                Id = 5,
                Name = "Toy 5",
                Discription = "This toy added by system you can delete it",
                Price = 20.99m,
                GenderFor = GenderType.Girls.ToString(),
                InStock = true,
                OrderId = new List<int>()
            });
        }


        public void Add(Toy toy)
        {
            Toys.Add(toy);
        }

        public void Edit(Toy toy)
        {
            var item = Toys.FirstOrDefault(e => e.Id == toy.Id);
            item.Name = toy.Name;
            item.Price = toy.Price;
            item.Discription = toy.Discription;
            item.InStock = toy.InStock;
        }

        public List<Toy> All()
        {
            return Toys.ToList();
        }

        public void remove(Toy toy)
        {
            Toys.Remove(toy);
        }
    }
}
