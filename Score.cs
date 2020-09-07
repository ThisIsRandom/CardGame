using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
    class Score
    {
        private int _CurrentScore;

        public Score() {

            this._CurrentScore = 1;

        }

        public int getScore()
        {
            return this._CurrentScore;
        }

        public int Add(int amountToAdd = 1)
        {
            return this._CurrentScore += amountToAdd;
        }

        public void Reset()
        {
            this._CurrentScore = 1;
        }
    }
}
