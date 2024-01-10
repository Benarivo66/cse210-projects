using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        string username = PromptUserName();
        int favNum = PromptUserNumber();
        int squaredNum = SquareNumber(favNum);
        DisplayResult(username, squaredNum);

    }
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }
    static string PromptUserName()
    {
        Console.WriteLine("Please enter your name? ");
        string username = Console.ReadLine();
        return username;
    }
    static int PromptUserNumber()
    {
        Console.WriteLine("Please enter your favorite number? ");
        string userNumberString = Console.ReadLine();
        int userNumber = int.Parse(userNumberString);
        return userNumber;
    }
    static int SquareNumber(int number)
    {
        int squaredNum = number * number;
        return squaredNum;
    }
    static void DisplayResult(string username, int squaredNumber)
    {
        Console.WriteLine($"{username}, the square of your number is {squaredNumber}");
    }
}