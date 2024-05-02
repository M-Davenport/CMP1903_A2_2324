using System;

public class Die
{
    private Random random;//encapsulation is used here to keep the dandom instance internal to the die class.
    public int FaceValue { get; private set; }//property to get the current face value of the die
                                              //it has a public getter and private setter
                                              //this is encapsulation and makes sure that the facevalue can only be modified by the die class
    public Die(Random sharedRandom)//constructor that takes a Random object as a parameter. This is dependency injection
    {
        random = sharedRandom;//assigns the passed-in Random object to the private field
    }

    public int Roll()//method that rolls the die and updates its face value
    {
        FaceValue = random.Next(1, 7);//sets the facevalue to a random number between 1 and 6
                                      //this is an exampl of data hiding
        return FaceValue;//returns the  facevalue.
                         
    }
}
