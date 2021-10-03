using System.Collections.Generic;

namespace Infinitor
{
    public class InfinityRandomNumbers : InfinityList<int>
    {
        public InfinityRandomNumbers()
        {
        }

        public InfinityRandomNumbers(IEnumerable<ProportionalItem<int>> proportional) : base(proportional)
        {
        }

        public InfinityRandomNumbers(IEnumerable<int> randomItems) : base(randomItems)
        {
        }

        public InfinityRandomNumbers(int cappedValue) : base(cappedValue)
        {
        }

        protected override int GetGeneratedCustomItem(int randomValue)
        {
            return randomValue;
        }
    }
}