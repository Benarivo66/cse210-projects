public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;

    public ReflectingActivity(int duration) : base(duration)
    {
        _duration = duration;
        _name = "reflecting";
        _prompts = new List<string> {
            "Think of a time when you stood up for someone else",
            "Think of a time when you did something really difficult",
            "Think of a time when you helped someone in need",
            "Think of a time when you did something truly selfless"
        };
        _questions = new List<string> {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?",
        };
    }

    public void Run()
    {
        DisplayPrompt();
        string input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Now ponder each of the following questions as they related to this question:\n");
            int duration = _duration;
            int divisions = 4;
            int countDownTime = duration / divisions;
            DateTime startTime = DateTime.Now;
            DateTime futureTime = startTime.AddSeconds(_duration);
            Console.WriteLine("You may begin in ...\n");
            ShowCountDown(countDownTime);
            while (DateTime.Now < futureTime)
            {
                DisplayQuestion();
            }

            DisplayEndingMessage();
            ShowSpinner(2000);
        }
    }
    public string GetRandomPrompt()
    {
        Random random = new Random();
        int randomIndex = random.Next(0, _prompts.Count);
        string prompt = _prompts[randomIndex];
        return prompt;
    }
    public string GetRandomQuestion()
    {
        Random random = new Random();
        int randomIndex = random.Next(0, _questions.Count);
        string question = _questions[randomIndex];
        return question;
    }
    public void DisplayPrompt()
    {
        Console.WriteLine("Get Ready\n");
        Thread.Sleep(1000);
        Console.WriteLine("Consider the following prompt:\n");
        string prompt = GetRandomPrompt();
        Console.WriteLine($"---{prompt}---\n");
        Thread.Sleep(2000);
        Console.WriteLine("When you have something in mind click Enter to continue");
    }
    public void DisplayQuestion()
    {
        string question = GetRandomQuestion();
        Console.WriteLine(question);
        Thread.Sleep(3000);
        Console.WriteLine();
        ShowSpinner(2000);
    }

}