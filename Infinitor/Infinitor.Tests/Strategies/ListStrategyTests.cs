using System.Collections.Generic;

namespace Infinitor.Strategies
{
    public partial class ListStrategyTests
    {
        private ListStrategy<int> strategy = null!;

        private void CreateStrategy(IEnumerable<int> list)
        {
            strategy = new ListStrategy<int>(list);
        }
    }
}