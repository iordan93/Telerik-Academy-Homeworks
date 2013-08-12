namespace _5.StringOccurrencesServiceClient
{
    using System;

    class StringOccurrencesServiceClient
    {
        static void Main()
        {
            StringOccurrencesService.StringOccurrencesServiceClient client = new StringOccurrencesService.StringOccurrencesServiceClient();
            Console.WriteLine(client.CountOccurrences("The answer is the answer - The answer", "The"));
        }
    }
}
