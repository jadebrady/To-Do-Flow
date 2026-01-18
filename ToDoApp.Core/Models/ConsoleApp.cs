public class ConsoleApp
{
    public void Run()
    {
        // Implementation of the console app's run logic
        Menu.DisplayHeader();
        bool keepRunning = true;
        while (keepRunning)
        {
            keepRunning = Menu.DisplayMainMenu();
        }
    }
}