namespace WordGame
{
    using System;
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
        private SortedSet<ScoredWord> _scores;

        public Leaderboard()
        {
            _scores = new SortedSet<ScoredWord>(new ScoresComparer());
        }

        public Submission Submit(ScoredWord scoredWord)
        {
            lock (this)
            {
                return _scores.Add(scoredWord) ?
                     Submission.Ok(scoredWord):
                     Submission.Rejected();
            }
        }

        public ScoredWord At(int position)
        {
            return _scores.ElementAtOrDefault(position);
        }
    }

    public class ScoresComparer : IComparer<ScoredWord>
    {
        public int Compare(ScoredWord x, ScoredWord y)
        {
            var scoreOrder = y.Score.CompareTo(x.Score);
            var timeOrder = x.Timestamp.CompareTo(y.Timestamp);

            return x.Word == y.Word ? 0 :
                   scoreOrder != 0 ? scoreOrder :
                   timeOrder;
        }
    }

}
