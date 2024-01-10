using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbs = new List<int>();
        int numb = -45;
        while (numb != 0)
        {
            Console.WriteLine("Enter a list of numbers, type 0 when finished");
            string numbString = Console.ReadLine();
            numb = int.Parse(numbString);
            numbs.Add(numb);
        }

        int total = 0;
        int count = 0;
        float average;
        int max = 0;
        foreach (int num in numbs)
        {
            if (num > max)
            {
                max = num;
            }
            if (num != 0) count += 1;
            total += num;
        }

        if (count != 0) average = (float)total / count;
        else average = 0;

        Console.WriteLine($"The sum is: {total}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");
    }
}