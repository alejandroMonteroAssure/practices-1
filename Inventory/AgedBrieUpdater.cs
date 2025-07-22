using RefactoringExerciseI.Inventory;
namespace RefactoringExerciseI.Inventory
{
    public class AgedBrieUpdater : IItemQualityUpdater
    {
        public void Update(Item item)
        {
            if(item.Quality < 50)
            {
                item.Quality++;
            }

            item.SellIn--;

            if(item.SellIn < 0)
            {
                if (item.Quality < 50)
                {
                    item.Quality++;
                }
            }
        }
    }
}
