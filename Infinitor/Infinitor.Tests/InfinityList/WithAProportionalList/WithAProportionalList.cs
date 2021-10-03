using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace Infinitor
{
    public partial class InfinityRandomNumbersTests
    {
        public class WithAProportionalList : InfinityRandomNumbersTests
        {
            private const int Repeats = 1000;
            private List<ProportionalItem<int>> proportionalList = null!;
            private Dictionary<int, int> count = null!;

            [SetUp]
            public void Setup()
            {
                proportionalList = new List<ProportionalItem<int>>
                                   {
                                       new(2, 1),
                                       new(1, 2)
                                   };
                list = new InfinityRandomNumbers(proportionalList);
                count = new Dictionary<int, int>
                        {
                            {1, 0},
                            {2, 0}
                        };
            }

            [Test]
            public void TheSumOfBothCountsMustBeTheRepeats()
            {
                for (var i = 0; i < Repeats; i++)
                    count[list[i]]++;
                
                (count[1] + count[2]).Should().Be(Repeats);
            }

            [Test]
            public void Item2MustBeNearTwoThirdsAnd1MusBeNearOneThirdOfRepeats()
            {
                for (var i = 0; i < Repeats; i++)
                    count[list[i]]++;
                
                count[1].Should().BeGreaterOrEqualTo(566).And.BeLessOrEqualTo(766);
                count[2].Should().BeGreaterOrEqualTo(333).And.BeLessOrEqualTo(433);
            }

            [Test]
            public void Item1612ShouldBe2ThatMustHave3000ModEquals2000()
            {
                list[1612].Should().Be(2);
            }
        }
    }
}