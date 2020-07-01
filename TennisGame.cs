using System;

namespace TennisRefactoringKata
{
    internal class TennisGame
    {
        private readonly string player1;
        private readonly string player2;
        private int player1Score;
        private int player2Score;

        public TennisGame(string Player1, string Player2)
        {
            this.player1 = Player1;
            this.player2 = Player2;
            Score = "Love-All";
        }

        public string Score { get; internal set; }

        internal void Point(string player)
        {
            var player1ScoreText = "Love";
            var player2ScoreText = "Love";
            if (player == player1)
            {
                player1Score++;
                if (player1Score == 1)
                    player1ScoreText = "15";
                else if (player1Score == 2)
                    player1ScoreText = "30";
                else if (player1Score == 3)
                    player1ScoreText = "40";
            }
            else
            {
                player2Score++;
                if (player2Score == 1)
                    player2ScoreText = "15";
                else if (player2Score == 2)
                    player2ScoreText = "30";
                else if (player2Score == 3)
                    player2ScoreText = "40";
            }

            Score = player1ScoreText + ", " + player2ScoreText;
            if (player1Score == player2Score)
            {
                if (player1Score == 1)
                    Score = "Fifteen-All";
                if (player1Score == 2)
                    Score = "Thirty-All";
                if (player1Score == 3)
                    Score = "Duece";
            }

            if (player1Score >= 4 && player1Score > player2Score)
            {
                if (player1Score - player2Score == 0)
                    Score = "Duece";
                if (player1Score - player2Score == 1)
                    Score = "Advantage Player1";
                if (player1Score - player2Score > 1)
                    Score = "Win for Player1";
            }

            if (player2Score >= 4 && player2Score > player1Score)
            {
                if (player2Score - player1Score == 0)
                    Score = "Duece";
                if (player2Score - player1Score == 1)
                    Score = "Advantage Player2";
                if (player2Score - player1Score > 1)
                    Score = "Win for Player2";
            }
        }
    }
}