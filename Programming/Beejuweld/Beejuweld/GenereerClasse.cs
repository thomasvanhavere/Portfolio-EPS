using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beejuweld
{
    class GenereerClasse
    {
        public GenereerClasse()
        {
            randomNumber = random.Next(1, 7);
            returnValue = randomNumber;
            SetRandomValue = randomNumber;
            SetNexValue = randomNumber;
        }

        static Random random = new Random();

        private int randomNumber;
        public int vulMatrix
        {
            get { return randomNumber; }
            set { randomNumber = value; }
        }
        public int X { get; set; }
        public int Y { get; set; }
        private int returnValue;
        public int GetmatrixTile
        {
            get { return returnValue; }
            set { returnValue = value; }
        }
        public int GetMatrixValue
        {
            get { return returnValue; }
        }
        private int SetNexValue;
        public int setNExtValue
        {
            set { SetNexValue = value; }


        }
        private int SetRandomValue;
        public int setRandomValue
        {
            set { SetRandomValue = value; }
           

        }
    }
}
