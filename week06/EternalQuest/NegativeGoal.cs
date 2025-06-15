public class NegativeGoal : Goal
{
    private int _timesTriggered;
    private int _penaltyPoints;

    public NegativeGoal(string name, string description, int penaltyPoints)
        : base(name, description, -penaltyPoints)
    {
        _penaltyPoints = penaltyPoints;
        _timesTriggered = 0;
    }

    public override int RecordEvent()
    {
        _timesTriggered++;
        return _points; // negative value
    }

    public override bool IsComplete() => false;

    public override string GetStatus() => $"[!] Triggered {_timesTriggered} times";

    public override string SaveData() =>
        $"NegativeGoal|{_name}|{_description}|{_penaltyPoints}|{_timesTriggered}";
}