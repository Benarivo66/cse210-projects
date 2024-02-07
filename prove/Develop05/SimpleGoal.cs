using System.ComponentModel;

public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points, bool isComplete) : base(name, description, points)
    {
        _shortName = name;
        _description = description;
        _points = points;
        _isComplete = isComplete;
        _className = "simplegoal";
    }

    public void SetIsComplete(bool boolean)
    {
        _isComplete = boolean;
    }

    public override void RecordEvent()
    {
        _isComplete = true;
    }
    public override bool IsComplete()
    {
        return _isComplete;
    }
    public override string GetStringRepresentation()
    {
        string goalName = _shortName;
        string goalDescription = _description;
        int goalPoint = _points;
        string line = $"{goalName}~{goalDescription}~{goalPoint}~{_isComplete}";
        return line;
    }
}