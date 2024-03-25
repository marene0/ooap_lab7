using System;

// Base class for each worker
abstract class Worker
{
    protected Worker _nextWorker;

    public void SetNextWorker(Worker nextWorker)
    {
        _nextWorker = nextWorker;
    }

    public abstract void ProcessTask(string task);
}

// Editor
class Editor : Worker
{
    public override void ProcessTask(string task)
    {
        if (task.Contains("edits"))
        {
            Console.WriteLine("Editor processes the task: " + task);
        }
        else if (_nextWorker != null)
        {
            _nextWorker.ProcessTask(task);
        }
    }
}

// Layout designer
class LayoutDesigner : Worker
{
    public override void ProcessTask(string task)
    {
        if (task.Contains("layout"))
        {
            Console.WriteLine("Layout designer processes the task: " + task);
        }
        else if (_nextWorker != null)
        {
            _nextWorker.ProcessTask(task);
        }
    }
}

// Designer
class Designer : Worker
{
    public override void ProcessTask(string task)
    {
        if (task.Contains("design"))
        {
            Console.WriteLine("Designer processes the task: " + task);
        }
        else if (_nextWorker != null)
        {
            _nextWorker.ProcessTask(task);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create workers
        var editor = new Editor();
        var layoutDesigner = new LayoutDesigner();
        var designer = new Designer();

        // Set up the chain of responsibility
        editor.SetNextWorker(layoutDesigner);
        layoutDesigner.SetNextWorker(designer);

        // Tasks to be processed
        string[] tasks = {
            "Make edits",
            "Format layout",
            "Create design",
            "Edit text",
            "Align pages"
        };

        // Process tasks
        foreach (var task in tasks)
        {
            Console.WriteLine("New task: " + task);
            editor.ProcessTask(task);
            Console.WriteLine();
        }
    }
}
