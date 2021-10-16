using System;
using Infinitor.Factories;

namespace Infinitor.Strategies
{
    public class UnlimitedStrategy<T> : IGenerationStrategy<T>
    {
        private readonly IRandomFactory<T> factory;

        public UnlimitedStrategy(IRandomFactory<T> factory)
        {
            this.factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        public T Generate(int randomNumber)
        {
            return factory.Generate(randomNumber);
        }
    }
}