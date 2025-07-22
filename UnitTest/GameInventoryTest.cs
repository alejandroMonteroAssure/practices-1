using System.Runtime.CompilerServices;
using NuGet.Frameworks;
using NUnit.Framework;
using RefactoringExerciseI.Inventory;
using RefactoringExerciseI;

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

            var updaterFactory = new ItemUpdaterFactory();
            GameInventory app = new(Items, updaterFactory);

            app.UpdateQuality();

            Assert.That(Items[0].Name, Is.EqualTo("Backstage passes to a Pokemon Gym concert"));
            Assert.That(Items[0].Quality, Is.EqualTo(expectedQuality));
            Assert.That(Items[0].SellIn, Is.EqualTo(expectedSellIn));
        }

        [Test]
        public void Sulfuras()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 10 } };
            var updaterFactory = new ItemUpdaterFactory();
            GameInventory app = new(Items, updaterFactory);
            app.UpdateQuality();

            Assert.That(Items[0].Name, Is.EqualTo("Sulfuras, Hand of Ragnaros"));
            Assert.That(Items[0].Quality, Is.EqualTo(10));
            Assert.That(Items[0].SellIn, Is.EqualTo(10));
        }

        [Test]
        public void BlockA_AgedBrie_QualityExceedFifty()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 5, Quality = 7 } };
            var updaterFactory = new ItemUpdaterFactory();
            GameInventory app = new(Items, updaterFactory);
            app.UpdateQuality();

            Assert.That(Items[0].Name, Is.EqualTo("Aged Brie"));
            Assert.That(Items[0].Quality, Is.EqualTo(8));
            Assert.That(Items[0].SellIn, Is.EqualTo(4));
        }

        [Test]
        [TestCase(10, 50, 50, 9)]
        public void BlockA_AgedBrie_EqualsToFifty(int initialSellIn, int initialQuality, int expectedQuality, int expectedSellIn)
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = initialSellIn, Quality = initialQuality } };
            var updaterFactory = new ItemUpdaterFactory();
            GameInventory app = new(Items, updaterFactory);
            app.UpdateQuality();

            Assert.That(Items[0].Name, Is.EqualTo("Aged Brie"));
            Assert.That(Items[0].Quality, Is.EqualTo(expectedQuality));
            Assert.That(Items[0].SellIn, Is.EqualTo(expectedSellIn));
        }

        [Test]
        public void Foo()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            var updaterFactory = new ItemUpdaterFactory();
            GameInventory app = new(Items, updaterFactory);
            app.UpdateQuality();

            Assert.That(Items[0].Name, Is.EqualTo("foo"));
            Assert.That(Items[0].Quality, Is.EqualTo(0));
            Assert.That(Items[0].SellIn, Is.EqualTo(-1));
        }

        [Test]
        public void EmptyList()
        {
            IList<Item> Items = new List<Item> { };
            var updaterFactory = new ItemUpdaterFactory();
            GameInventory app = new(Items, updaterFactory);
            app.UpdateQuality();
            Assert.That(Items, Is.Empty);
        }

        [Test]
        [TestCase(10, 20, 19, 9, "Normal Item")]
        [TestCase(1, 1, 0, 0, "Another Item")]
        public void BlockA_NormalItem_DecreasesQuality(int initialSellIn, int initialQuality, int expectedQuality, int expectedSellIn, string itemName)
        {
            IList<Item> Items = new List<Item> { new Item { Name = itemName, SellIn = initialSellIn, Quality = initialQuality } };
            var updaterFactory = new ItemUpdaterFactory();
            GameInventory app = new(Items, updaterFactory);
            app.UpdateQuality();
            Assert.That(Items[0].Name, Is.EqualTo(itemName));
            Assert.That(Items[0].Quality, Is.EqualTo(expectedQuality));
            Assert.That(Items[0].SellIn, Is.EqualTo(expectedSellIn));
        }

        [Test]
        [TestCase(10, 0, 0, 9, "Normal Item At Zero Quality")]
        public void BlockA_NormalItem_QualityDoesNotDecreaseBelowZero(int initialSellIn, int initialQuality, int expectedQuality, int expectedSellIn, string itemName)
        {
            IList<Item> Items = new List<Item> { new Item { Name = itemName, SellIn = initialSellIn, Quality = initialQuality } };
            var updaterFactory = new ItemUpdaterFactory();
            GameInventory app = new(Items, updaterFactory);
            app.UpdateQuality();

            Assert.That(Items[0].Name, Is.EqualTo(itemName));
            Assert.That(Items[0].Quality, Is.EqualTo(expectedQuality));
            Assert.That(Items[0].SellIn, Is.EqualTo(expectedSellIn));
        }

        [Test]
        [TestCase(15, 20, 21, 14, "Backstage passes to a Pokemon Gym concert")]
        [TestCase(10, 20, 22, 9, "Backstage passes to a Pokemon Gym concert")]
        [TestCase(5, 20, 23, 4, "Backstage passes to a Pokemon Gym concert")]
        [TestCase(11, 20, 21, 10, "Backstage passes to a Pokemon Gym concert")]
        [TestCase(6, 20, 22, 5, "Backstage passes to a Pokemon Gym concert")]
        [TestCase(6, 49, 50, 5, "Aged Brie")]
        public void BlockA_BackstagePasses_And_AgedBries_IncreasesQualityByRules(int initialSellIn, int initialQuality, int expectedQuality, int expectedSellIn, string itemName)
        {
            IList<Item> Items = new List<Item> { new Item { Name = itemName, SellIn = initialSellIn, Quality = initialQuality } };
            var updaterFactory = new ItemUpdaterFactory();
            GameInventory app = new(Items, updaterFactory);
            app.UpdateQuality();

            Assert.That(Items[0].Name, Is.EqualTo(itemName));
            Assert.That(Items[0].Quality, Is.EqualTo(expectedQuality));
            Assert.That(Items[0].SellIn, Is.EqualTo(expectedSellIn));
        }

        [Test]
        [TestCase(10, 50, 50, 9, "Backstage passes to a Pokemon Gym concert")]
        [TestCase(5, 50, 50, 4, "Aged Brie")]
        public void BlockA_BackstagePasses_QualityDoesNotExceedFifty(int initialSellIn, int initialQuality, int expectedQuality, int expectedSellIn, string itemName)
        {
            IList<Item> Items = new List<Item> { new Item { Name = itemName, SellIn = initialSellIn, Quality = initialQuality } };
            var updaterFactory = new ItemUpdaterFactory();
            GameInventory app = new(Items, updaterFactory);
            app.UpdateQuality();

            Assert.That(Items[0].Name, Is.EqualTo(itemName));
            Assert.That(Items[0].Quality, Is.EqualTo(expectedQuality));
            Assert.That(Items[0].SellIn, Is.EqualTo(expectedSellIn));
        }

        [Test]
        [TestCase(0, 49, 50, -1)]
        public void BlockC_AgedBrie_NegativeSellIn(int initialSellIn, int initialQuality, int expectedQuality, int expectedSellIn)
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = initialSellIn, Quality = initialQuality } };
            var updaterFactory = new ItemUpdaterFactory();
            GameInventory app = new(Items, updaterFactory);
            app.UpdateQuality();

            Assert.That(Items[0].Name, Is.EqualTo("Aged Brie"));
            Assert.That(Items[0].Quality, Is.EqualTo(expectedQuality));
            Assert.That(Items[0].SellIn, Is.EqualTo(expectedSellIn));
        }

        [Test]
        [TestCase(0, 50, 50, -1)]
        public void BlockC_AgedBrie_NegativeSellIn_SecondCase(int initialSellIn, int initialQuality, int expectedQuality, int expectedSellIn)
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = initialSellIn, Quality = initialQuality } };
            var updaterFactory = new ItemUpdaterFactory();
            GameInventory app = new(Items, updaterFactory);
            app.UpdateQuality();

            Assert.That(Items[0].Name, Is.EqualTo("Aged Brie"));
            Assert.That(Items[0].Quality, Is.EqualTo(expectedQuality));
            Assert.That(Items[0].SellIn, Is.EqualTo(expectedSellIn));
        }

        [Test]
        [TestCase(0, 50, 0, -1)]
        public void BlockC_BackstagePasses_NegativeSellIn_SecondCase(int initialSellIn, int initialQuality, int expectedQuality, int expectedSellIn)
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a Pokemon Gym concert", SellIn = initialSellIn, Quality = initialQuality } };
            var updaterFactory = new ItemUpdaterFactory();
            GameInventory app = new(Items, updaterFactory);
            app.UpdateQuality();

            Assert.That(Items[0].Name, Is.EqualTo("Backstage passes to a Pokemon Gym concert"));
            Assert.That(Items[0].Quality, Is.EqualTo(expectedQuality));
            Assert.That(Items[0].SellIn, Is.EqualTo(expectedSellIn));
        }

        [Test]
        [TestCase(-1, 10, 8, -2, "Not sulfuras")]
        [TestCase(-5, 2, 0, -6, "Not sulfuras")]
        public void BlockC_ExpiredNormalItem_QualityDecreasesTwice(int initialSellIn, int initialQuality, int expectedQuality, int expectedSellIn, string itemName)
        {
            IList<Item> Items = new List<Item> { new Item { Name = itemName, SellIn = initialSellIn, Quality = initialQuality } };
            var updaterFactory = new ItemUpdaterFactory();
            GameInventory app = new(Items, updaterFactory);
            app.UpdateQuality();

            Assert.That(Items[0].Name, Is.EqualTo(itemName));
            Assert.That(Items[0].Quality, Is.EqualTo(expectedQuality));
            Assert.That(Items[0].SellIn, Is.EqualTo(expectedSellIn));
        }



    }
}