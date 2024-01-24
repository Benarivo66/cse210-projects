using System;

class Program
{
    static void Main(string[] args)
    {
        string filePath = "Scripture.txt";
        List<string> scriptureOptions = File.ReadAllLines(filePath).ToList();
        string scripturePassage = "";
        
        if(scriptureOptions.Count > 0)
        {
            Random random = new Random();
            int randomIndex = random.Next(0, scriptureOptions.Count);
            scripturePassage = scriptureOptions[randomIndex];
        }
        else
        {
            Console.WriteLine("It seems there are no scriptures in the file");
        }

        string[] refWordsList = scripturePassage.Split("~");
        string[] refParts = refWordsList[0].Split("%");
        string text = refWordsList[1];
        string book = refParts[0];
        int chapter = int.Parse(refParts[1]);
        int verse = int.Parse(refParts[2]);

        int lenOfText = text.Split(" ").Count();
        int divOfText = 5;
        int numOfWordsToHide = (int)Math.Ceiling((double)lenOfText/divOfText);

        Reference reference = new Reference(book, chapter, verse);
        if(refParts.Length == 4)
        {
            int endVerse = int.Parse(refParts[3]);
            reference = new Reference(book, chapter, verse, endVerse);
        }
        Scripture scripture = new Scripture(reference, text);
        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());

        while (true)
        {
            Console.WriteLine("\nPress Enter to continue or type quit to exit");
            string input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                scripture.HideRandomWords(numOfWordsToHide);
                Console.WriteLine(scripture.GetDisplayText());
                if (scripture.IsCompletelyHidden() == true)
                {
                    break;
                }
            }
            else if (input.Trim().ToLower() == "quit")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid input. Press Enter to continue or type 'quit' to exit.");
            }
        }
    }
}