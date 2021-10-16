using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace Infinitor.Strategies
{
    public partial class ProportionalStrategyTests
    {
        public class WithTwoItems : ProportionalStrategyTests
        {
            private List<ProportionalItem<int>> proportionalList = null!;

            [SetUp]
            public void SetUp()
            {
                proportionalList = new List<ProportionalItem<int>>
                {
                    new(2, 1),
                    new(1, 2)
                };

                CreateProportionalStrategy(proportionalList);
            }
            
            [Test]
            [TestCase(0, 1)]
            [TestCase(1999, 1)]
            [TestCase(2000, 2)]
            [TestCase(2999, 2)]
            [TestCase(3000, 1)]
            public void Generate_TheSumOfBothCountsMustBeTheRepeats(int randomNumber, int expected)
            {
                var result = strategy.Generate(randomNumber);
                result.Should().Be(expected);
            }

            [Test]
            public void Generate_ProportionalStrategyIsInheritedGenerationStrategy()
            {
                strategy.Should().BeAssignableTo<IGenerationStrategy<int>>();
            }
        }
    }
}