using System;

    class MembersOfSequence
    {
        static void Main()
        {
            Console.WriteLine("The first ten members of the sequence 2, -3, 4, -5... are: ");
            int oddMember = 0;
            int evenMember = -1;
            for (int i = 0; i < 5; i++)         
            {
                oddMember = oddMember + 2;
                Console.WriteLine(oddMember);
                evenMember = evenMember - 2;
                Console.WriteLine(evenMember);
            }
        }
    }
