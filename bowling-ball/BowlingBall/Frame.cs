using System.Collections.Generic;
using System.Linq;

namespace BowlingBall
{
    /// <summary>
    /// Class to manage the frame, which hold the pins array for game.
    /// </summary>
    public class Frame : IFrame
    {
        /// <summary>
        /// Maximum polls allowed from frame.
        /// </summary>
        private readonly int MAX_ROLLS = 2;

        /// <summary>
        /// Maximum pins to be strike down for the frame.
        /// </summary>
        private const int MAX_PINS = 10;

        /// <summary>
        /// Rolls value for the frame.
        /// </summary>
        private readonly List<int> Rolls;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="maxRollsAllowed"></param>
        public Frame(int maxRollsAllowed = 2)
        {
            this.MAX_ROLLS = maxRollsAllowed;
            this.Rolls = new List<int>(this.MAX_ROLLS);
        }

        /// <summary>
        ///  Add pins down for roll.
        /// </summary>
        /// <param name="pins"></param>
        public void Roll(int pins)
        {
            this.Rolls.Add(pins);
        }

        /// <summary>
        /// Return does the frame open.
        /// </summary>
        /// <returns></returns>
        public bool IsOpen()
        {
            if (this.IsStrike() || this.IsSpare())
            {
                return false;
            }

            if (this.Rolls.Count() < MAX_ROLLS)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Returns true of frame is Strike
        /// </summary>
        /// <returns></returns>
        public bool IsStrike()
        {
            if (this.Rolls.Count() == 1 && this.Rolls.First() == MAX_PINS)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Returns true of frame is Spare
        /// </summary>
        /// <returns></returns>
        public bool IsSpare()
        {
            if (this.Rolls.Count == MAX_ROLLS)
            {
                return GetScore() == MAX_PINS ? true : false;
            }
            return false;
        }

        /// <summary>
        /// Get Score for the frame.
        /// </summary>
        /// <param name="numberOfRolls"></param>
        /// <returns></returns>
        public int GetScore(int numberOfRolls = 0)
        {
            int sum = 0;
            int maxRolls = numberOfRolls != 0 ? numberOfRolls : Rolls.Count;
            for (int rollIndex = 0; rollIndex < maxRolls; rollIndex++)
            {
                sum += Rolls[rollIndex];
            }
            return sum;
        }
    }
}
