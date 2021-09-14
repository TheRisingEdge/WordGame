using System;

namespace WordGame
{
    public class WordGameService : IWordGameService
    {
        private readonly IValidWords _validWords;
        private readonly ValidLetters _validLetters;
        private readonly Leaderboard _leaderboard;

        public WordGameService(ValidLetters validLetters, IValidWords validWords, Leaderboard leaderboard)
        {
            _validWords = validWords;
            _validLetters = validLetters;
            _leaderboard = leaderboard;
        }

        public string GetPlayerNameAtPosition(int position) => _leaderboard.At(position)?.PlayerName;
        public int? GetScoreAtPosition(int position) => _leaderboard.At(position)?.Score;
        public string GetWordEntryAtPosition(int position) => _leaderboard.At(position)?.Word;

        public int? SubmitWord(string playerName, string word)
        {
            if (WordIsOk(word))
            {
                var scoredWord = ScoreWord(playerName, word);
                var submission = _leaderboard.Submit(scoredWord);

                if (submission.Accepted)
                {
                    return submission.ScoredWord.Score;
                }
            }

            return null;
        }

        private ScoredWord ScoreWord(string playerName, string word)
        {
            return new ScoredWord(playerName, word, DateTime.Now);
        }

        private bool WordIsOk(string word)
        {
            return _validLetters.OkFor(word) && _validWords.Contains(word);
        }
    }
}
