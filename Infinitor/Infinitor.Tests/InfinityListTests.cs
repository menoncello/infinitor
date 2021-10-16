using Infinitor.Strategies;

namespace Infinitor
{
    public partial class InfinityListTests
    {
        private InfinityList<int> list = null!;

        private void CreateList(IGenerationStrategy<int>? strategy = null) =>
            list = new InfinityList<int>(strategy ?? new DummyStrategy());
    }
}