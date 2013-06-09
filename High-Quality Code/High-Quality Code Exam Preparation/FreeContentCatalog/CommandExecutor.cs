namespace FreeContentCatalog
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class CommandExecutor : ICommandExecutor
    {
        public void ExecuteCommand(ICatalog contentCatalog, ICommand command, StringBuilder output)
        {
            switch (command.Type)
            {
                case CommandType.AddBook:
                    {
                        AddItem(contentCatalog, "book", command, output);
                    }

                    break;

                case CommandType.AddMovie:
                    {
                        AddItem(contentCatalog, "movie", command, output);
                    }

                    break;

                case CommandType.AddSong:
                    {
                        AddItem(contentCatalog, "song", command, output);
                    }

                    break;

                case CommandType.AddApplication:
                    {
                        AddItem(contentCatalog, "application", command, output);
                    }

                    break;

                case CommandType.Update:
                    {
                       UpdateItems(command, contentCatalog, output);
                    }

                    break;

                case CommandType.Find:
                    {
                        FindItems(command, contentCatalog, output);
                    }

                    break;

                default:
                    {
                        throw new InvalidOperationException(string.Format("The command {0} is invalid.", command));
                    }
            }
        }

        private static void AddItem(ICatalog catalog, string type, ICommand command, StringBuilder output)
        {
            switch (type)
            {
                case "book":
                    catalog.Add(new Content(ContentType.Book, command.Parameters));
                    output.Append("Book");
                    break;
                case "movie":
                    catalog.Add(new Content(ContentType.Movie, command.Parameters));
                    output.Append("Movie");
                    break;
                case "song":
                    catalog.Add(new Content(ContentType.Song, command.Parameters));
                    output.Append("Song");
                    break;
                case "application":
                    catalog.Add(new Content(ContentType.Application, command.Parameters));
                    output.Append("Application");
                    break;
                default:
                    throw new InvalidOperationException(string.Format("The type {0} is invalid.", type));
            }

            output.AppendLine(" added");
        }

        private static void UpdateItems(ICommand command, ICatalog contentCatalog, StringBuilder output)
        {
            if (command.Parameters.Length != 2)
            {
                throw new FormatException("The number of parameters specified for this command is invalid.");
            }

            int itemsCount = contentCatalog.UpdateContent(command.Parameters[0], command.Parameters[1]);
            output.AppendLine(string.Format("{0} items updated", itemsCount));
        }

        private static void FindItems(ICommand command, ICatalog contentCatalog, StringBuilder output)
        {
            if (command.Parameters.Length != 2)
            {
                throw new Exception("The number of parameters is invalid.");
            }

            int itemsCount = int.Parse(command.Parameters[1]);

            IEnumerable<IContent> foundContent = contentCatalog.GetCatalogContent(command.Parameters[0], itemsCount);

            if (foundContent.Count() == 0)
            {
                output.AppendLine("No items found");
            }
            else
            {
                foreach (IContent content in foundContent)
                {
                    output.AppendLine(content.TextRepresentation);
                }
            }
        }
    }
}