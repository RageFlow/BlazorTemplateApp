using System.Collections.ObjectModel;

namespace BlazorTemplateApp.Pages.TaskException
{
    public class TaskExceptionData
    {
        public static ObservableCollection<string> consoleEmulator = new();

        public static async void MainMethod()
        {
            string coffee = "Gevalia";

            TaskScheduler.UnobservedTaskException +=
                (object sender, UnobservedTaskExceptionEventArgs e) =>
                {
                    consoleEmulator.Add("UnobservedTaskEception");
                };
            try
            {
                await Task.Run(() => TestTask(coffee));
            }
            catch (Exception e)
            {
                consoleEmulator.Add("Exception: " + e.Message);
                return;
            }
        }

        public static async Task TestTask(string item)
        {
            await Task.Delay(3000);
            throw new ArgumentNullException();
        }

        public async Task GetCoffee(Action<IEnumerable<string>> callback)
        {

        }
    }
}
