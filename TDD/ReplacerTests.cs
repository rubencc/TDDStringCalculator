namespace TDD
{
    using FluentAssertions;
    using StringCalculator.Implementations;
    using Xunit;

    public class ReplacerTests
    {
        private Replacer sut;

        public ReplacerTests()
        {
            this.sut = new Replacer();
        }

        ~ ReplacerTests()
        {
            this.sut = null;
        }

        [Theory,
         InlineDataAttribute("1", "1"),
         InlineDataAttribute("1 2", "1 2"),
         InlineDataAttribute("1;3,-4\n9", "1 3 -4 9"),
         InlineDataAttribute("1;3,-4\n-9", "1 3 -4 -9"),
         InlineDataAttribute("1;3,-4\n-9 12 3.3",  "1 3 -4 -9 12 3.3"),
         InlineDataAttribute("1,3;-4-9\n 12 3.3", "1 3 -4-9  12 3.3"),
        ]
        public void Validate(string value, string expected)
        {
            string result = this.sut.Replace(value);

            result.Should().Be(expected);
        }
    }
}
