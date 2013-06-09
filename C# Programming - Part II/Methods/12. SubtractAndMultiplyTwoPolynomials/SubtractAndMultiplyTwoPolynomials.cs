using System;
using System.Collections.Generic;

class AddTwoPolynomials
{
    static int[] InitializePolynomial()
    {
        Console.Write("\tEnter the degree of the polynomial: ");
        int degree = int.Parse(Console.ReadLine());
        int[] polynomial = new int[degree + 1];
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

    // To subtract two polynomials, we will need a modified version of the algorithm to add two polynomials
    static int[] SubtractPolynomials(int[] first, int[] second)
    {
        // Check which is the bigger array
        int minLength = Math.Min(first.Length, second.Length);
        int maxLength = Math.Max(first.Length, second.Length);
        int[] result = new int[maxLength];

        // If the first array is longer or the lengths of the arrays are the same
        if (first.Length >= second.Length)
        {
            for (int i = 0; i < second.Length; i++)
            {
                result[i] = first[i] - second[i];
            }
            for (int i = second.Length; i < first.Length; i++)
            {
                result[i] = first[i];
            }
        }
        else
            // If the second array is longer
        {
            for (int i = 0; i < first.Length; i++)
            {
                result[i] = first[i] - second[i];
            }
            for (int i = first.Length; i < second.Length; i++)
            {
                result[i] = -second[i];
            }
        }
        return result;
    }

    // Multiplication of polynomials is multiplication member by member. 
    // We can represent this as an array whose length is the sum of the two lengths
    static int[] MultiplyPolynomials(int[] first, int[] second)
    {
        int[] result = new int[first.Length + second.Length - 1];
        for (int i = 0; i < first.Length; i++)
        {
            for (int j = 0; j < second.Length; j++)
            {
                result[i + j] += first[i] * second[j];
            }
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
        Console.WriteLine("This program will subtract and multiply two polynomials, input by the user.");
        // Input
        Console.WriteLine("Enter the first polynomial:");
        int[] poly1 = InitializePolynomial();
        Console.WriteLine("Enter the second polynomial:");
        int[] poly2 = InitializePolynomial();

        // Subtract polynomials, e.g. subtract arrays member by member
        int[] difference = SubtractPolynomials(poly1, poly2);

        //Multiply polynomials
        int[] product = MultiplyPolynomials(poly1, poly2);

        // Output
        Console.Write("The difference of the two polynomials is ");
        PrintPolynomial(difference);
        Console.Write("The product of the two polynomials is ");
        PrintPolynomial(product);
    }
}
