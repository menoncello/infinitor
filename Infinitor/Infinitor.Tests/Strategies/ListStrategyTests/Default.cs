using System;
using FluentAssertions;
using NUnit.Framework;

namespace Infinitor.Strategies
{
    public partial class ListStrategyTests
    {
        public class Default : ListStrategyTests
        {
            [Test]
            public void Constructor_ListStrategyInheritsFromGenerationStrategy()
            {
                new ListStrategy<int>(new[] {1}).Should().BeAssignableTo<IGenerationStrategy<int>>();
            }

            [Test]
            public void Constructor_ThrowsExceptionWhenListIsNull()
            {
                Action act = () => _ = new ListStrategy<int>(null!);
                act.Should().Throw<ArgumentNullException>();
            }

            [Test]
            public void Constructor_ThrowsExceptionWhenListIsEmpty()
            {
                Action act = () => _ = new ListStrategy<int>(Array.Empty<int>());
                act.Should().Throw<ArgumentOutOfRangeException>();
            }
        }
    }
}