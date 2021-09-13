using System.Collections.Generic;

namespace BowlingBall
{
    public class ScoreBoard
    {
        /// <summary>
        /// Maxinum frames allowed for the game.
        /// </summary>
        private const int MAX_FRAME_COUNT = 10;

        /// <summary>
        /// Number of Bonus rolls for Strike.
        /// </summary>
        private const int BONUS_ROLLS_FOR_STRIKE = 2;

        /// <summary>
        /// Number of bonus rolls for spare.
        /// </summary>
        private const int BONUS_ROLLS_FOR_SPARE = 1;

        /// <summary>
        /// Frame Count for the game.
        /// </summary>
        private int frameCount = 0;

        /// <summary>
        /// Frames of the game
        /// </summary>
        private readonly List<Frame> frames = new List<Frame>();

        /// <summary>
        /// Cursor to hold the current frame of the game. 
        /// </summary>
        private Frame currentFrame = null;

        /// <summary>
        /// Add poll pins to game frame
        /// </summary>
        /// <param name="pins"></param>
        public void AddPoll(int pins)
        {
            if (frameCount < MAX_FRAME_COUNT + 2)
            {
                if (currentFrame == null || !currentFrame.IsOpen())
                {
                    currentFrame = new Frame();
                    frames.Add(currentFrame);
                    frameCount++;
                }
                currentFrame.Roll(pins);
            }
        }

        /// <summary>
        /// Get Score for the game.
        /// </summary>
        /// <returns></returns>
        public int GetScore()
        {
            int finalScore = 0;
            int currentFrameIndex = 0;
            foreach (var frame in frames)
            {
                if (currentFrameIndex < MAX_FRAME_COUNT)
                {
                    finalScore += frame.GetScore();

                    int noOfBonusRolls = 0;
                    if (frame.IsSpare())
                    {
                        //Get Bonus for Spare frame.
                        noOfBonusRolls = BONUS_ROLLS_FOR_SPARE;
                    }

                    if (frame.IsStrike())
                    {
                        //Get Bonus for Strike frame.
                        noOfBonusRolls = BONUS_ROLLS_FOR_STRIKE;
                    }
                    finalScore += GetBonus(currentFrameIndex, noOfBonusRolls);
                }
                currentFrameIndex++;
            }
            return finalScore;
        }

        /// <summary>
        /// Get the bonus for give index frame.
        /// </summary>
        /// <param name="currentFrameIndex"></param>
        /// <param name="noOfBonusRolls"></param>
        /// <returns></returns>
        private int GetBonus(int currentFrameIndex, int noOfBonusRolls)
        {
            // if no bonus rolls are  allowed
            int bonus = 0;
            if (noOfBonusRolls == 0)
            {
                return bonus;
            }

            // Get the bonus from next indice.
            int bonusRollsToBeAdded = 0;
            int frameIndexForBonus = currentFrameIndex + 1;
            while (bonusRollsToBeAdded < noOfBonusRolls)
            {
                //If bonus frame is strike, adding 10 points
                if (frames[frameIndexForBonus].IsStrike())
                {
                    bonus += 10;
                    bonusRollsToBeAdded++;
                    frameIndexForBonus++;
                }
                else
                {
                    //If the bonus fram is spare or normal frame, get the score for pending bonus rolls.
                    int pendingBonusRolls = noOfBonusRolls - bonusRollsToBeAdded;
                    bonus += frames[frameIndexForBonus].GetScore(pendingBonusRolls);
                    bonusRollsToBeAdded += (pendingBonusRolls);
                    frameIndexForBonus++;
                }
            }
            return bonus;
        }
    }
}
