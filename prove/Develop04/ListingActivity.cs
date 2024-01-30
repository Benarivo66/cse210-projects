using Microsoft.VisualBasic;

public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts;

    public ListingActivity(int duration) : base(duration)
    {
        _duration = duration;
        _name = "listing";
        _count = 0;
        _prompts = new List<string>{
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?",
        };
    }

    public void Run()
    {
        string filePath = "userlist.txt";

        Console.WriteLine("Get Ready\n");
        ShowSpinner(3000);
        Console.WriteLine("List as many responses as you can to the following prompt. Press Enter after typing each. \n");

        string prompt = GetRandomPrompt();
        Console.WriteLine($"---{prompt}---\n");
        Thread.Sleep(2000);
        Console.WriteLine("You may begin in ...\n");
        ShowCountDown(_duration / 4);

        List<string> userList = GetListFromUser();
        Console.WriteLine($"You listed {_count} items.\n");
        Thread.Sleep(1000);
        DisplayEndingMessage();
        ShowSpinner(2000);

        WriteListToFile(userList, filePath);
    }

    private void WriteListToFile(List<string> list, string filePath)
    {
        using(StreamWriter writer = new StreamWriter(filePath))
        {
            foreach(string item in list)
            {
                writer.WriteLine(item);
            }
        }
    }

    private string GetRandomPrompt()
    {
        Random random = new Random();
        int randomIndex = random.Next(0, _prompts.Count);
        string prompt = _prompts[randomIndex];
        return prompt;
    }

    private List<string> GetListFromUser()
    {
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(_duration);
        List<string> listFromUser = new List<string>();
        while (DateTime.Now < futureTime)
        {
            string input = Console.ReadLine();
            listFromUser.Add(input);
            _count += 1;
        }

        return listFromUser;
    }
}