namespace ToDoApp.Core.Models
{
    public class ConsoleApp
    {
        public void Run()
        {
            Menu.DisplayHeader();
            bool keepRunning = true;
            while (keepRunning)
            {
                keepRunning = Menu.DisplayMainMenu();
            }
        }
    }
}