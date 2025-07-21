using NUnit.Framework;
using RefactoringExerciseI.Inventory;

namespace RefactoringExerciseI.UnitTest
{
    [TestFixture]
    public class GameInventoryTest
    {
        [Test]
        [TestCase(0, 0, 0, -1)]
        [TestCase(10, 40, 42, 9)]
        [TestCase(12, 40, 41, 11)]
        public void BackstagePasses(int sellIn, int quality, int expectedQuality, int expectedSellIn)
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a Pokemon Gym concert", SellIn = sellIn, Quality = quality } };
            GameInventory app = new(Items);
            app.UpdateQuality();

            Assert.That(Items[0].Name, Is.EqualTo("Backstage passes to a Pokemon Gym concert"));
            Assert.That(Items[0].Quality, Is.EqualTo(expectedQuality));
            Assert.That(Items[0].SellIn, Is.EqualTo(expectedSellIn));
        }

        [Test]
        public void Sulfuras()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 10 } };
            GameInventory app = new(Items);
            app.UpdateQuality();

            Assert.That(Items[0].Name, Is.EqualTo("Sulfuras, Hand of Ragnaros"));
            Assert.That(Items[0].Quality, Is.EqualTo(10));
            Assert.That(Items[0].SellIn, Is.EqualTo(10));
        }

        [Test]
        public void AgedBrie()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 5, Quality = 7 } };
            GameInventory app = new(Items);
            app.UpdateQuality();

            Assert.That(Items[0].Name, Is.EqualTo("Aged Brie"));
            Assert.That(Items[0].Quality, Is.EqualTo(8));
            Assert.That(Items[0].SellIn, Is.EqualTo(4));
        }

        [Test]
        public void Foo()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GameInventory app = new(Items);
            app.UpdateQuality();

            Assert.That(Items[0].Name, Is.EqualTo("foo"));
            Assert.That(Items[0].Quality, Is.EqualTo(0));
            Assert.That(Items[0].SellIn, Is.EqualTo(-1));
        }
    }
}