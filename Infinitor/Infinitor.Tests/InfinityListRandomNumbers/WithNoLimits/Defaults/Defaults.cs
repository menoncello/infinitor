using System;
using System.Linq;
using FluentAssertions;
using Infinitor.Tools;
using NUnit.Framework;

namespace Infinitor
{
    public partial class InfinityListRandomNumbersTests
    {
        public partial class WithNoLimits
        {
            public class Defaults : WithNoLimits
            {
                [Test]
                public void CountMustBeIntegerMaximum()
                {
                    list.Should().HaveCount(int.MaxValue);
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

                    for (var i = 0; i < timesToRepeat; i++)
                        AssertRandomNumberSeeded(i);
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
                        value.Should().Be(RandomTool.GetInteger(counter));
                        counter++;
                    }
                }

                [Test]
                public void IsReadOnlyMustBeTrue()
                {
                    list.IsReadOnly.Should().BeTrue();
                }

                [Test]
                public void AddMustThrowError()
                {
                    list.Invoking(x => x.Add(0))
                        .Should()
                        .ThrowExactly<InfinityListReadOnlyException>();
                }

                [Test]
                public void ClearMustThrowError()
                {
                    list.Invoking(x => x.Clear())
                        .Should()
                        .ThrowExactly<InfinityListReadOnlyException>();
                }

                [Test]
                public void RemoveMustThrowError()
                {
                    list.Invoking(x => x.Remove(0))
                        .Should()
                        .ThrowExactly<InfinityListReadOnlyException>();
                }

                [Test]
                public void ContainsMustBeTrue()
                {
                    list.Contains(0).Should().BeTrue();
                }

                [Test]
                public void CopyToMustThrowError()
                {
                    var array = Array.Empty<int>();
                    list.Invoking(x => x.CopyTo(array, 0))
                        .Should()
                        .ThrowExactly<TooLargeToCopyException>();
                }
            }
        }
    }
}