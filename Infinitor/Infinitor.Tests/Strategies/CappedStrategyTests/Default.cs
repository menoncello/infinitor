using System;
using FluentAssertions;
using NUnit.Framework;

namespace Infinitor.Strategies
{
    public partial class CappedStrategyTests
    {
        public class Default : CappedStrategyTests
        {
            [Test]
            public void Constructor_InheritsFromGenerationStrategy()
            {
                CreateStrategy();
                strategy.Should().BeAssignableTo<IGenerationStrategy<int>>();
            }

            [Test]
            public void Generate_ReturnMustBeZero() => strategy.Generate(0).Should().Be(0);

            [Test]
            [TestCase(-1)]
            [TestCase(0)]
            public void Constructor_ThrowsExceptionWhenNumberIsZeroOrNegative(int capped)
            {
                Action act = () => CreateStrategy(capped: capped);
                act.Should().Throw<ArgumentOutOfRangeException>();
            }
        }
    }
}