using NUnit.Framework;
using System;

namespace TennisRefactoringKata
{
    public class Tests
    {
        private const string Player1 = "Player1";
        private const string Player2 = "Player2";
        private TennisGame game;

        [SetUp]
        public void Setup()
        {
            game = new TennisGame(Player1, Player2);
        }

        [Test]
        public void GameStartsAtScoreZero()
        {
            Assert.AreEqual("Love-All", game.Score);
        }

        [Test]
        public void Player1Scoring()
        {
            game.Point(Player1);
            Assert.AreEqual("15, Love", game.Score);

            game.Point(Player1);
            Assert.AreEqual("30, Love", game.Score);

            game.Point(Player1);
            Assert.AreEqual("40, Love", game.Score);

            game.Point(Player1);
            Assert.AreEqual($"Win for {Player1}", game.Score);
        }

        [Test]
        public void Player2Scoring()
        {
            game.Point(Player2);
            Assert.AreEqual("Love, 15", game.Score);

            game.Point(Player2);
            Assert.AreEqual("Love, 30", game.Score);

            game.Point(Player2);
            Assert.AreEqual("Love, 40", game.Score);

            game.Point(Player2);
            Assert.AreEqual($"Win for {Player2}", game.Score);
        }

        [Test]
        public void TieScores()
        {
            game.Point(Player1);
            game.Point(Player2);
            Assert.AreEqual("Fifteen-All", game.Score);
    
            game.Point(Player1);
            game.Point(Player2);
            Assert.AreEqual("Thirty-All", game.Score);

            game.Point(Player1);
            game.Point(Player2);
            Assert.AreEqual("Duece", game.Score);
        }

        [Test]
        public void AdvantageScore()
        {
            AssignPlayerPoints(Player1, 4);
            AssignPlayerPoints(Player2, 3);

            Assert.AreEqual("Advantage Player1", game.Score);
        }

        private void AssignPlayerPoints(string player, int points)
        {
            for(int point = 0; point < points; point++) {
                game.Point(player);
            }
        }
    }
}