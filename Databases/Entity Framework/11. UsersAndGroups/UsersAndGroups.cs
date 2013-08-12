namespace _11.UsersAndGroups
{
    using System;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Transactions;
    using UsersModel;

    public class UsersAndGroups
    {
        public static void Main()
        {
            // To create the database, execute the script Users.sql in the program folder
            using (var users = new UsersEntities())
            {
                try
                {
                    Console.WriteLine(AddAdmin(users, new Users() { Username = "the.brave" }));
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static string AddAdmin(UsersEntities users, Users user)
        {
            using (var transaction = new TransactionScope())
            {
                users.Users.Add(user);

                // Create the group Admins if it does not exits
                var admins = users.Groups.Where(g => g.GroupName == "Admins").FirstOrDefault();
                if (admins == null)
                {
                    users.Groups.Add(new Groups() { GroupName = "Admins" });
                    users.SaveChanges();
                }

                user.Groups = users.Groups.Where(g => g.GroupName == "Admins").First();
                try
                {
                    users.SaveChanges();
                }
                // Adding a duplicate username violates the unique key constraint and should rollback the transaction
                catch (DbUpdateException)
                {
                    throw new InvalidOperationException(string.Format("The username {0} already exists in the database.", user.Username));
                }

                transaction.Complete();
            }

            return string.Format("{0} added as admin", user.Username);
        }
    }
}