using System;
using System.Collections.Generic;
using System.Text;

namespace ColliseumClash
{
    class RollDie
    {
        private Random random;  
        private int sidesNumber;

        public RollDie() //die roll
        {
            sidesNumber = 6;
            random = new Random();
        }

        public RollDie(int sidesNumber) 
        {
            this.sidesNumber = sidesNumber;
            random = new Random();
        }

        public int GetSidesNumber() //return sides number
        {
            return sidesNumber;
        }

        public int Roll() //return random number 1-6
        {
            return random.Next(1, sidesNumber + 1);
        }

        public override string ToString() //returns message with info.
        {
            return String.Format("Rolling die with {0} sides", sidesNumber);
        }
    }
}
