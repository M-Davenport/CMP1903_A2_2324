using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324 //defines the namespace
{
    internal class Die //declares the die class
    {
        private static Random random = new Random(); //declares and initialises a private field for generating random numbers
        
        public int FaceValue { get; private set; } //declares a property to hold the current die value

        public int Roll() //declares a method to roll the die
        {
            FaceValue = random.Next(1, 7); //generates a random number between 1 and 6 (1-7 to allow it to include up to 6) and assigns it to the FaceValue property
            return FaceValue; //returns the rolled value
        }
      


    }
}

