using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace Infinitor
{
    public partial class InfinityListRandomNumbersTests
    {
        public class WithAListWith3Items : InfinityListRandomNumbersTests
        {
            private Dictionary<int, int> randomItems = null!;

            [SetUp]
            public void Setup()
            {
                randomItems = new Dictionary<int, int>()
                              {
                                  { 3, 0 },
                                  { 6, 0 },
                                  { 9, 0 }
                              };
                list = new InfinityListRandomNumbers(randomItems: randomItems.Keys);
            }

            [Test]
            public void MustOnlyHasThis3Items()
            {
                const int repeats = 1000;
                for (var i = 0; i < repeats; i++)
                    randomItems[list[i]]++;

                (randomItems[3] + randomItems[6] + randomItems[9]).Should().Be(repeats);
            }
        }
    }
}