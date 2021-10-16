using System;
using System.Collections.Generic;
using System.Linq;

namespace Infinitor.Strategies
{
    public class ProportionalStrategy<T> : IGenerationStrategy<T>
    {
        private readonly IList<ProportionalItem<T>> items;
        private readonly int total;

        public ProportionalStrategy(List<ProportionalItem<T>> proportionalItems)
        {
            if (!proportionalItems.Any())
                throw new ArgumentOutOfRangeException(nameof(proportionalItems));
            
            items = proportionalItems
                .OrderByDescending(x => x.Chance)
                .ToList();
            total = proportionalItems.Sum(x => x.FullIntChance);
        }

        public T Generate(int randomNumber)
        {
            var modded = randomNumber % total;
            var selected = items[0].Value;

            for (var i = 1; !IsPicked(modded, i); modded -= items[i++ - 1].FullIntChance)
                selected = items[i].Value;

            return selected;
        }

        private bool IsPicked(int modded, int i) =>
            modded < items[i - 1].FullIntChance;
    }
}