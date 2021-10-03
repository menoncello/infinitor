using FluentAssertions;
using Infinitor.Tools;

namespace Infinitor
{
    public partial class InfinityRandomNumbersTests
    {
        private InfinityRandomNumbers list = null!;

        private void AssertRandomNumberSeeded(int seed)
        {
            list[seed].Should().Be(RandomTool.GetInteger(seed));
        }
    }
}