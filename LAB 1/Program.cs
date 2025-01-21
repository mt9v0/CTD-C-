// Вариант 7 - решатель уравнений

namespace Lab1
{
    internal class Program
    {
        private const string CommandsList = "Use one of the commands:\n\"help\" to get this message\n\"solve\" to solve an equation\n\"find\" to get an existing solution from memory\n\"save\" to save data\n\"clear\" to clear saved data\n\"quit\" to exit";
        static void Main(string[] args)
        {
            string? UserCommand;
            string? saverWay = "";

            while (saverWay == "")
            {
                Console.WriteLine("Which way do you want to save and load data? 1 - JSON, 2 - XML, 3 - CSV");
                saverWay = Console.ReadLine();
                if (saverWay != "1" && saverWay != "2" && saverWay != "3")
                {
                    Console.WriteLine("Incorrect input");
                    saverWay = "";
                    break;

                }
            }
            CommandsHandler Commander = new CommandsHandler(saverWay);

            Console.WriteLine(CommandsList);

            while (true)
            {
                Console.WriteLine("-------\nInput the command:");
                UserCommand = Console.ReadLine();
                switch (UserCommand)
                {
                    case "solve":
                        Commander.Solve();
                        break;
                    case "find":
                        Commander.Find();
                        break;
                    case "clear":
                        Commander.Clear();
                        break;
                    case "quit":
                        Commander.Quit();
                        break;
                    case "help":
                        Console.WriteLine(CommandsList);
                        break;
                    case "save":
                        Commander.Save();
                        break;
                    default:
                        Console.WriteLine("Unknown command. Type \"help\" to see the list of available commands.");
                        break;
                }
            }
        }

    }
}