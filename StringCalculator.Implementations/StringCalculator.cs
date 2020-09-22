namespace StringCalculator.Implementations
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class StringCalculator
    {

        public float Add(string values)
        {
            if (String.IsNullOrEmpty(values))
                return 0;

            var regex = new Regex(@"^[1-9 ]+$");

            if (!regex.IsMatch(values))
                return 0;
            
            var list = values.Split(' ').Select(float.Parse);

            return list.Sum();
        }
    }
}
