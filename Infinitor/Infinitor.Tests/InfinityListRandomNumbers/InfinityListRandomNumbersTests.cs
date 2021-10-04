using FluentAssertions;
using Infinitor.Tools;

namespace Infinitor
{
    public partial class InfinityListRandomNumbersTests
    {
        private InfinityListRandomNumbers list = null!;

        private void AssertRandomNumberSeeded(int seed)
        {
            list[seed].Should().Be(RandomTool.GetInteger(seed));
        }
    }
}