namespace _1.IronMqChat
{
    using System;
    using System.Diagnostics;
    using System.Threading;
    using IronMQ;
    using IronMQ.Data;

    public class IronMqChat
    {
        public static void Main()
        {
            // To test the chat client, open two instances of the program (from bin/Debug).
            // If you open only one instance, it will both send and receive its own messages
            Console.Write("Enter your username: ");
            string username = Console.ReadLine();

            Client client = new Client("521099a5824dad0009000001", "bBrd7Es2TrXW75bX57ZZLmvsix8");
            IQueue chatQueue = client.Queue("chat");
            Console.WriteLine("Listening for new messages from IronMQ server. To send a message, type it right away and press Enter.");
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    string message = Console.ReadLine();
                    chatQueue.Push(string.Format("[{0:dd.MM.yyyy}] {1}: {2}", DateTime.Now, username, message));
                }
                else
                {
                    Message message = chatQueue.Get();
                    if (message != null)
                    {
                        Console.WriteLine(message.Body);
                        chatQueue.DeleteMessage(message);
                    }
                }

                Thread.Sleep(100);
            }
        }
    }
}
