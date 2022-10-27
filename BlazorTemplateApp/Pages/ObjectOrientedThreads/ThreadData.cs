using System.Collections.ObjectModel;

namespace BlazorTemplateApp.Pages.ObjectOrientedThreads
{
    public static class ThreadData
    {
        static ObservableCollection<string> consoleEmulator = new();
        public static ObservableCollection<string> MainMethod()
        {
            consoleEmulator.Clear(); // Reset Emulator

            Action<object> action = (object obj) => consoleEmulator.Add($"Task={Task.CurrentId}, obj={obj}, Thread={Thread.CurrentThread.ManagedThreadId}");

            // Create a task but do not start it.
            Task t1 = new Task(action, "alpha");

            // Construct a started task
            Task t2 = Task.Factory.StartNew(action, "beta");
            // Block the main thread to demonstrate that t2 is executing
            t2.Wait();

            // Launch t1
            t1.Start();
            consoleEmulator.Add($"t1 has been launched. (Main Thread={Thread.CurrentThread.ManagedThreadId})");

            // Wait for the task to finish.
            t1.Wait();

            // Construct a started task using Task.Run.
            String taskData = "delta";
            Task t3 = Task.Run(() => consoleEmulator.Add($"Task={Task.CurrentId}, obj={taskData}, Thread={Thread.CurrentThread.ManagedThreadId}"));

            // Wait for the task to finish.
            t3.Wait();

            // Construct an unstarted task
            Task t4 = new Task(action, "gamma");
            // Run it synchronously
            t4.RunSynchronously();
            // Although the task was run synchronously, it is a good practice
            // to wait for it in the event exceptions were thrown by the task.
            t4.Wait();

            return consoleEmulator;
        }
    }
}
