namespace TDD
{
    using System;
    using FluentAssertions;
    using StringCalculator.Implementations;
    using Xunit;

    public class ValidatorTests
    {
        private Validator sut;

        public ValidatorTests()
        {
            this.sut = new Validator();
        }

        ~ValidatorTests()
        {
            this.sut = null;
        }

        [Fact]
        public void Validate_null()
        {
            bool result = this.sut.IsValid(null);

            result.Should().BeFalse();
        }

        [Fact]
        public void Validate_empty()
        {
            bool result = this.sut.IsValid(String.Empty);

            result.Should().BeFalse();
        }

        [Theory,
        InlineDataAttribute("a1", false),
        InlineDataAttribute("1", true),
        InlineDataAttribute("1 2", true),
        InlineDataAttribute("1 3 4", true),
        InlineDataAttribute("1 3 4.3", true),
        InlineDataAttribute("1;3 4", true),
        InlineDataAttribute("1;3 -4", true),
        InlineDataAttribute("1;3,-4", true),
        InlineDataAttribute("1;3,-4\n9", true),
        InlineDataAttribute("1;3,-4\n-9", true),
        InlineDataAttribute("1;3,-4\n-9 12 3.3", true),
        InlineDataAttribute("1,3;-4-9\n 12 3.3", true),
        ]
        public void Validate(string value, bool expected)
        {
            bool result = this.sut.IsValid(value);

            result.Should().Be(expected);
        }
    }
}
