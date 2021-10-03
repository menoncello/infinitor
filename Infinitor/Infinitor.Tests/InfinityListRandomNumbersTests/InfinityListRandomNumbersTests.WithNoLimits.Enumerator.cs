using System.Collections;
using FluentAssertions;
using Infinitor.Tools;
using NUnit.Framework;

namespace Infinitor
{
    public partial class InfinityListRandomNumbersTests
    {
        public partial class WithNoLimits
        {
            public class Enumerator : WithNoLimits
            {
                private const int TimesToRepeat = 100;
                private InfinityList<int>.Enumerator enumerator = null!;

                [SetUp]
                public void SetUp()
                {
                    enumerator = (InfinityList<int>.Enumerator)list.GetEnumerator();
                }


                [Test]
                public void CanIterateThrow100ItemsWithMoveNextNext()
                {
                    while (enumerator.MoveNext() && enumerator.Index < TimesToRepeat)
                        enumerator.Current.Should().Be(RandomTool.GetInteger(enumerator.Index - 1));

                    enumerator.Index.Should().Be(TimesToRepeat);
                }

                [Test]
                public void CanIterateAsIEnumerableThrow100ItemsWithMoveNextNext()
                {
                    var baseEnumerator = ((IEnumerable)list).GetEnumerator();
                    var counter = 0;

                    while (baseEnumerator.MoveNext() && counter < TimesToRepeat)
                    {
                        baseEnumerator.Current.Should().Be(RandomTool.GetInteger(counter));

                        counter++;
                    }

                    counter.Should().Be(TimesToRepeat);
                }

                [Test]
                public void DisposedMustReturnFalse()
                {
                    enumerator.Disposed.Should().BeFalse();
                }

                [Test]
                public void AfterBeDisposedTheDisposedMustReturnTrue()
                {
                    enumerator.Dispose();
                    enumerator.Disposed.Should().BeTrue();
                }

                [Test]
                public void AfterBeDisposedWithFalseTheDisposedMustBeFalse()
                {
                    enumerator.Dispose(false);
                    enumerator.Disposed.Should().BeTrue();
                }

                [Test]
                public void IfIsNotInTheLastItemMoveNextMustReturnTrue()
                {
                    enumerator.MoveNext().Should().BeTrue();
                }

                [Test]
                public void AfterDisposeEnumeratorValueMustBeReset()
                {
                    enumerator.MoveNext();
                    enumerator.Dispose();

                    enumerator.Current.Should().Be(0);
                    enumerator.Index.Should().Be(0);
                }

                [Test]
                [TestCase(5)]
                [TestCase(10)]
                [TestCase(1000)]
                [TestCase(int.MaxValue)]
                public void WhenJumpToIndexIndexMustBeTheSame(int index)
                {
                    enumerator.JumpToIndex(index);
                    enumerator.Index.Should().Be(index);
                }

                [Test]
                [TestCase(5)]
                [TestCase(10)]
                [TestCase(1000)]
                [TestCase(int.MaxValue)]
                public void WhenJumpToIndexIndexMustBeTheSeedOfCurrent(int index)
                {
                    enumerator.JumpToIndex(index);
                    enumerator.Current.Should().Be(RandomTool.GetInteger(index));
                }

                [Test]
                public void ThenJumpToIntMaxValueMoveNextMustBeFalse()
                {
                    enumerator.JumpToIndex(int.MaxValue);
                    enumerator.MoveNext().Should().BeFalse();
                }

                [Test]
                public void CanExecuteDisposeTwice()
                {
                    enumerator.Dispose();
                    enumerator.Dispose();

                    enumerator.Disposed.Should().BeTrue();
                }
            }
        }
    }
}