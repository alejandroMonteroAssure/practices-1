using RefactoringExerciseI.Inventory;

namespace RefactoringExerciseI.Inventory
{
    public class GameInventory
    {
        private readonly IList<Item> _items;
        private readonly IItemUpdaterFactory _updaterFactory;

        public GameInventory(IList<Item> Items, IItemUpdaterFactory updaterFactory)
        {
            _items = Items;
            _updaterFactory = updaterFactory;
        }

        public void UpdateQuality()
        { 
            foreach (var item in _items)
            {
                var updater = _updaterFactory.GetUpdater(item);
                updater.Update(item);
            }
        }
    }
}
