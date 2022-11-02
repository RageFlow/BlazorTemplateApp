using BlazorTemplateApp.Shared;
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

        private static int Step { get; set; } = 0;
        public static Task Data()
        {
            if (Step == 0)
            {
                consoleEmulator.Add("Type [4] for Yes [5] for No");

                ConsoleEmulator.CleanInput();
                Step++; // Go to next step
            }
            else if (Step == 1)
            {
                if (CurrentKey == "4" || CurrentKey == "5")
                {
                    consoleEmulator.Add($"Key pressed {CurrentKey} = {(CurrentKey == "4" ? "Yes" : "No")}");

                    ConsoleEmulator.CleanInput();
                    Step++;
                }
            }
            if (Step == 2)
            {
                consoleEmulator.Add("Type [1] for Cow [2] for Squirrel");

                ConsoleEmulator.CleanInput();
                Step++; // Go to next step
            }
            else if (Step == 3)
            {
                if (CurrentKey == "1" || CurrentKey == "2")
                {
                    consoleEmulator.Add($"Key pressed {CurrentKey} = {(CurrentKey == "2" ? "Cow" : "Squirrel")}");

                    ConsoleEmulator.CleanInput();
                    Step++;
                }
            }

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
            else if(Ready == true)
            {
                Data();
            }
        }
    }
}
