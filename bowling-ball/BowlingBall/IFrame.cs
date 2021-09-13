using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingBall
{
    public interface IFrame
    {
        /// <summary>
        /// Insert roll pins in frame
        /// </summary>
        /// <param name="pins"></param>
        void Roll(int pins);

        /// <summary>
        /// Returns boolean if frame is open
        /// </summary>
        /// <returns></returns>
        bool IsOpen();

        /// <summary>
        /// Return true if frame is strike
        /// </summary>
        /// <returns></returns>
        bool IsStrike();

        /// <summary>
        /// Return true If frame is spare
        /// </summary>
        /// <returns></returns>
        bool IsSpare();

        /// <summary>
        /// Method to get score without bonus.
        /// </summary>
        /// <param name="numberOfRolls"></param>
        /// <returns></returns>
        int GetScore(int numberOfRolls = 0);
    }
}
