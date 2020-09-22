namespace TDD
{
    using System;
    using FluentAssertions;
    using StringCalculator.Implementations;
    using Xunit;

    public class StringCalculatorTests
    {
        [Fact]
        public void Input_empty()
        {
            StringCalculator sut = new StringCalculator();

            float result = sut.Add(String.Empty);

            result.Should().Be(0);
        }
    }
}
