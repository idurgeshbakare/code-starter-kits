﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingBall
{
    public class Game
    {
        ScoreBoard scoreBoard = new ScoreBoard();

        public void Roll(int pins)
        {
            // Add your logic here. Add classes as needed.
            scoreBoard.AddPoll(pins);
        }

        public int GetScore()
        {
            // Returns the final score of the game.
            return scoreBoard.GetScore();
        }
    }
}
