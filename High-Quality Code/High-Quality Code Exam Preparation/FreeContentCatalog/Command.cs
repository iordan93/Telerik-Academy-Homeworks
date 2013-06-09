namespace FreeContentCatalog
{
    using System;
    using System.Linq;
    using System.Text;

    public class Command : ICommand
    {
        private readonly char[] paramsSeparators = { ';' };
        private readonly char commandEnd = ':';
        private int commandNameEndIndex;

        public Command(string input)
        {
            this.OriginalForm = input.Trim();
            this.Parse();
        }

        public CommandType Type { get; set; }

        public string OriginalForm { get; set; }

        public string Name { get; set; }

        public string[] Parameters { get; set; }

        public CommandType ParseCommandType(string commandName)
        {
            CommandType type;

            if (commandName.Contains(':') || commandName.Contains(';'))
            {
                throw new FormatException("The command name should not contain \";\" or \":\".");
            }

            switch (commandName.Trim())
            {
                case "Add book":
                    {
                        type = CommandType.AddBook;
                    }

                    break;

                case "Add movie":
                    {
                        type = CommandType.AddMovie;
                    }

                    break;

                case "Add song":
                    {
                        type = CommandType.AddSong;
                    }

                    break;

                case "Add application":
                    {
                        type = CommandType.AddApplication;
                    }

                    break;

                case "Update":
                    {
                        type = CommandType.Update;
                    }

                    break;

                case "Find":
                    {
                        type = CommandType.Find;
                    }

                    break;

                default:
                    {
                        throw new InvalidOperationException(string.Format("The command name {0} is invalid.", commandName));
                    }
            }

            return type;
        }

        public string ParseName()
        {
            string name = this.OriginalForm.Substring(0, this.commandNameEndIndex + 1);
            return name;
        }

        public string[] ParseParameters()
        {
            int paramsLength = this.OriginalForm.Length - (this.commandNameEndIndex + 3);

            string paramsOriginalForm = this.OriginalForm.Substring(this.commandNameEndIndex + 3, paramsLength);

            string[] parameters = paramsOriginalForm.Split(this.paramsSeparators, StringSplitOptions.RemoveEmptyEntries);

            return parameters;
        }

        public int GetCommandNameEndIndex()
        {
            int endIndex = this.OriginalForm.IndexOf(this.commandEnd) - 1;
            return endIndex;
        }

        public override string ToString()
        {
            StringBuilder command = new StringBuilder();
            command.Append(this.Name);
            for (int i = 0; i < this.Parameters.Length; i++)
            {
                command.Append(this.Parameters[i] + " ");
            }

            return command.ToString();
        }

        private void Parse()
        {
            this.commandNameEndIndex = this.GetCommandNameEndIndex();

            this.Name = this.ParseName();
            this.Parameters = this.ParseParameters();
            this.TrimParams();

            this.Type = this.ParseCommandType(this.Name);
        }

        private void TrimParams()
        {
            for (int i = 0; i < this.Parameters.Length; i++)
            {
                this.Parameters[i] = this.Parameters[i].Trim();
            }
        }
    }
}
