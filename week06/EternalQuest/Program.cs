using System;

class Program
{
    static void Main()
    {
        GoalManager manager = new GoalManager();
        string filename = "goals.txt";

        while (true)
        {
            Console.WriteLine("\nEternal Quest Menu:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Goal Event");
            Console.WriteLine("4. Show Score");
            Console.WriteLine("5. Save Goals");
            Console.WriteLine("6. Load Goals");
            Console.WriteLine("7. Exit");
            Console.Write("Choose an option: ");

            switch (Console.ReadLine())
            {
                case "1": CreateGoal(manager); break;
                case "2": manager.DisplayGoals(); break;
                case "3":
                    manager.DisplayGoals();
                    Console.Write("Enter goal number to record: ");
                    if (int.TryParse(Console.ReadLine(), out int index))
                        manager.RecordEvent(index - 1);
                    break;
                case "4": manager.ShowScore(); break;
                case "5": manager.Save(filename); Console.WriteLine("Saved."); break;
                case "6": manager.Load(filename); Console.WriteLine("Loaded."); break;
                case "7": return;
                default: Console.WriteLine("Invalid choice."); break;
            }
        }
    }

    static void CreateGoal(GoalManager manager)
    {
        Console.WriteLine("Choose goal type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.WriteLine("4. Negative Goal");
        Console.Write("Choice: ");
        string type = Console.ReadLine();

        Console.Write("Name: "); string name = Console.ReadLine();
        Console.Write("Description: "); string desc = Console.ReadLine();

        if (type == "1" || type == "2" || type == "3")
        {
            Console.Write("Points: ");
            int points = int.Parse(Console.ReadLine());

            switch (type)
            {
                case "1": manager.AddGoal(new SimpleGoal(name, desc, points)); break;
                case "2": manager.AddGoal(new EternalGoal(name, desc, points)); break;
                case "3":
                    Console.Write("Target count: ");
                    int target = int.Parse(Console.ReadLine());
                    Console.Write("Bonus points: ");
                    int bonus = int.Parse(Console.ReadLine());
                    manager.AddGoal(new ChecklistGoal(name, desc, points, target, bonus));
                    break;
            }
        }
        else if (type == "4")
        {
            Console.Write("Penalty points: ");
            int penalty = int.Parse(Console.ReadLine());
            manager.AddGoal(new NegativeGoal(name, desc, penalty));
        }
    }
}
