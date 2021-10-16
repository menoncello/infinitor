using System;
using System.Collections.Generic;
using System.Linq;

namespace Infinitor.Strategies
{
    public class ProportionalStrategy<T> : IGenerationStrategy<T>
    {
        private readonly IList<ProportionalItem<T>> proportionalItems;
        private readonly int total;

        public ProportionalStrategy(List<ProportionalItem<T>> proportionalItems)
        {
            if (!proportionalItems.Any())
                throw new ArgumentOutOfRangeException(nameof(proportionalItems));
            
            this.proportionalItems = proportionalItems
                .OrderByDescending(x => x.Chance)
                .ToList();
            total = proportionalItems.Sum(x => x.FullIntChance);
        }

        public T Generate(int randomNumber)
        {
            var modded = randomNumber % total;
            T selected = default!;
            
            foreach (var item in proportionalItems)
            {
                if (modded < item.FullIntChance)
                {
                    selected = item.Value;
                    break;
                }

                modded -= item.FullIntChance;
            }

            return selected;
        }
    }
}