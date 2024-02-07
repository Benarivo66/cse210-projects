public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus) : base(name, description, points)
    {
        SetName(name);
        _description = description;
        _points = points;
        _target = target;
        _bonus = bonus;
        _amountCompleted = 0;
        _className = "checklistgoal";
    }

    // public int GetBonus()
    // {
    //     return _bonus;
    // }
    public void SetAmountCompleted(int num)
    {
        _amountCompleted = num;
    }

    public override void RecordEvent()
    {
        _amountCompleted += 1;
        if(IsComplete() == true)
        {
            _points += _bonus;
        }
    }
    public override bool IsComplete()
    {
        if (_amountCompleted == _target)
        {
            return true;
        }
        return false;
    }
    public override string GetDetailsString()
    {
        if (IsComplete() == true)
        {
            return $"[X] {_shortName} ({_description}). --- completion:{_amountCompleted}/{_target}";
        }
        else
        {
            return $"[] {_shortName} ({_description}). --- Completion: {_amountCompleted}/{_target}";
        }
    }
    public override string GetStringRepresentation()
    {
        string goalName = _shortName;
        string goalDescription = _description;
        int goalPoint = _points;
        string line = $"{goalName}~{goalDescription}~{goalPoint}~{_bonus}~{_target}~{_amountCompleted}";
        return line;
    }
}