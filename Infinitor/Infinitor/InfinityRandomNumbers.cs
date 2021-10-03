using System;
using System.Collections.Generic;
using System.Linq;

namespace Infinitor
{
    public class InfinityRandomNumbers : InfinityList<int>
    {
        public InfinityRandomNumbers(IEnumerable<int>? randomItems = null, int limitItems = int.MaxValue)
            : base(randomItems, limitItems)
        {
        }

        protected override int GetGeneratedItem(int index)
        {
            var rnd = new Random(index);
            
            var value = rnd.Next();
            var max = Math.Min(RandomItems.Length, LimitItems);
            
            return RandomItems.Any()
                ? RandomItems[value % max]
                : value % LimitItems;
        }
    }
}