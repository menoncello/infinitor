using FluentAssertions;
using Infinitor.Factories;
using NUnit.Framework;

namespace Infinitor.Strategies
{
    public partial class CappedStrategyTests
    {
        public class CappedWith4 : CappedStrategyTests
        {
            [Test]
            [TestCase(0, 0)]
            [TestCase(1, 1)]
            [TestCase(2, 2)]
            [TestCase(3, 3)]
            [TestCase(4, 0)]
            public void Generate_ShouldBeEqualToExpected(int randomNumber, int expected)
            {
                CreateStrategy(new IntegerFactory(), 4);
                strategy.Generate(randomNumber).Should().Be(expected);
            }
        }
    }
}