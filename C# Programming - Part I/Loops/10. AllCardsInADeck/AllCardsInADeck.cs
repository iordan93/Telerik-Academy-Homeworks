using System;
class AllCardsInADeck
{
    static void Main()
    {

        char club = '♣';
        char diamond = '♦';
        char heart = '♥';
        char spade = '♠';
        byte suitIndex;
        char suit = '1';
        for (suitIndex = 1; suitIndex <= 4; suitIndex++)
        {
            switch (suitIndex)
            {
                case 1:
                    suit = club;
                    break;
                case 2:
                    suit = diamond;
                    break;
                case 3:
                    suit = heart;
                    break;
                case 4:
                    suit = spade;
                    break;
            }
            for (int card = 2; card <= 14; card++)
            {

                switch (card)
                {
                    case 2:
                        Console.Write("2{0}, ", suit);
                        break;
                    case 3:
                        Console.Write("3{0}, ", suit);
                        break;
                    case 4:
                        Console.Write("4{0}, ", suit);
                        break;
                    case 5:
                        Console.Write("5{0}, ", suit);
                        break;
                    case 6:
                        Console.Write("6{0}, ", suit);
                        break;        
                    case 7:           
                        Console.Write("7{0}, ", suit);
                        break;       
                    case 8:          
                        Console.Write("8{0}, ", suit);
                        break;       
                    case 9:          
                        Console.Write("9{0}, ", suit);
                        break;        
                    case 10:          
                        Console.Write("10{0}, ", suit);
                        break;        
                    case 11:          
                        Console.Write("J{0}, ", suit);
                        break;        
                    case 12:          
                        Console.Write("Q{0}, ", suit);
                        break;       
                    case 13:         
                        Console.Write("K{0}, ", suit);
                        break;        
                    case 14:          
                        Console.WriteLine("A{0}.", suit);
                        break;
                }
            }
        }
    }
}