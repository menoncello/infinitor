using Infinitor.Factories;

namespace Infinitor.Strategies
{
    public partial class CappedStrategyTests
    {
        private CappedStrategy<int> strategy = null!;

        private void CreateStrategy(IRandomFactory<int>? factory = null, int capped = 1) => 
            strategy = new CappedStrategy<int>(factory ?? new DummyFactory(), capped);
    }
}