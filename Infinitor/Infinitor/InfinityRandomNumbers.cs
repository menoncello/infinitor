using System;
using System.Linq;

namespace Infinitor
{
    public class InfinityRandomNumbers : InfinityList<int>
    {
        protected override int GetGeneratedItem(int index)
        {
            var rnd = new Random(index);
            
            var value = rnd.Next();
            var max = Math.Min(RandomItems.Length, LimitItems);
            
            return RandomItems.Any()
                ? RandomItems[value / max]
                : value % LimitItems;
        }
    }
}