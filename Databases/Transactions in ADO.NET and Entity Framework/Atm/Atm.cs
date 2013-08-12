namespace Atm
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Transactions;
    using AtmData;
    using AtmModel;

    public class Atm
    {
        public static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AtmContext, AtmData.Migrations.Configuration>());

            using (var atm = new AtmContext())
            {
                FillInSampleRecords(atm);

                // Normal case
                Console.WriteLine(WithdrawMoney(atm, "1234567890", "1234", 500));

                // Withdrawal of no money
                Console.WriteLine(WithdrawMoney(atm, "1234567890", "1234", 0));

                // Wrong PIN
                Console.WriteLine(WithdrawMoney(atm, "1234567890", "0001", 500));

                // Wrong card number
                Console.WriteLine(WithdrawMoney(atm, "4444444444", "1234", 500));

                // Wrong card number and PIN
                Console.WriteLine(WithdrawMoney(atm, "4444444444", "4444", 500));

                // Too much money
                Console.WriteLine(WithdrawMoney(atm, "1234567890", "1234", 5000));

                Console.WriteLine();
                Console.WriteLine("Transaction logs:");
                foreach (var log in atm.TransactionLogs.Include("Account"))
                {
                    Console.WriteLine("{0} | {1} | {2} | {3}", log.Id, log.Account.CardNumber, log.OldMoney, log.NewMoney);
                }
            }
        }

        public static string WithdrawMoney(AtmContext atm, string cardNumber, string cardPin, decimal money)
        {
            var options = new TransactionOptions();
            // Repeatable read - data can be added and read but not modified during a transaction
            options.IsolationLevel = IsolationLevel.RepeatableRead;
            using (var transactionScope = new TransactionScope(TransactionScopeOption.Required, options))
            {
                var card = atm.CardAccounts.Where(a => a.CardNumber == cardNumber && a.CardPin == cardPin).FirstOrDefault();
                if (card == null)
                {
                    return "The money withdrawal was unsuccessful. The card number or PIN is invalid.";
                }

                if (card.CardCash - money > 0)
                {
                    decimal oldMoney = card.CardCash;
                    card.CardCash -= money;
                    decimal newMoney = card.CardCash;

                    atm.SaveChanges();
                    transactionScope.Complete();

                    LogTransaction(atm, card, oldMoney, newMoney);

                    return string.Format(
                        "Successfully withdrew {0} dollars from card {1}. The amount remaining is {2}.",
                        money,
                        card.CardNumber.Substring(0, 4).PadRight(10, 'X'),
                        card.CardCash);
                }
                else
                {
                    return "The money withdrawal was unsuccessful. There are not enough money in the account.";
                }
            }
        }

        private static void FillInSampleRecords(AtmContext atm)
        {
            atm.CardAccounts.Add(new CardAccount() { CardNumber = "1234567890", CardPin = "1234", CardCash = 2000 });
            atm.CardAccounts.Add(new CardAccount() { CardNumber = "0452368874", CardPin = "4455", CardCash = 1000 });
            atm.CardAccounts.Add(new CardAccount() { CardNumber = "8965123476", CardPin = "0000", CardCash = 500.23M });

            atm.SaveChanges();
        }

        private static void LogTransaction(AtmContext atm, CardAccount account, decimal oldMoney, decimal newMoney)
        {
            var options = new TransactionOptions();
            // Snapshot - data can be read but before modifying the value is checked for updates
            options.IsolationLevel = IsolationLevel.RepeatableRead;

            using (var transactionScope = new TransactionScope(TransactionScopeOption.Required, options))
            {
                atm.TransactionLogs.Add(new TransactionLog() { Account = account, OldMoney = oldMoney, NewMoney = newMoney });

                atm.SaveChanges();
                transactionScope.Complete();
            }
        }
    }
}