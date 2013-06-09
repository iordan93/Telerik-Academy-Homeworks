using System;
class CheckBrackets
{
    static void Main()
    {
        Console.WriteLine("This program will check if the brackets in an expression have been put correctly.");
        Console.WriteLine("Enter the expression to check:");
        string input = Console.ReadLine();
        int bracketCounter = 0;

        // Check each character. If it is '(', increment the counter, if it is ')', decrement the counter.
        // While checking, the counter must not be less than zero. If it becomes less than zero, output an error message.
        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == '(')
            {
                bracketCounter++;
            }
            if (input[i] == ')')
            {
                bracketCounter--;
            }
            if (bracketCounter < 0)
            {
                Console.WriteLine("The brackets in the expression have not been put correctly.");
                return;
            }
        }

        // After the checking has finished, if the counter is zero, the brackets are OK
        // Else, if the counter is greater than zero (the case "less than zero" has already been checked), the brackets are not put correctly
        if (bracketCounter > 0)
        {
            Console.WriteLine("The brackets in the expression have not been put correctly.");
        }
        else 
        {
            Console.WriteLine("The brackets in the expression have been put correctly.");
        }
    }
}
