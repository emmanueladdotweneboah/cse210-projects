using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public void AddGoal(Goal goal) => _goals.Add(goal);

    public void RecordEvent(int index)
    {
        if (index < 0 || index >= _goals.Count)
        {
            Console.WriteLine("Invalid index.");
            return;
        }

        int points = _goals[index].RecordEvent();
        _score += points;
        Console.WriteLine(points >= 0
            ? $"You earned {points} points!"
            : $"You lost {-points} points.");
    }

    public void DisplayGoals()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetStatus()} {_goals[i].GetName()}");
        }
    }

    public void ShowScore()
    {
        int level = LevelSystem.CalculateLevel(_score);
        string title = LevelSystem.GetTitle(level);
        Console.WriteLine($"Score: {_score} | Level {level} - {title}");
    }

    public void Save(string filename)
    {
        using StreamWriter writer = new StreamWriter(filename);
        writer.WriteLine(_score);
        foreach (Goal g in _goals)
            writer.WriteLine(g.SaveData());
    }

    public void Load(string filename)
    {
        if (!File.Exists(filename)) return;

        string[] lines = File.ReadAllLines(filename);
        _score = int.Parse(lines[0]);
        _goals.Clear();

        foreach (string line in lines.Skip(1))
        {
            var parts = line.Split('|');
            switch (parts[0])
            {
                case "SimpleGoal":
                    var sg = new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]));
                    if (bool.Parse(parts[4])) sg.RecordEvent();
                    _goals.Add(sg);
                    break;
                case "EternalGoal":
                    _goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
                    break;
                case "ChecklistGoal":
                    var cg = new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[6]), int.Parse(parts[4]));
                    for (int i = 0; i < int.Parse(parts[5]); i++) cg.RecordEvent();
                    _goals.Add(cg);
                    break;
                case "NegativeGoal":
                    var ng = new NegativeGoal(parts[1], parts[2], int.Parse(parts[3]));
                    for (int i = 0; i < int.Parse(parts[4]); i++) ng.RecordEvent();
                    _goals.Add(ng);
                    break;
            }
        }
    }
}