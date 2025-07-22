using RefactoringExerciseI.Inventory;

namespace RefactoringExerciseI
{

    public static class Program
    {
        public static void Main()
        {
            Console.WriteLine("Here we are!");

            IList<Item> Items = new List<Item>{
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new Item {Name = "Sulfuras, Hand of sRagnaros", SellIn = -1, Quality = 80},
                new Item
                {
                    Name = "Backstage passes to a Pokemon Gym concert",
                    SellIn = 15,
                    Quality = 20
                },
                new Item
                {
                    Name = "Backstage passes to a Pokemon Gym concert",
                    SellIn = 10,
                    Quality = 49
                },
                new Item
                {
                    Name = "Backstage passes to a Pokemon Gym concert",
                    SellIn = 5,
                    Quality = 49
                },
				new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            };

            var updaterFactory = new ItemUpdaterFactory();
            var app = new GameInventory(Items, updaterFactory);


            for (int index = 0; index < 31; index++)
            {
                Console.WriteLine($"-------- day {index} --------");
                Console.WriteLine("name, sellIn, quality");
                for (int pivot = 0; pivot < Items.Count; pivot++)
                {
                    Console.WriteLine(Items[pivot]);
                }
                Console.WriteLine("");
                app.UpdateQuality();
            }
        }
    }
}