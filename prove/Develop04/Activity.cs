using System.ComponentModel;

public class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity(int duration)
    {
        _duration = duration;
    }

    public Activity(string name)
    {
        _name = name;
        if (name == "breathing")
        {
            _description = "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing";
        }
        else if (name == "reflecting")
        {
            _description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
        }
        else if (name == "listing")
        {
            _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
        }


    }

    public void DisplayStartingMessage()
    {
        Console.WriteLine($"Welcome to the {_name} activity\n");
        Console.WriteLine($"{_description}\n");
        Console.WriteLine("How long, in seconds, would you like for your session? ");

    }
    public void DisplayEndingMessage()
    {
        Console.WriteLine("Well done!!\n");
        ShowSpinner(2000);
        Console.WriteLine($"\nYou have completed another {_duration} seconds of the {_name} activity.");
        Thread.Sleep(2000);
    }
    public void ShowSpinner(int seconds)
    {
        int div = seconds / 5;
        for (int i = 0; i < seconds; i += div)
        {
            Console.Write("+");
            Thread.Sleep(500);

            Console.Write("\b \b");
            Console.Write("-");
            Thread.Sleep(500);

            Console.Write("\b \b");
        }
    }
    public void ShowCountDown(int seconds)
    {
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(seconds);

        Thread.Sleep(1000);

        while (DateTime.Now < futureTime)
        {
            TimeSpan remainingTime = futureTime - DateTime.Now;
            int remainingSeconds = (int)Math.Round(remainingTime.TotalSeconds);
            Console.Write($"\r{remainingSeconds}");
            Thread.Sleep(1000);
        }
        Console.WriteLine("\r                        ");
    }

}