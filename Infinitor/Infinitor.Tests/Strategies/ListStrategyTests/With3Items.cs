using FluentAssertions;
using NUnit.Framework;

namespace Infinitor.Strategies
{
    public partial class ListStrategyTests
    {
        public class With3Items : ListStrategyTests
        {
            [SetUp]
            public void SetUpWithItems()
            {
                CreateStrategy(new[] {3, 6, 9});
            }

            [Test]
            [TestCase(0, 3)]
            [TestCase(1, 6)]
            [TestCase(2, 9)]
            [TestCase(3, 3)]
            public void Generate_ShouldReturnSelectedItem(int randomNumber, int expected)
            {
                strategy.Generate(randomNumber).Should().Be(expected);
            }
        }
    }
}