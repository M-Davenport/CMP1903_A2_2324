using System; // Importing the System namespace

namespace CMP1903_A1_2324 // Defining the namespace
{
    internal class Die // Declaring the Die class
    {
        private Random random = new Random(); // Declaring and initializing a private field for generating random numbers

        public int FaceValue { get; private set; } // Declaring a property to hold the current die value (Property)

        public int Roll() // Declaring a method to roll the die (Method)
        {
            FaceValue = random.Next(1, 7); // Generating a random number between 1 and 6 and assigning it to the FaceValue property
            return FaceValue; // Returning the rolled value
        }
    }
}
