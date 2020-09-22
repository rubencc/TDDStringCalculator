namespace StringCalculator.Implementations
{
    using System;
    using System.Text.RegularExpressions;
    
    public class Validator : IValidator
    {
        private readonly Regex regex;

        public Validator()
        {
            this.regex = new Regex(@"^[-?1-9 .,;\n]+$");
        }
        public bool IsValid(string input)
        {
            if (String.IsNullOrEmpty(input))
                return false;

            if (!regex.IsMatch(input))
                return false;

            return true;
        }
    }
}
