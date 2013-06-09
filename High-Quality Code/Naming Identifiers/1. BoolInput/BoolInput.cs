using System;

public class BoolInput
{
    private const int MaxCount = 6;

    public static void Main()
    {
        BoolInput.BoolPrinter boolPrinter = new BoolInput.BoolPrinter();
        boolPrinter.GetBoolAsString(true);
    }
    
    public class BoolPrinter
    {
        public void GetBoolAsString(bool variable)
        {
            string variableAsString = variable.ToString();
            Console.WriteLine(variableAsString);
        }
    }
}