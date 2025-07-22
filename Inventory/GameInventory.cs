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
            //quality updater
            for (var index = 0; index < _items.Count; index++)
            {

                /*
                
                So there are 4 types of updaters
                Aged brie updater
                Backstage passed updater
                Sulfuras, Hand of Ragnaros
                Other types - general types
                

                The easiest one to depict here is the general type or base type:

                if(_items[index].Quality > 0) then: _items[index].Quality--;
                _items[index].SellIn--;

                if (_items[index].Quality > 0 )
                {
                    _items[index].Quality--;
                }

                Aged Brie updater:

                if (_items[index].Quality < 50)
                {
                    _items[index].Quality++;
                }

                _items[index].SellIn--;

                if(items[index].SellIn < 0){
                    if (_items[index].Quality < 50)
                    {
                        _items[index].Quality++;
                    }
                }

                Backstage passes:

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

                    _items[index].SellIn--;

                    if (_items[index].SellIn < 0) 
                        _items[index].Quality = _items[index].Quality - _items[index].Quality;
                        its the same as saying items.Quality = 0;
                {

                THERE IS NO STRATEGY FOR SULFURAS, HAND OF RAGNAROS, CAN BE GENERIC


                */

                // it is noticeable that for any name S such that s does not belong to
                // {Aged Brie, Sulfuras, hand of ragnaros and Backstage passes to a Pokemon Gym concert}
                // then the rule:
                // item.Quality-- will always be true. and of course, must have Quality > 0;
                if (_items[index].Name != "Aged Brie" && _items[index].Name != "Backstage passes to a Pokemon Gym concert")
                {
                    if (_items[index].Quality > 0 && _items[index].Name != "Sulfuras, Hand of Ragnaros")
                    {
                        _items[index].Quality--;
                    }
                }
                else
                {
                    //sub block for aged bries or backstage passes
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

                //sell in updater, applied to all distinct to sulfutas hand of ragnaros, this is general, 

                if (_items[index].Name != "Sulfuras, Hand of Ragnaros")
                {
                    _items[index].SellIn--;
                }

                //another strange quality updater based on the SellIn parameter.
                //only enter here if SellIn is less than 0
                // 

                if (_items[index].SellIn < 0)
                {
                    //only objects not named Aged Brie can enter this if
                    if (_items[index].Name != "Aged Brie")
                    {
                        
                        if (_items[index].Name != "Backstage passes to a Pokemon Gym concert")
                        {
                            //Updater for any other kind of Item not named Backstage Passes to a Pokemon Gym Concert 
                            //lets also note that for any other item different from the ones belonging to set "Default"
                            // which sellin < 0, then the following rule is true:
                            if (_items[index].Quality > 0 && _items[index].Name != "Sulfuras, Hand of Ragnaros")
                            {
                                _items[index].Quality--;
                            }
                        }
                        //Quality updater for Backstage passes to a Pokemon Gym Concert
                        else
                        {
                            _items[index].Quality = _items[index].Quality - _items[index].Quality;
                        }
                    }
                    //quality updater for Aged Brie
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
