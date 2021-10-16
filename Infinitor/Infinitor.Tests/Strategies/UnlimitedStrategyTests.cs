using System;
using FluentAssertions;
using Infinitor.Factories;
using NUnit.Framework;

namespace Infinitor.Strategies
{
    public class UnlimitedStrategyTests
    {
        private UnlimitedStrategy<int> strategy = null!;

        private void CreateStrategy(IRandomFactory<int>? factory = null)
        {
            strategy = new UnlimitedStrategy<int>(factory ?? new DummyFactory());
        }

        [Test]
        public void UnlimitedStrategyMustInheritsFromGenerationStrategy()
        {
            CreateStrategy();
            strategy.Should().BeAssignableTo<IGenerationStrategy<int>>();
        }

        [Test]
        public void Constructor_ThrowsExceptionWhenFactoryIsNull()
        {
            Action act = () => _ = new UnlimitedStrategy<int>(null!);
            act.Should().Throw<ArgumentNullException>();
        }

        [Test]
        [TestCase(0)]
        [TestCase(1000)]
        [TestCase(123123)]
        public void Generate_WhenPassingNumberResultMustBeTheSame(int randomNumber)
        {
            CreateStrategy(new IntegerFactory());
            strategy.Generate(randomNumber).Should().Be(randomNumber);
        }
    }
}