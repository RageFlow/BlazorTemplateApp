using System.Collections.ObjectModel;

namespace BlazorTemplateApp.Pages.ThreadsWithBlock
{
    public class ThreadsWithBlockData
    {
        public static ObservableCollection<string> consoleEmulator = new();

        private static bool _stopThreads;
        private static string _threadOutput = "";

        private static AutoResetEvent _blockThread1 = new AutoResetEvent(false);
        private static AutoResetEvent _blockThread2 = new AutoResetEvent(true);
        public static void MainMethod()
        {
            consoleEmulator = new();

            try
            {
                Thread thread1 = new Thread(new ThreadStart(DisplayThread_1));
                Thread thread2 = new Thread(new ThreadStart(DisplayThread_2));
                // start them
                thread1.Start();
                thread2.Start();
            }
            catch (Exception e)
            {
                consoleEmulator.Add("Exception: " + e.Message + " Target: " + e.TargetSite?.ToString() + $" - ( ThreadsWithBlock.MainMethod() )");
                return;
            }
        }

        private static void DisplayThread_1()
        {
            while (_stopThreads == false)
            {
                // block thread 1  while the thread 2 is executing
                _blockThread1.WaitOne();

                // Set was called to free the block on thread 1, continue executing the code
                consoleEmulator.Add("Display Thread 1");

                _threadOutput = "Hello Thread 1";
                Thread.Sleep(1000);  // simulate a  lot of processing

                // tell the user what thread we are in thread #1  
                consoleEmulator.Add($"Thread 1 Output -- > {_threadOutput}");

                // finished executing the code in thread 1, so unblock thread 2  
                _blockThread2.Set();
            }
        }

        private static void DisplayThread_2()
        {
            while (_stopThreads == false)
            {
                // block thread 2  while thread 1 is executing
                _blockThread2.WaitOne();

                // Set was called to free the block on thread 2, continue executing the code
                consoleEmulator.Add("Display Thread 2");

                _threadOutput = "Hello Thread 2";
                Thread.Sleep(1000);  // simulate a  lot of processing  

                // tell the user we are in thread #2  
                consoleEmulator.Add($"Thread 2 Output -- > {_threadOutput}");

                // finished executing the code in thread 2, so unblock thread 1  
                _blockThread1.Set();
            }
        }
    }
}
