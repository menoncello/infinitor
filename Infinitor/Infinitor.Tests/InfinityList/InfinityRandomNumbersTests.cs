using System;
using System.Collections;
using System.Linq;
using Infinitor.Tools;
using NUnit.Framework;

namespace Infinitor
{
    public class InfinityRandomNumbersTests
    {
        private InfinityRandomNumbers list = null!;

        public class WithNoLimits : InfinityRandomNumbersTests
        {
            [SetUp]
            public void Setup()
            {
                list = new InfinityRandomNumbers();
            }

            [Test]
            public void CountMustBeIntegerMaximum()
            {
                Assert.AreEqual(int.MaxValue, list.Count);
            }

            [Test]
            [TestCase(0)]
            [TestCase(5)]
            [TestCase(100)]
            [TestCase(100000)]
            public void FirstItemMustBeTheRandomNumberOfSeed(int seed)
            {
                AssertRandomNumberSeeded(seed);
            }

            [Test]
            public void CanIterateThrow100ItemsWithAFor()
            {
                const int timesToRepeat = 100;

                for (var i = 0; i < timesToRepeat; i++) AssertRandomNumberSeeded(i);
            }

            [Test]
            public void CanIterateThrow100ItemsWithAForeach()
            {
                const int timesToRepeat = 100;
                var first100Items = list
                                    .Take(timesToRepeat)
                                    .ToList();
                var counter = 0;

                foreach (var value in first100Items)
                {
                    var expected = RandomTool.GetInteger(counter);
                    Assert.AreEqual(expected, value);

                    counter++;
                }
            }

            [Test]
            public void CanIterateThrow100ItemsWithMoveNextNext()
            {
                const int timesToRepeat = 100;
                using var enumerator = list.GetEnumerator();
                var counter = 0;

                while (enumerator.MoveNext() && counter < timesToRepeat)
                {
                    var expected = RandomTool.GetInteger(counter);
                    Assert.AreEqual(expected, enumerator.Current);
                    
                    counter++;
                }
            }

            [Test]
            public void CanIterateAsIEnumerableThrow100ItemsWithMoveNextNext()
            {
                const int timesToRepeat = 100;
                IEnumerable newList = list;
                var enumerator = newList.GetEnumerator();
                var counter = 0;

                while (enumerator.MoveNext() && counter < timesToRepeat)
                {
                    var expected = RandomTool.GetInteger(counter);
                    Assert.AreEqual(expected, enumerator.Current);

                    counter++;
                }
            }

            private void AssertRandomNumberSeeded(int seed)
            {
                var expected = RandomTool.GetInteger(seed);
                Assert.AreEqual(expected, list[seed]);
            }
        }
    }
}