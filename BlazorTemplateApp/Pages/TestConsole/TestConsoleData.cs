using System.Collections.ObjectModel;

namespace BlazorTemplateApp.Pages.TestConsole
{
    public class TestConsoleData
    {
        public static ObservableCollection<string> consoleEmulator = new();

        private static string CurrentKey { get; set; } = "";

        private static bool Ready { get; set; }

        public static void MainMethod()
        {
            consoleEmulator = new();

            consoleEmulator.Add("Press Enter to start");
        }

        public static Task Data()
        {
            consoleEmulator.Add("Type [4] for Yes [5] for No");

            while (CurrentKey != "4" || CurrentKey != "5")
            {
                Task.Delay(400);
            }
            CurrentKey = "";

            consoleEmulator.Add($"Key pressed{CurrentKey} = {(CurrentKey == "4" ? "Yes" : "No")}");

            return Task.CompletedTask;
        }

        public static void KeyPressed(string key)
        {
            CurrentKey = key;

            if (Ready == false && CurrentKey == "Enter")
            {
                Ready = true;
                Data();
            }
        }
    }
}
