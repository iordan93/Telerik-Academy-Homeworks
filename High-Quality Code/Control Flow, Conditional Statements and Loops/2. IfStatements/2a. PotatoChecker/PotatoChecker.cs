using System;

public class PotatoChecker
{
    // ...
    public void CheckPotato(Vegetable potatoToCheck)
    {
        Potato potato = potatoToCheck as Potato;

        if (potato != null)
        {
            // Using lazy evaluation - if the potato is rotten, the program will not check anything else
            if (!potato.IsRotten && potato.IsPeeled)
            {
                this.Cook(potato);
            }
        }
    }

    private void Cook(Vegetable vegitable) 
    {
        // ...
    }
}