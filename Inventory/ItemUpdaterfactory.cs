using RefactoringExerciseI.Inventory;
namespace RefactoringExerciseI.Inventory
{
    public class ItemUpdaterFactory: IItemUpdaterFactory
    {
        public IItemQualityUpdater GetUpdater(Item item)
        {
            return item.Name switch
            {
                "Aged Brie" => new AgedBrieUpdater(),
                "Backstage passes to a Pokemon Gym concert" => new BackstagePassesUpdater(),
                "Sulfuras, Hand of Ragnaros" => new SulfurasUpdater(),
                _ => new DefaultItemUpdater()
            };
        }
    }
}
