public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        string[] strList = text.Split(" ");
        foreach (string str in strList)
        {
            Word word = new Word(str);
            _words.Add(word);
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        for (int i = 0; i < numberToHide; i++)
        {
            Random random = new Random();
            int index = random.Next(_words.Count);
            Word word = _words[index];
            word.Hide();
        }
    }
    public string GetDisplayText()
    { 
        string reference = _reference.GetDisplayText();
        string words = ""; 
        for(int i = 0; i < _words.Count; i++)
        {
            Word word = _words[i];
            string text = word.GetDisplayText();
            if(i == _words.Count - 1)
            {
                words += $"{text}";
            }else
            {
                words += $"{text} ";
            }
        }
        
        return $"{reference} {words}";
    }
    public bool IsCompletelyHidden()
    { 
        foreach (Word word in _words)
        {
            if(word.GetDisplayText() != "____")
            {
                return false;
            }
        }

        return true;
    }
}