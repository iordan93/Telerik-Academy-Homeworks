using System;
using System.Globalization;
using System.Text.RegularExpressions;

class ExtractDatesForCanada
{
    static void Main()
    {
        Console.WriteLine("This program will read a string and extract every date that corresponds to the format dd.MM.yyyy.");
        Console.WriteLine("Then it will display these dates in the standard date format for Canada.");

        Console.WriteLine("Write the string from which the dates should be extracted:");
        string input = Console.ReadLine();

        // The regular expression matches 1 or 2 digits + . + 1 or 2 digits + . + 4 digits
        MatchCollection possibleDates = Regex.Matches(input, @"\d{1,2}\.\d{1,2}\.\d{4}");
        
        DateTime validDate = new DateTime();
        foreach (Match date in possibleDates)
        {
            // For each string which might be a date, try to parse it. If the result of the parsing is true, convert the date to string,
            // using the Canadian culture (in French), and skip the hours (ShortDatePattern)
            if (DateTime.TryParse(date.Value, CultureInfo.InvariantCulture, DateTimeStyles.None, out validDate))
            {
                string output = validDate.ToString(CultureInfo.GetCultureInfo("fr-CA").DateTimeFormat.ShortDatePattern);
                Console.WriteLine(output);
            }
        }
    }
}