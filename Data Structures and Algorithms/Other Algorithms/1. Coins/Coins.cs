using System;
using System.Linq;

public class Coins
{
    public static void Main()
    {
        Console.Write("Enter the desired sum (in coins): ");
        ulong sum = ulong.Parse(Console.ReadLine());
        int[] coins = new int[] { 5, 2, 1 };
        ulong numberOfCoins = GetCoins(coins, sum);

        Console.WriteLine("The sum {0} can be made with {1} coin(s).", sum, numberOfCoins);
    }

    private static ulong GetCoins(int[] coins, ulong sum)
    {
        ulong currentSum = 0;
        ulong currentCoins = 0;
        ulong maximalCoin = (ulong)coins.Max();

        while (sum - currentSum >= maximalCoin)
        {
            currentSum += maximalCoin;
            currentCoins++;
        }

        if (currentSum == sum)
        {
            return currentCoins;
        }

        int[] remaining = coins.Where(coin => coin != coins.Max()).ToArray();

        if (remaining.Length == 0)
        {
            throw new ArgumentException("There are not enough coins to fulfil the order.");
        }

        // If the sum is more than needed, try to remove coins
        for (ulong i = 0; i <= currentCoins; i++)
        {
            ulong lowerSum = GetCoins(remaining, sum - currentSum + (i * maximalCoin));

            if (lowerSum == 0)
            {
                continue;
            }

            return lowerSum + currentCoins - i;
        }

        throw new ArgumentException("The sum cannot be reached with the given coins.");
    }
}