using System;
using Infinitor.Factories;

namespace Infinitor.Strategies
{
    public class CappedStrategy<T> : IGenerationStrategy<T>
    {
        private readonly int capped;
        private readonly IRandomFactory<T> factory;

        public CappedStrategy(IRandomFactory<T> factory, int capped)
        {
            this.factory = factory;
            this.capped = capped > 0
                ? capped
                : throw new ArgumentOutOfRangeException(nameof(capped));
        }

        public T Generate(int randomNumber) => factory.Generate(randomNumber % capped);
    }
}