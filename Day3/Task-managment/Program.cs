using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;

public enum TaskCategory
{
    Personal,
    Work, 
    Errands
}

public class Task
{
    public string?  Name { get; set;}
    public string?  Description { get; set;}
    public TaskCategory Category{ get; set;}
    public bool? IsCompleted { get; set;}
}

public class TaskManager
{
    List<Task> Tasks;
    private string filePath = "tasks.csv";

    public TaskManager()
    {
        Tasks = new List<Task>();
        ReadFromFile();
    }

    public async void AddTask(string name, string description, string category, bool isCompleted)
    {
        try
        {
            TaskCategory category_ = (TaskCategory)Enum.Parse(typeof(TaskCategory), category);
            Tasks.Add(new Task { Name = name, Description = description, Category = category_, IsCompleted = isCompleted });
            string taskText = $"{name},{description},{category},{isCompleted}\n";
            await using (var stream = new FileStream(filePath, FileMode.Append))
            {
                using (var writer = new StreamWriter(stream))
                {
                    await writer.WriteAsync(taskText);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private async void RewriteToFile()
    {
        try
        {
            await using (var stream = new FileStream(filePath, FileMode.Truncate))
            {
                stream.SetLength(0);
            }
            foreach (Task task in Tasks)
            {
                string taskText = $"{task.Name},{task.Description},{task.Category},{task.IsCompleted}\n";
                await using (var stream = new FileStream(filePath, FileMode.Append))
                {
                    using (var writer = new StreamWriter(stream))
                    {
                        await writer.WriteAsync(taskText);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private async void ReadFromFile()
    {
        try
        {
            string[] lines = await File.ReadAllLinesAsync(filePath);

            foreach (string line in lines)
            {
                string[] values = line.Split(',');
                TaskCategory category = (TaskCategory)Enum.Parse(typeof(TaskCategory), values[2]);
                Tasks.Add(new Task { Name = values[0], Description = values[1], Category = category, IsCompleted = bool.Parse(values[3]) });
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public void RemoveTask(string name)
    {
        Task? removeTask = Tasks.Find(task => task.Name == name);
        if (removeTask == null) return;
        Tasks.Remove(removeTask);
        RewriteToFile();
    }

    public void DisplayTasks(List<Task>? tasks = null)
    {
        if (tasks == null)
        {
            tasks = Tasks;
        }
        Console.WriteLine("All Tasks:");
        foreach (Task task in tasks)
        {
            Console.WriteLine($"Name - {task.Name} Description - {task.Description} Catagory - {task.Category} complete - {task.IsCompleted}");
        }
        RewriteToFile();
    }

    public void DisplayTasksByCatagory(string category)
    {
        TaskCategory category_ = (TaskCategory)Enum.Parse(typeof(TaskCategory), category);
        List<Task> filteredTasks = Tasks.Where(task => task.Category == category_).ToList();
        Console.WriteLine($"Filtered Tasks of {category}:");
        foreach (Task task in filteredTasks)
        {
            Console.WriteLine($"Name - {task.Name} Description - {task.Description} Catagory - {task.Category} complete - {task.IsCompleted}");
        }
        RewriteToFile();

    }
}

public class Program
{

    public static void Main(){

        TaskManager taskManager =  new TaskManager();

        taskManager.AddTask("pay bill", "pay bills", "Errands", true);
        taskManager.AddTask("eat", "eat lunch", "Personal", false);
        taskManager.AddTask("do homework", "finish homework", "Work", false);
        
        taskManager.RemoveTask("eat");

        taskManager.DisplayTasksByCatagory("Work");
        taskManager.DisplayTasks();

    }
}

