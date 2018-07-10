using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling
{
    public class Game
    {
        private readonly int[] _rolls=new int[21];
        private int _currentRoll = 0;
        private int _totalScore;

        /// <summary>
        /// Return true if roll is strike
        /// </summary>
        /// <param name="rollIndex">Index of roll</param>
        /// <returns></returns>
        private bool IsStrike(int rollIndex) => _rolls[rollIndex] == 10;

        /// <summary>
        /// Add to total score point for frame and bonus of strike
        /// </summary>
        /// <param name="rollIndex"></param>
        private void ScoreStrike(int rollIndex) => _totalScore +=10 + _rolls[rollIndex + 1] + _rolls[rollIndex + 2];

        /// <summary>
        /// Return true if rolls of frame form spare
        /// </summary>
        /// <param name="rollIndex"></param>
        /// <returns></returns>
        private bool IsSpare(int rollIndex) => _rolls[rollIndex] + _rolls[rollIndex + 1] == 10;

        /// <summary>
        /// Add to total score total point for frame and bonus for spare
        /// </summary>
        /// <param name="rollIndex"></param>
        private void ScoreSpare(int rollIndex) =>_totalScore += _rolls[rollIndex] + _rolls[rollIndex + 1] + _rolls[rollIndex + 2];

        public Game() => _totalScore = 0;

        /// <summary>
        /// Add point
        /// </summary>
        /// <param name="point"></param>
        public void Roll(int point) => _rolls[_currentRoll++] = point;

        /// <summary>
        /// Return total score of the Game
        /// </summary>
        public int GetTotalScore()
        {
            int rollIndex = 0;
            for (int frame = 0; frame < 10; frame++)
            {
                if (IsStrike(rollIndex))
                {   
                    ScoreStrike(rollIndex);
                    rollIndex++;
                }
                else if (IsSpare(rollIndex))
                {
                    ScoreSpare(rollIndex);
                    rollIndex += 2;
                }
                else
                {
                    _totalScore += _rolls[rollIndex] + _rolls[rollIndex + 1];
                    rollIndex += 2;
                }
            }
            return _totalScore;
        }        
    }
}
