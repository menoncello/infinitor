using FluentAssertions;
using NUnit.Framework;

namespace Infinitor
{
    [TestFixture]
    public class ProportionalItemTests
    {
        private ProportionalItem<int> item = null!;
        private decimal chance;
        private int value;

        [SetUp]
        public void SetUp()
        {
            chance = 3m;
            value = 5;

            item = new ProportionalItem<int>(chance, value);
        }

        [Test]
        public void ValuesMustBeEqualsToTheConstructor()
        {
            item.Chance.Should().Be(chance);
            item.Value.Should().Be(value);
        }

        [Test]
        public void FullIntChanceMustBeEqualTo5000()
        {
            item.FullIntChance.Should().Be(3000);
        }
    }
}