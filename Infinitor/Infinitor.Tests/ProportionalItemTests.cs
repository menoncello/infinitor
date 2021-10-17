using FluentAssertions;
using NUnit.Framework;

namespace Infinitor
{
    [TestFixture]
    public class ProportionalItemTests
    {
        private ProportionalItem<int> item = null!;

        [SetUp]
        public void SetUp() =>
            item = new ProportionalItem<int>(3m, 5);

        [Test]
        public void Constructor_ValuesMustBeEquals()
        {
            item.Chance.Should().Be(3m);
            item.Value.Should().Be(5);
        }

        [Test]
        public void FullIntChance_MustBeEqualTo5000() =>
            item.FullIntChance.Should().Be(3000);
    }
}