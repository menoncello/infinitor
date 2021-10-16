using System.Collections;
using FluentAssertions;
using NUnit.Framework;

namespace Infinitor
{
    public partial class InfinityListTests
    {
        public class Enumerator : InfinityListTests
        {
            private InfinityList<int>.Enumerator enumerator = null!;
            private IEnumerable enumerable = null!;

            [SetUp]
            public void SetUp()
            {
                CreateList();
                enumerator = (InfinityList<int>.Enumerator) list.GetEnumerator();
                enumerable = list;
            }

            [Test]
            public void DisposedMustReturnFalse() => enumerator.Disposed.Should().BeFalse();

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
            public void IfIsNotInTheLastItemMoveNextMustReturnTrue() =>
                enumerator.MoveNext().Should().BeTrue();

            [Test]
            public void Enumerable_Current_MustBeZero() =>
                enumerable.GetEnumerator().Current.Should().Be(0);

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

            [Test]
            public void MoveNext_IndexMustBe1()
            {
                enumerator.MoveNext();
                enumerator.Index.Should().Be(1);
            }
        }
    }
}