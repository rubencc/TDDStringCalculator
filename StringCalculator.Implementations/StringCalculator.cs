namespace StringCalculator.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    public class StringCalculator
    {
        private readonly IValidator validator;
        private readonly IReplacer replacer;

        public StringCalculator(IValidator validator, IReplacer replacer)
        {
            this.validator = validator ?? throw new ArgumentNullException(nameof(validator));
            this.replacer = replacer ?? throw new ArgumentNullException(nameof(replacer));
        }

        public float Add(string values)
        {
            var numbers = this.GetNumbers(values);

            return numbers.Sum();
        }


        public float Subtract(string values)
        {
            var numbers = this.GetNumbers(values);

            float result = numbers.FirstOrDefault();

            foreach (var item in numbers.Skip(1))
            {
                result = result - item;
            }
            
            return result;
        }

        private IEnumerable<float> GetNumbers(string values)
        {
            if (!this.validator.IsValid(values))
                return new List<float>(){0};
            
            string replaced = this.replacer.Replace(values);

            return replaced.Split(' ').Select(x => float.Parse(x, CultureInfo.InvariantCulture));
        }
    }
}
