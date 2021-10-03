using System.Collections.Generic;

namespace Infinitor
{
    public class InfinityListRandomNumbers : InfinityList<int>
    {
        public InfinityListRandomNumbers()
        {
        }

        public InfinityListRandomNumbers(IEnumerable<ProportionalItem<int>> proportional) : base(proportional)
        {
        }

        public InfinityListRandomNumbers(IEnumerable<int> randomItems) : base(randomItems)
        {
        }

        public InfinityListRandomNumbers(int cappedValue) : base(cappedValue)
        {
        }

        protected override int GetGeneratedCustomItem(int randomValue)
        {
            return randomValue;
        }
    }
}