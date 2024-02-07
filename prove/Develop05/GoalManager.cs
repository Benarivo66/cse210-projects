public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _score = 0;
        _goals = new List<Goal>();
    }

    public void Start()
    {
        try
        {
            Console.WriteLine($"You have {_score} points.\n");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Events");
            Console.WriteLine("6. Quit");

            Console.WriteLine("Select a choice from the menu");
            string menuResponseStr = Console.ReadLine();

            Helper(menuResponseStr);

            int menuResp = int.Parse(menuResponseStr);

            while (menuResp != 6)
            {
                if (menuResp == 1)
                {
                    CreateGoal();
                }
                else if (menuResp == 2)
                {
                    DisplayPlayerInfo();
                    ListGoalDetails();
                }
                else if (menuResp == 3)
                {
                    SaveGoals();

                }

                else if (menuResp == 4)
                {
                    LoadGoals();
                }
                else if (menuResp == 5)
                {
                    RecordEvent();
                }
                else
                {
                    Console.WriteLine("Type a valid input");
                }

                Console.WriteLine($"You have {_score} points.\n");
                Console.WriteLine("Menu Options:");
                Console.WriteLine("1. Create New Goal");
                Console.WriteLine("2. List Goals");
                Console.WriteLine("3. Save Goals");
                Console.WriteLine("4. Load Goals");
                Console.WriteLine("5. Record Events");
                Console.WriteLine("6. Quit");

                Console.WriteLine("Select a choice from the menu");
                menuResponseStr = Console.ReadLine();
                menuResp = int.Parse(menuResponseStr);
            }
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }

    }

    private void Helper(string userInput)
    {
        int number;
        if (!int.TryParse(userInput, out number))
        {
            throw new ArgumentException("Error: Input cannot be parsed to an integer.");
        }
    }

    private void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {_score} points.\n");
    }
    private void ListGoalNames()
    {
        foreach (Goal goal in _goals)
        {
            Console.WriteLine(goal.GetName());
        }
    }
    private void ListGoalDetails()
    {
        for (int i = 0; i < _goals.Count(); i++)
        {
            Goal goal = _goals[i];
            Console.WriteLine($"{i + 1}. {goal.GetDetailsString()}");
        }
    }

    private void CreateGoal()
    {
        try
        {
        Console.WriteLine("The three types of Goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");

        string goalTypeStr = Console.ReadLine();
        Helper(goalTypeStr);
        int goalType = int.Parse(goalTypeStr);
        if (goalType == 1)
        {
            Console.WriteLine("What is the name of your goal?");
            string goalName = Console.ReadLine();
            Console.WriteLine("What is a short description of it?");
            string goalDescription = Console.ReadLine();
            Console.WriteLine("What is the amount of points associated with this goal? ");
            int goalPoints = int.Parse(Console.ReadLine());
            SimpleGoal simpleGoal = new SimpleGoal(goalName, goalDescription, goalPoints, false);
            _goals.Add(simpleGoal);
        }
        else if (goalType == 2)
        {
            Console.WriteLine("What is the name of your goal?");
            string goalName = Console.ReadLine();
            Console.WriteLine("What is a short description of it?");
            string goalDescription = Console.ReadLine();
            Console.WriteLine("What is the amount of points associated with this goal? ");
            int goalPoints = int.Parse(Console.ReadLine());
            EternalGoal eternalGoal = new EternalGoal(goalName, goalDescription, goalPoints);
            _goals.Add(eternalGoal);
        }
        else if (goalType == 3)
        {
            Console.WriteLine("What is the name of your goal?");
            string goalName = Console.ReadLine();
            Console.WriteLine("What is a short description of it?");
            string goalDescription = Console.ReadLine();
            Console.WriteLine("What is the amount of points associated with this goal?");
            int goalPoints = int.Parse(Console.ReadLine());
            Console.WriteLine("How many times does this goal needs to be accomplished for a bonus?");
            int target = int.Parse(Console.ReadLine());
            Console.WriteLine("What is the bonus for accomplishing it that many times?");
            int bonus = int.Parse(Console.ReadLine());
            ChecklistGoal checklistGoal = new ChecklistGoal(goalName, goalDescription, goalPoints, target, bonus);
            _goals.Add(checklistGoal);
        }
        else
        {
            Console.WriteLine("Your input is not valid. Choose one of the numbers seen.");
        }
        }
        catch(ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    private void RecordEvent()
    {
        ListGoalDetails();
        Console.WriteLine("Record an Event. Type the number corresponding to the event you want to record.");
        int eventToRecord = int.Parse(Console.ReadLine());
        Goal goal = _goals[eventToRecord - 1];
        if (goal.IsComplete() == false)
        {
            goal.RecordEvent();
            _score += goal.GetPoints();
            Console.WriteLine($"Congratulations, you have {_score} points");
        }


    }
    private void SaveGoals()
    {
        Console.WriteLine("What is the name of the goal file? (Only .csv and .txt are accepted).");
        string filePath = Console.ReadLine();
        if (string.IsNullOrEmpty(filePath))
        {
            throw new ArgumentException("Error: File path cannot be null or empty.");
        }
        else if (!filePath.EndsWith(".csv", StringComparison.OrdinalIgnoreCase) &&
         !filePath.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
        {
            throw new ArgumentException("Error: File path must have a valid file extension.");
        }
        else if (filePath.GetType() != typeof(string))
        {
            throw new ArgumentException("Error: File path must be a string.");
        }


        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                string stringRep = goal.GetStringRepresentation();
                writer.WriteLine(stringRep);
            }
        }
    }
    private void LoadGoals()
    {
        Console.WriteLine("What is the name of the goal file? (Only .csv and .txt are accepted).");
        string filePath = Console.ReadLine();
        if (string.IsNullOrEmpty(filePath))
        {
            throw new ArgumentException("Error: File path cannot be null or empty.");
        }
        else if (!System.IO.File.Exists(filePath))
        {
            throw new ArgumentException("Error: File not found.");
        }
        else if (filePath.GetType() != typeof(string))
        {
            throw new ArgumentException("Error: File path must be a string.");
        }


        string[] lines = System.IO.File.ReadAllLines(filePath);
        _score = int.Parse(lines[0]);
        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];
            string[] parts = line.Split("~");
            if (parts.Length == 4)
            {
                string name = parts[0];
                string description = parts[1];
                int point = int.Parse(parts[2]);
                bool boolean = bool.Parse(parts[3]);
                SimpleGoal simpleGoal = new SimpleGoal(name, description, point, boolean);
                _goals.Add(simpleGoal);
            }
            else if (parts.Length == 3)
            {
                string name = parts[0];
                string description = parts[1];
                int point = int.Parse(parts[2]);
                EternalGoal eternalGoal = new EternalGoal(name, description, point);
                _goals.Add(eternalGoal);
            }
            else if (parts.Length == 6)
            {
                string name = parts[0];
                string description = parts[1];
                int point = int.Parse(parts[2]);
                int bonus = int.Parse(parts[3]);
                int target = int.Parse(parts[4]);
                int achieved = int.Parse(parts[5]);
                ChecklistGoal checklistGoal = new ChecklistGoal(name, description, point, target, bonus);
                checklistGoal.SetAmountCompleted(achieved);
                _goals.Add(checklistGoal);
            }
        }
    }
}