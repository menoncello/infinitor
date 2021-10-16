using System;
using FluentAssertions;
using NUnit.Framework;

namespace Infinitor
{
    public partial class InfinityListTests
    {
        public class Default : InfinityListTests
        {
            [SetUp]
            public void SetUp()
            {
                CreateList();
            }
            
            [Test]
            public void CountMustBeIntegerMaximum()
            {
                list.Should().HaveCount(int.MaxValue);
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