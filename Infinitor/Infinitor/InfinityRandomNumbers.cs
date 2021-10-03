using System;
using System.Collections.Generic;
using System.Linq;

namespace Infinitor
{
    public class InfinityRandomNumbers : InfinityList<int>
    {
        public InfinityRandomNumbers(IEnumerable<ProportionalItem<int>>? proportional = null,
            IEnumerable<int>? randomItems = null, int limitItems = int.MaxValue)
            : base(proportional, randomItems, limitItems)
        {
        }

        protected override int GetGeneratedCustomItem(int randomValue)
        {
            return randomValue % LimitItems;
        }
    }
}