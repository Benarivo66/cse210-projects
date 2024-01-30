public class BreathingActivity : Activity
{
    public BreathingActivity(int duration) : base(duration)
    {
        _duration = duration;
        _name = "breathing";
    }



    public void Run()
    {
        Console.WriteLine("Get Ready");
        int duration = _duration;
        ShowSpinner(3000);
        int divisions = 4;
        int countDownTime = duration / divisions;
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(_duration);
        while (DateTime.Now < futureTime)
        {
            Console.Write($"Breathe in...\n");
            ShowCountDown(countDownTime);
            Console.WriteLine();
            duration -= countDownTime;
            if (duration <= 0)
            {
                break;
            }
            Console.Write($"Breathe out...\n");
            ShowCountDown(countDownTime);
            Console.WriteLine();
            duration -= countDownTime;
        }

        DisplayEndingMessage();
    }
}