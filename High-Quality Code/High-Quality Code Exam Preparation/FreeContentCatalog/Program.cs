namespace FreeContentCatalog
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Program
    {
        public static void Main()
        {
            StringBuilder output = new StringBuilder();
            Catalog catalog = new Catalog();
            ICommandExecutor commandExecutor = new CommandExecutor();

            IList<ICommand> commands = GetAllCommands();
            foreach (ICommand item in commands)
            {
                commandExecutor.ExecuteCommand(catalog, item, output);
            }
            
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write(output);
        }

        private static List<ICommand> GetAllCommands()
        {
            List<ICommand> commands = new List<ICommand>();
            bool end = false;
            do
            {
                string line = Console.ReadLine();
                end = line.Trim() == "End";
                if (!end)
                {
                    commands.Add(new Command(line));
                }
            }
            while (!end);

            return commands;
        }
    }
}
