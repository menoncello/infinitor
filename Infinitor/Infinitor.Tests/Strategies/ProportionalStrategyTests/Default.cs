using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace Infinitor.Strategies
{
    public partial class ProportionalStrategyTests
    {
        public class Default : ProportionalStrategyTests
        {
            [Test]
            public void Constructor_ThrowsErrorWhenPassingNullList()
            {
                Action act = () => CreateProportionalStrategy();
                act.Should().Throw<ArgumentNullException>();
            }

            [Test]
            public void Constructor_ThrowsErrorWhenPassingListIsEmpty()
            {
                Action act = () => CreateProportionalStrategy(new List<ProportionalItem<int>>());
                act.Should().Throw<ArgumentOutOfRangeException>();
            }
        }
    }
}