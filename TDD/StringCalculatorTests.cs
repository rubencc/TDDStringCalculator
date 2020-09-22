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

        [Fact]
        public void Input_null()
        {
            StringCalculator sut = new StringCalculator();

            float result = sut.Add(null);

            result.Should().Be(0);
        }

        [Fact]
        public void Input_not_numbers()
        {
            StringCalculator sut = new StringCalculator();

            float result = sut.Add("String.Empty");

            result.Should().Be(0);
        }

        [Fact]
        public void Input_1_2()
        {
            StringCalculator sut = new StringCalculator();

            float result = sut.Add("1 2");

            result.Should().Be(3);
        }

        [Fact]
        public void Input_4_4_5()
        {
            StringCalculator sut = new StringCalculator();

            float result = sut.Add("4 4 5");

            result.Should().Be(13);
        }

        [Fact]
        public void Input_4_dot_1_4_5()
        {
            StringCalculator sut = new StringCalculator();

            float result = sut.Add("4.1 4 5");

            result.Should().Be(13.1f);
        }

        [Fact]
        public void Input_4_dot_1_4_5_separator()
        {
            StringCalculator sut = new StringCalculator();

            float result = sut.Add("4.1,4,5");

            result.Should().Be(13.1f);
        }
    }
}
