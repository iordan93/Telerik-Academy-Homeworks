using System;
using System.Collections.Generic;

class AddTwoPolynomials
{
    static int[] InitializePolynomial() 
    {
        Console.Write("\tEnter the degree of the polynomial: ");
        int degree = int.Parse(Console.ReadLine());
        int[] polynomial = new int[degree+1];
        for (int i = degree; i >= 0; i--)
        {
            if (i != 0)
            {
                Console.Write("\tEnter the coefficient of x^{0}: ", i);
                polynomial[i] = int.Parse(Console.ReadLine());
            }
            else
            {
                Console.Write("\tEnter the coefficient of the free member: ");
                polynomial[0] = int.Parse(Console.ReadLine());
            }
        }
        return polynomial;
    }

    // To add two polynomials, we will need a simplified version of the algorithm to add numbers as arrays
    static int[] AddPolynomials(int[] first, int[] second)
    {
        // Check which is the bigger array
        int maxLength = Math.Max(first.Length, second.Length);
        int[] result = new int[maxLength];
        for (int i = 0; i < maxLength; i++)
        {
            result[i] = first[i] + second[i];
        }
        
        return result;
    }

    static void PrintPolynomial(int[] polynomial)
    {
        for (int i = polynomial.Length - 1; i >= 0; i--)
        {
            if (i != 0)
            {
                Console.Write("{0}x^{1} + ", polynomial[i], i);
            }
            else
            {
                Console.Write("{0}", polynomial[0]);
            }
        }
        Console.WriteLine();
    }

    static void Main()
    {
        Console.WriteLine("This program will add two polynomials, input by the user.");
        // Input
        Console.WriteLine("Enter the first polynomial:");
        int[]poly1 = InitializePolynomial();
        Console.WriteLine("Enter the second polynomial:");
        int[] poly2 = InitializePolynomial();

        // Add polynomials, e.g. add arrays member by member
        int[] result = AddPolynomials(poly1, poly2);

        // Output
        Console.Write("The sum of the two polynomials is ");
        PrintPolynomial(result);
    }
}
