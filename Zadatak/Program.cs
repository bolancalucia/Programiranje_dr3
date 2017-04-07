using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak
{
    class Program
    {
        static void Main(string[] args)
        {
            Task task1 = new Task("QuickSort", "Napiši pseukod za algoritam", 3, 40);
            Task task2 = new Task("Rekurzija", "Rijesi zadatak metodom rekurzivnog stabla", 4, 50);

            Test test1 = new Test("Algoritmi 1.kolokvij", new List<Task>() {task1, task2 });

            Console.WriteLine("\nUkupan broj bodova na ispitu: " + test1.TotalPoints());
            Console.WriteLine("\nProsječna težina zadataka: " + test1.AverageDifficulty());
            Console.WriteLine("\nUkupno skupljeno bodova na ispitu: " + test1.TotalEarnedPoints());

            test1.SolveTasksEasierThan(4);
            Console.WriteLine("\nUkupan broj skupljenih bodova na ispitu nakon unesene težine zadataka: " + test1.TotalEarnedPoints());

            test1.PrintAllTasks();
        }

        class Task
        {
            public string Name;
            public string Text;
            public int Difficulty;
            public int Points;
            public bool Solved;

            public Task(string name, string text, int difficulty, int points)
            {
                Name = name;
                Text = text;
                Difficulty = difficulty;
                Points = points;
                Solved = false;
            }

            public string Print()
            { 
                return $"{Name} {Difficulty}|{Points}|{Solved}";
            }
        }

        class Test
        {
            public string Name;
            public List<Task> Tasks;  // = new List<Task>();

            public Test()
            {

            }

            public Test(string name, List<Task> tasks)
            {
                Name = name;
                Tasks = tasks;
            }

            public int TotalPoints()
            {
                int Total = 0;
                foreach (Task task in Tasks)
                    Total += task.Points;
                
                return Total;
            }

            public double AverageDifficulty()
            {
                double Average = 0;
                foreach (Task task in Tasks)
                    Average += task.Difficulty;

                Average /= Tasks.Count();
                return Average;
            }

            public int TotalEarnedPoints()
            {
                int EarnedPoints = 0;
                foreach (Task task in Tasks)
                    if (task.Solved)
                        EarnedPoints += task.Points;

                return EarnedPoints;
            }

            public void SolveTasksEasierThan(int difficulty) 
            {
                foreach (Task task in Tasks)
                    if (task.Difficulty < difficulty)
                        task.Solved = true;
            }

            public void PrintAllTasks()
            {
                foreach (Task task in Tasks)
                    Console.WriteLine(task.Print()); 
            }
        }

    }
}
