using System.Drawing;

public abstract class Goal
{
    protected string _shortName;
    protected string _description;
    protected int _points;
    protected string _className;

    public Goal(string name, string description, int points)
    {
        SetName(name);
        _description = description;
        SetPoints(points);
    }

    public void SetPoints(int point)
    {
        _points = point;
    }
    public int GetPoints()
    {
        return _points;
    }
    
    public void SetName(string name)
    {
        _shortName = name;
    }
    public string GetName()
    {
        return _shortName;
    }

    public abstract void RecordEvent();
    
    public abstract bool IsComplete();
    
    public virtual string GetDetailsString()
    {
        if(IsComplete() == true)
        {
            return $"[X] {_shortName} ({_description}).";
        }
        else
        {
            return $"[] {_shortName} ({_description}).";
        }
    }
    public abstract string GetStringRepresentation();

    
}