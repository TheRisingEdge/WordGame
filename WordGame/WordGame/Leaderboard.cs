namespace WordGame
{
    using System.Collections.Generic;
    using System.Linq;

    public struct Submission
    {
        public ScoredWord ScoredWord { get; set; }
        public bool Accepted => ScoredWord != null;

        private Submission(ScoredWord scoredWord)
        {
            ScoredWord = scoredWord;
        }

        public static Submission Ok(ScoredWord scoredWord) => new Submission(scoredWord);
        public static Submission Rejected() => new Submission(null);
    }

    public class Leaderboard
    {
        private List<ScoredWord> _scores;

        public Leaderboard()
        {
            _scores = new List<ScoredWord>();
        }

        public Submission Submit(ScoredWord scoredWord)
        {
            lock (_scores)
            {
                if (WordIsNew(scoredWord))
                {
                    InsertWord(scoredWord);

                    return Submission.Ok(scoredWord);
                }

                return Submission.Rejected();
            }
        }

        private void InsertWord(ScoredWord scoredWord)
        {
            var firstLowerScoreWordIndex = _scores.FindIndex(w => w.Score < scoredWord.Score);
            var indexToInsertAt = firstLowerScoreWordIndex < 0 ? 0 : firstLowerScoreWordIndex;

            _scores.Insert(indexToInsertAt, scoredWord);
            _scores = _scores.Take(10).ToList();
        }

        private bool WordIsNew(ScoredWord scoredWord)
        {
            return !_scores.Any(x => x.Word == scoredWord.Word);
        }

        public ScoredWord At(int position)
        {
            return _scores.ElementAtOrDefault(position);
        }
    }
}
