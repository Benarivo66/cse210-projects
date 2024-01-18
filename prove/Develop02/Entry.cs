public class Entry
{   
    public string _date = "";
    public string _promptText = "";
    public string _entryText = "";
    public string _location = "";



    public void Display()
    {
        Console.WriteLine($"Date: {_date}.\nLocation: {_location}.\nPrompt: {_promptText}.\nResponse: {_entryText}.\n");
    }

}