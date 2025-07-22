using RefactoringExerciseI.Inventory;
namespace RefactoringExerciseI.Inventory
{
    public class DefaultItemUpdater : IItemQualityUpdater
    {
        public void Update(Item item)
        {
            if(item.Quality > 0)
            {
                item.Quality--;
            }

            item.SellIn--;

            if(item.SellIn < 0)
            {
                if(item.Quality > 0)
                {
                    item.Quality--;
                }
            }
        }
    }
}
