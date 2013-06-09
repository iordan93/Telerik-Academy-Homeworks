using System;
using System.Collections.Generic;
using System.Linq;

public class DocumentSystem
{
    private static List<Document> documents = new List<Document>();

    static void Main()
    {
        IList<string> allCommands = ReadAllCommands();
        ExecuteCommands(allCommands);
    }

    private static IList<string> ReadAllCommands()
    {
        List<string> commands = new List<string>();
        while (true)
        {
            string commandLine = Console.ReadLine();
            if (commandLine == "")
            {
                // End of commands
                break;
            }
            commands.Add(commandLine);
        }
        return commands;
    }

    private static void ExecuteCommands(IList<string> commands)
    {
        foreach (var commandLine in commands)
        {
            int paramsStartIndex = commandLine.IndexOf("[");
            string cmd = commandLine.Substring(0, paramsStartIndex);
            int paramsEndIndex = commandLine.IndexOf("]");
            string parameters = commandLine.Substring(
                paramsStartIndex + 1, paramsEndIndex - paramsStartIndex - 1);
            ExecuteCommand(cmd, parameters);
        }
    }

    private static void ExecuteCommand(string cmd, string parameters)
    {
        string[] cmdAttributes = parameters.Split(
            new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
        if (cmd == "AddTextDocument")
        {
            AddTextDocument(cmdAttributes);
        }
        else if (cmd == "AddPDFDocument")
        {
            AddPdfDocument(cmdAttributes);
        }
        else if (cmd == "AddWordDocument")
        {
            AddWordDocument(cmdAttributes);
        }
        else if (cmd == "AddExcelDocument")
        {
            AddExcelDocument(cmdAttributes);
        }
        else if (cmd == "AddAudioDocument")
        {
            AddAudioDocument(cmdAttributes);
        }
        else if (cmd == "AddVideoDocument")
        {
            AddVideoDocument(cmdAttributes);
        }
        else if (cmd == "ListDocuments")
        {
            ListDocuments();
        }
        else if (cmd == "EncryptDocument")
        {
            EncryptDocument(parameters);
        }
        else if (cmd == "DecryptDocument")
        {
            DecryptDocument(parameters);
        }
        else if (cmd == "EncryptAllDocuments")
        {
            EncryptAllDocuments();
        }
        else if (cmd == "ChangeContent")
        {
            ChangeContent(cmdAttributes[0], cmdAttributes[1]);
        }
        else
        {
            throw new InvalidOperationException("Invalid command: " + cmd);
        }
    }

    // Helper method to add a custom document (and avoid repetition of code)
    private static void AddDocument(Document document, string[] attributes)
    {
        foreach (var attribute in attributes)
        {
            string[] split = attribute.Split('=');
            document.LoadProperty(split[0], split[1]);
        }
        if (document.Name == null)
        {
            Console.WriteLine("Document has no name");
        }
        else
        {
            Console.WriteLine("Document added: {0}", document.Name);
            documents.Add(document);
        }
    }

    private static void AddTextDocument(string[] attributes)
    {
        AddDocument(new TextDocument(), attributes);
    }

    private static void AddPdfDocument(string[] attributes)
    {
        AddDocument(new PDFDocument(), attributes);
    }

    private static void AddWordDocument(string[] attributes)
    {
        AddDocument(new WordDocument(), attributes);
    }

    private static void AddExcelDocument(string[] attributes)
    {
        AddDocument(new ExcelDocument(), attributes);
    }

    private static void AddAudioDocument(string[] attributes)
    {
        AddDocument(new AudioDocument(), attributes);
    }

    private static void AddVideoDocument(string[] attributes)
    {
        AddDocument(new VideoDocument(), attributes);
    }

    private static void ListDocuments()
    {
        if (documents.Count == 0)
        {
            Console.WriteLine("No documents found");
        }
        else
        {
            foreach (Document document in documents)
            {
                Console.WriteLine(document);
            }
        }
    }

    private static void EncryptDocument(string name)
    {
        Document[] nameMatches = documents.Where(document => document.Name == name).ToArray();
        if (nameMatches.Length == 0)
        {
            Console.WriteLine("Document not found: {0}", name);
            return;
        }

        foreach (Document document in nameMatches)
        {
            if (document is IEncryptable)
            {
                (document as IEncryptable).Encrypt();
                Console.WriteLine("Document encrypted: {0}", name);
            }
            else
            {
                Console.WriteLine("Document does not support encryption: {0}", name);
            }
        }
    }

    private static void DecryptDocument(string name)
    {
        Document[] nameMatches = documents.Where(document => document.Name == name).ToArray();
        if (nameMatches.Length == 0)
        {
            Console.WriteLine("Document not found: {0}", name);
            return;
        }

        foreach (Document document in nameMatches)
        {
            if (document is IEncryptable)
            {
                (document as IEncryptable).Decrypt();
                Console.WriteLine("Document decrypted: {0}", name);
            }
            else
            {
                Console.WriteLine("Document does not support decryption: {0}", name);
            }
        }
    }

    private static void EncryptAllDocuments()
    {
        var iEncryptables = documents.Where(document => document is IEncryptable).ToArray();
        if (iEncryptables.Length == 0)
        {
            Console.WriteLine("No encryptable documents found");
            return;
        }

        foreach (IEncryptable document in iEncryptables)
        {
            document.Encrypt();
        }
        Console.WriteLine("All documents encrypted");
    }

    private static void ChangeContent(string name, string content)
    {
        Document[] nameMatches = documents.Where(document => document.Name == name).ToArray();
        if (nameMatches.Length == 0)
        {
            Console.WriteLine("Document not found: {0}", name);
            return;
        }

        foreach (Document document in nameMatches)
        {
            if (document is IEditable)
            {
                (document as IEditable).ChangeContent(content);
                Console.WriteLine("Document content changed: {0}", name);
            }
            else
            {
                Console.WriteLine("Document is not editable: {0}", name);
            }
        }
    }
}