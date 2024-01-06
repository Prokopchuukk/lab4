using System;
using System.Collections.Generic;

namespace lab4
{
    class StandardGameAccount : GameAccount
    {
        public StandardGameAccount(string userName) : base(userName) { }

        public override int CalculatePoints(int rating, bool isWin)
        {
            if (isWin)
            {
                return rating;
            }
            else
            {
                return rating;
            }
        }
    }
}
