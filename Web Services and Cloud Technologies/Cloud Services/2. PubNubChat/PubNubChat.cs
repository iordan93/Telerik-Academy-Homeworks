namespace _2.PubNubChat
{
    using System;
    using System.Threading;

    public class PubNubChat
    {
        static void Main()
        {
            // To test the chat client, open two instances of the program (from bin/Debug).
            // If you open only one instance, it will both send and receive its own messages
            Console.Write("Enter your username: ");
            string username = Console.ReadLine();

            PubNubAPI pubNub = new PubNubAPI(
                "pub-c-3cadf3d9-b9c1-4c00-b12b-0abd7cc88b9e",
                "sub-c-9f0fc8b0-07f5-11e3-ab8d-02ee2ddab7fe",
                "sec-c-MDljMzNiNTgtNTI3MC00ZGRlLWI2MjctZTNkNThmNzZiZmNh",
                true);

            string channel = "chat";
            Console.WriteLine("Listening for new messages from PubNub server. To send a message, type it right away and press Enter.");
            while (true)
            {
                System.Threading.Tasks.Task t = new System.Threading.Tasks.Task(
                    () => pubNub.Subscribe(
                        channel,
                        delegate(object message)
                        {
                            // Simple check to avoid getting the user's own messages
                            // (because PubNub sends notifications to all subscribers)
                            if (message.ToString().IndexOf("] " + username) == -1)
                            {
                                Console.WriteLine(message);
                            }
                            return true;
                        }));
                t.Start();

                while (true)
                {
                    string message = Console.ReadLine();
                    pubNub.Publish(channel, string.Format("[{0:dd.MM.yyyy}] {1}: {2}", DateTime.Now, username, message));
                }
            }
        }
    }
}