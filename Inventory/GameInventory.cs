namespace RefactoringExerciseI.Inventory
{
    public class GameInventory
    {
        private readonly IList<Item> _items;

        public GameInventory(IList<Item> Items)
        {
            _items = Items;
        }

        public void UpdateQuality()
        {
            for (var index = 0; index < _items.Count; index++)
            {
                if (_items[index].Name != "Aged Brie" && _items[index].Name != "Backstage passes to a Pokemon Gym concert")
                {
                    if (_items[index].Quality > 0 && _items[index].Name != "Sulfuras, Hand of Ragnaros")
                    {
                        _items[index].Quality--;
                    }
                }
                else
                {
                    if (_items[index].Quality < 50)
                    {
                        _items[index].Quality++;

                        if (_items[index].Name == "Backstage passes to a Pokemon Gym concert")
                        {
                            if (_items[index].SellIn < 11 && _items[index].Quality < 50)
                            {
                                _items[index].Quality++;
                            }

                            if (_items[index].SellIn < 6 && _items[index].Quality < 50)
                            {
                                _items[index].Quality++;
                            }
                        }
                    }
                }

                if (_items[index].Name != "Sulfuras, Hand of Ragnaros")
                {
                    _items[index].SellIn--;
                }

                if (_items[index].SellIn < 0)
                {
                    if (_items[index].Name != "Aged Brie")
                    {
                        if (_items[index].Name != "Backstage passes to a Pokemon Gym concert")
                        {
                            if (_items[index].Quality > 0 && _items[index].Name != "Sulfuras, Hand of Ragnaros")
                            {
                                _items[index].Quality--;
                            }
                        }
                        else
                        {
                            _items[index].Quality = _items[index].Quality - _items[index].Quality;
                        }
                    }
                    else
                    {
                        if (_items[index].Quality < 50)
                        {
                            _items[index].Quality++;
                        }
                    }
                }
            }
        }
    }
}
