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

        private bool IsStrike(int rollIndex) => _rolls[rollIndex] == 10;
        private void ScoreStrike(int rollIndex) => _totalScore +=10 + _rolls[rollIndex + 1] + _rolls[rollIndex + 2];

        private bool IsSpare(int rollIndex) => _rolls[rollIndex] + _rolls[rollIndex + 1] == 10;
        private void ScoreSpare(int rollIndex) =>_totalScore += _rolls[rollIndex] + _rolls[rollIndex + 1] + _rolls[rollIndex + 2];

        public Game() => _totalScore = 0;

        public void Roll(int point) => _rolls[_currentRoll++] = point;


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


        public void ResetGame()
        {
            _totalScore = 0;
            for (int rollIndex = 0; rollIndex < _rolls.Length; rollIndex++)
                _rolls[rollIndex] = 0;
        }

        
    }
}
