using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) : base(name, description, points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    public override void RecordEvent()
    {}
    public override bool IsComplete()
    {
        return false;
    }
    public override string GetStringRepresentation()
    {
        string goalName = _shortName;
        string goalDescription = _description;
        int goalPoint = _points;
        string line = $"{goalName}~{goalDescription}~{goalPoint}";
        return line;
    }
}