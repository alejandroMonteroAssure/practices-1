using RefactoringExerciseI.Inventory;
namespace RefactoringExerciseI.Inventory
{
    public interface IItemUpdaterFactory
    {
        IItemQualityUpdater GetUpdater(Item item);
    }
}
