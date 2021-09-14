namespace WordGame
{
    using System.Collections.Generic;
    using System.Linq;

    public class ValidLetters
    {
        private Dictionary<char, int> _validLettersCount;

        public ValidLetters(char[] letters)
        {
            _validLettersCount = CountLetters(letters);
        }

        public bool OkFor(string word)
        {
            var wordAsDict = CountLetters(word.ToCharArray());

            foreach (var kv in wordAsDict)
            {
                var letter = kv.Key;
                var count = kv.Value;

                if (!_validLettersCount.TryGetValue(letter, out var maxCount))
                {
                    return false;
                }

                if (count > maxCount)
                {
                    return false;
                }
            }

            return true;
        }

        public Dictionary<char, int> CountLetters(char[] letters)
        {
            return letters
                .GroupBy(x => x)
                .ToDictionary(x => x.Key, x => x.Count());
        }
    }
}
