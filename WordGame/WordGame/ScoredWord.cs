using System;

namespace WordGame
{
    public class ScoredWord
    {
        public string PlayerName { get; private set; }
        public string Word { get; private set; }
        public int Score => Word.Length;
        public DateTime Timestamp { get; private set; }

        public ScoredWord(string playerName, string word, DateTime timestamp)
        {
            Timestamp = timestamp;
            PlayerName = playerName;
            Word = word;
        }
    }
}
