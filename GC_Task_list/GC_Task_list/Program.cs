using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GC_Task_list
{
    class Program
    {

        static List<Task> TaskList = new List<Task>()
        {
            //order string name, string description, string dueDate, bool completion
            new Task("Peter Gibbons", "Turn in TPS reports", "01/01/2019", false),
            new Task("Bill Lumbergh", "Get 3 people to work on Saturday", "11/10/2018", false),
            new Task("Milton Waddams", "Find who took my stapler", "10/31/2018", false)
        };
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the task manager!");
            Pathway();
        }

        static void Pathway()
        {
            try
            {
                Console.WriteLine("\n1. List tasks");
                Console.WriteLine("2. Add task");
                Console.WriteLine("3. Delete task");
                Console.WriteLine("4. Mark task complete");
                Console.WriteLine("5. Quit\n");
                Console.WriteLine("What would you like to do?");
                int choosePath = int.Parse(Console.ReadLine());
                if (choosePath == 1)
                {
                    // display all the tasks
                    Console.WriteLine("\n**TASK LIST**\n");
                    DisplayTask(TaskList);
                }
                if (choosePath == 2)
                {
                    // input task
                    Console.WriteLine("**ADD TASK**");
                    AddTask();
                }
                if (choosePath == 3)
                {
                    // delete task
                    Console.WriteLine("**DELETE TASK**");
                    DeleteTask();
                }
                if (choosePath == 4)
                {
                    // Mark task complete
                    Console.WriteLine("**MARK TASK COMPLETE**");
                    TaskComplete();
                }
                if (choosePath == 5)
                {
                    // quit 
                    Console.WriteLine("Goodbye");
                    Environment.Exit(0);
                }
                if (choosePath >= 6)
                {
                    Console.WriteLine("That is not a choice, try again");
                    Pathway();
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("What was that?");
                Pathway();

            }

            Looper();
        }

        static void DisplayTask(List<Task> TaskList)
        {
            //order string name, string description, string dueDate, bool completion

            Console.WriteLine("{0,-5}{1,-20}{2,-20}{3,-20}{4,-20}", " ", "Name", "Due Date", "Completed?", "Description");
            for (int t = 0; t < TaskList.Count; t++)
            {
                Console.WriteLine("{0, -5}{1,-20}{2,-20}{3,-20}{4,-20}", (t + 1), TaskList[t].Name, TaskList[t].DueDate, TaskList[t].Completion, TaskList[t].Description);
                Console.WriteLine();
            }
        }

        static void AddTask()
        {
            //order string name, string description, string dueDate, bool completion
            Console.WriteLine("Please Enter:");
            Console.WriteLine("Team Member Name: ");
            string nameInput = Console.ReadLine();
            Console.WriteLine("Brief description:");
            string descriptionInput = Console.ReadLine();
            Console.WriteLine("Due Date (format: 00/00/0000): ");
            string dueDate = Console.ReadLine();

            TaskList.Add(new Task(nameInput, descriptionInput, dueDate, false));
            Console.WriteLine("\nNew Task has been added!\n");
            Pathway();
        }

        static void DeleteTask()
        {
            DisplayTask(TaskList);
            Console.WriteLine("Which task would you like to delete?");
            int deleteTask = int.Parse(Console.ReadLine());
            if (deleteTask <= TaskList.Count)
            {
                Console.WriteLine("Do you wish to delete this task? y/n");
                string deleteinput = Console.ReadLine().ToLower();
                if (deleteinput == "y" || deleteinput == "yes")
                {
                    TaskList.Remove(TaskList[deleteTask - 1]);
                    Console.WriteLine("\nThe task has been removed!\n");
                    Pathway();
                }
                if (deleteinput == "no" || deleteinput == "n")
                {
                    Pathway();
                }
                else
                {
                    Console.WriteLine("What?");
                    DeleteTask();
                }
            }
            else
            {
                Console.WriteLine("That number is not in range, try again");
                Console.WriteLine();
                DeleteTask();
            }
        }

        static void TaskComplete()
        {

            DisplayTask(TaskList);
            Console.WriteLine("Which task would you like to complete?");
            int compTask = int.Parse(Console.ReadLine());
            
            //Console.WriteLine(TaskList[compTask - 1]("{1,-20}{2,-20}{3,-20}{4,-20}", Task.Name  , TaskList.DueDate, TaskList.Completion, TaskList.Description));
            if (compTask <= TaskList.Count)
            {
                Console.WriteLine("Do you wish to complete this task? y/n");
                string compinput = Console.ReadLine().ToLower();
                
                if (compinput == "y" || compinput == "yes")
                {

                    TaskList[compTask - 1].Completion = true;

                    Console.WriteLine("\nThe task has been completed!\n");
                    Pathway();
                }
                if (compinput == "no" || compinput == "n")
                {
                    Pathway();
                }
                else
                {
                    Console.WriteLine("What?");
                    TaskComplete();
                }
            }
        }

            static void Looper()
            {
                Console.WriteLine("Back to main menu? y/n");
                string goAgain = Console.ReadLine().ToLower();
                if (goAgain == "y" || goAgain == "yes")
                {
                    Pathway();
                }
                else if (goAgain == "n" || goAgain == "no")
                {
                    SecondTime();
                }
                else
                {
                    Console.WriteLine("That wasn't quite right...try again.");
                    Looper();
                }
            }

            static void SecondTime()
            {
                Console.WriteLine("\nAre you sure? y/n");
                string askAgain = Console.ReadLine().ToLower();
                if (askAgain == "yes" || askAgain == "y")
                {
                    Console.WriteLine("Goodbye");
                    Environment.Exit(0);
                }
                else if (askAgain == "no" || askAgain == "n")
                {
                    Looper();
                }
            }
        }
    }

