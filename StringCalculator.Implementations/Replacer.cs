namespace StringCalculator.Implementations
{
    public class Replacer : IReplacer
    {
        public string Replace(string input)
        {
            return input.Replace( "\r", " ").Replace( "\n", " " ).Replace(',', ' ').Replace(';', ' ');
        }
    }
}
