namespace WordGameTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using WordGame;

    [TestClass]
    public class WordGameServiceTest
    {
        private WordGameService wordGameService;
        
        [TestInitialize]
        public void Initialize()
        {
            var validLetters = new ValidLetters("areallylongword");
            var validWords = new ValidWords();
            var leaderboard = new Leaderboard();

            wordGameService = new WordGameService(validLetters, validWords, leaderboard);
        }

        [TestMethod]
        public void TestSubmissions()
        {
            Assert.AreEqual(3, wordGameService.SubmitWord("player1", "all"));
            Assert.AreEqual(4, wordGameService.SubmitWord("player2", "word"));
            Assert.AreEqual(null, wordGameService.SubmitWord("player3", "tale"));
            Assert.AreEqual(null, wordGameService.SubmitWord("player4", "glly"));
            Assert.AreEqual(6, wordGameService.SubmitWord("player5", "woolly"));
            Assert.AreEqual(null, wordGameService.SubmitWord("player6", "adder"));
        }

        [TestMethod]
        public void TestSubmissions2()
        {
            Assert.AreEqual(4, wordGameService.SubmitWord("player2", "word"));
            Assert.AreEqual(3, wordGameService.SubmitWord("player1", "all"));
            Assert.AreEqual(6, wordGameService.SubmitWord("player5", "woolly"));
            Assert.AreEqual(null, wordGameService.SubmitWord("player6", "woolly"));

            Assert.AreEqual("player5", wordGameService.GetPlayerNameAtPosition(0));
            Assert.AreEqual("woolly", wordGameService.GetWordEntryAtPosition(0));

            Assert.AreEqual("player2", wordGameService.GetPlayerNameAtPosition(1));
            Assert.AreEqual("player1", wordGameService.GetPlayerNameAtPosition(2));
        }
    }
}
