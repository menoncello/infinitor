using System.Collections.Generic;

namespace Infinitor.Strategies
{
    public partial class ProportionalStrategyTests
    {
        private ProportionalStrategy<int> strategy = null!;

        private void CreateProportionalStrategy(
            List<ProportionalItem<int>>? proportionalList = null)
        {
            strategy = new ProportionalStrategy<int>(proportionalList!);
        }
    }
}