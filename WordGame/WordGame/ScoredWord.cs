namespace WordGame
{
    public class ScoredWord
    {
        public string PlayerName { get; set; }
        public string Word { get; set; }
        public int Score => Word.Length;

        public ScoredWord(string playerName, string word)
        {
            PlayerName = playerName;
            Word = word;
        }
    }
}
