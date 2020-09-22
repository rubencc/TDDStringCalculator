namespace StringCalculator.Implementations
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class StringCalculator
    {

        public float Add(string values)
        {
            if (String.IsNullOrEmpty(values))
                return 0;

            var regex = new Regex(@"^[-?1-9 .,;\n]+$");

            if (!regex.IsMatch(values))
                return 0;

            values = values.Replace( "\r", " ").Replace( "\n", " " ).Replace(',', ' ').Replace(';', ' ');

            var list = values.Split(' ').Select(x => float.Parse(x, CultureInfo.InvariantCulture));

            return list.Sum();
        }
    }
}
