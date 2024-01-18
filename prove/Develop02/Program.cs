using System;

class Program
{
    static void Main(string[] args)
    {
        DateTime theCurrentTime = DateTime.Now;
        string dateText = theCurrentTime.ToShortDateString();

        Journal journal = new Journal();

        List<string> prompts = new List<string>{
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I could change one thing today, what would it be?",
            "What did I do to bless others today?",
            "How did I draw closer to my goals today?"
        };

        Console.WriteLine("Welcome to the Journal Program\nPlease select one of the following choices:");
        Console.Write("1. Write\n");
        Console.Write("2. Display\n");
        Console.Write("3. Load\n");
        Console.Write("4. Save\n");
        Console.Write("5. Exit\n");
        string strMenuResp = Console.ReadLine();
        int menuResp = 0;
        if (int.TryParse(strMenuResp, out int parsedMenuResp))
        {
            menuResp = parsedMenuResp;
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid menu option.");
        }
        while (menuResp != 5)
        {
            if (menuResp == 1)
            {   
                Entry entry = new Entry();
                PromptGenerator promptGen = new PromptGenerator();
                promptGen._prompts = prompts;
                string randomPrompt = promptGen.GetRandomPrompt();
                Console.WriteLine(randomPrompt);
                Console.Write("> ");
                string resp = Console.ReadLine();

                entry._date = dateText;
                entry._promptText = randomPrompt;
                entry._entryText = resp;

                journal.AddEntry(entry);
            }
            else if (menuResp == 2)
            {
                    journal.DisplayAll();
                }
            else if (menuResp == 3)
            {
                Console.WriteLine("What is the file name?");
                Console.Write("> ");
                string fileName = Console.ReadLine();
                journal.LoadFromFile(fileName);
            }
            else if (menuResp == 4)
            {
                Console.WriteLine("What is the file name?");
                Console.Write("> ");
                string fileName = Console.ReadLine();
                journal.SaveToFile(fileName);
            }
            else
            {
                Console.WriteLine("Enter a number from one of the displayed numbers in the prompt");
            }
            Console.WriteLine("Welcome to the Journal Program\nPlease select one of the following choices:");
            Console.Write("1. Write\n");
            Console.Write("2. Display\n");
            Console.Write("3. Load\n");
            Console.Write("4. Save\n");
            Console.Write("5. Exit\n");

            strMenuResp = Console.ReadLine();
            if (int.TryParse(strMenuResp, out int parsedMenuRes))
            {
                menuResp = parsedMenuRes;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid menu option.");
            }
        }
    }
}