public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points) { }

    public override int RecordEvent() => _points;

    public override bool IsComplete() => false;

    public override string GetStatus() => "[∞]";

    public override string SaveData() =>
        $"EternalGoal|{_name}|{_description}|{_points}";
}

// File: ChecklistGoal.cs
public class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonusPoints;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints)
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _bonusPoints = bonusPoints;
        _currentCount = 0;
    }

    public override int RecordEvent()
    {
        if (_currentCount < _targetCount)
        {
            _currentCount++;
            return _currentCount == _targetCount ? _points + _bonusPoints : _points;
        }
        return 0;
    }

    public override bool IsComplete() => _currentCount >= _targetCount;

    public override string GetStatus() =>
        IsComplete() ? "[X]" : $"[ ] Completed {_currentCount}/{_targetCount} times";

    public override string SaveData() =>
        $"ChecklistGoal|{_name}|{_description}|{_points}|{_bonusPoints}|{_currentCount}|{_targetCount}";
}
