using System;
using System.Collections.Generic;
using System.Linq;

namespace Infinitor.Strategies
{
    public class ListStrategy<T> : IGenerationStrategy<T>
    {
        private readonly T[] list;

        public ListStrategy(IEnumerable<T> list)
        {
            this.list = (list ?? throw new ArgumentNullException(nameof(list))).ToArray();
            if (!list.Any()) throw new ArgumentOutOfRangeException(nameof(list));
        }

        public T Generate(int randomNumber)
        {
            return list[randomNumber % list.Length];
        }
    }
}