using System;

class Program
{
    static int Helper(string action)
    {
        Activity activity = new Activity(action);
        activity.DisplayStartingMessage();
        string sessionLenStr = Console.ReadLine();
        int sessionLen = int.Parse(sessionLenStr);
        return sessionLen;
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Menu Options:");
        Console.WriteLine("1. Start breathing activity:");
        Console.WriteLine("2. Start reflecting activity");
        Console.WriteLine("3. Start listing activity");
        Console.WriteLine("4. Quit\n");
        Console.WriteLine("Select a choice from the menu (type the corresponding number):");

        string menuStr = Console.ReadLine();
        int menu = int.Parse(menuStr);

        while (menu != 4)
        {
            if (menu == 1)
            {
                // Activity activity = new Activity("breathing");
                // activity.DisplayStartingMessage();
                // string sessionLenStr = Console.ReadLine();
                // int sessionLen = int.Parse(sessionLenStr);
                int sessionLen = Helper("breathing");
                BreathingActivity breathingActivity = new BreathingActivity(sessionLen);
                breathingActivity.Run();
            }
            else if (menu == 2)
            {
                // Activity activity = new Activity("reflecting");
                // activity.DisplayStartingMessage();
                // string sessionLenStr = Console.ReadLine();
                // int sessionLen = int.Parse(sessionLenStr);
                int sessionLen = Helper("reflecting");
                ReflectingActivity reflectingActivity = new ReflectingActivity(sessionLen);
                reflectingActivity.Run();
            }
            else if (menu == 3)
            {
                // Activity activity = new Activity("listing");
                // activity.DisplayStartingMessage();
                // string sessionLenStr = Console.ReadLine();
                // int sessionLen = int.Parse(sessionLenStr);
                int sessionLen = Helper("listing");
                ListingActivity listingActivity = new ListingActivity(sessionLen);
                listingActivity.Run();
            }
            else if (menu == 4)
            {
                break;
            }

            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Start breathing activity:");
            Console.WriteLine("2. Start reflecting activity");
            Console.WriteLine("3. Start listing activity");
            Console.WriteLine("4. Quit\n");
            Console.WriteLine("Select a choice from the menu (type the corresponding number)");

            menuStr = Console.ReadLine();
            menu = int.Parse(menuStr);
        }
    }
}