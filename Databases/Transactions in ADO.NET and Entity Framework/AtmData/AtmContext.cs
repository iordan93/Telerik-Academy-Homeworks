namespace AtmData
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using AtmModel;

    public class AtmContext : DbContext
    {
        public AtmContext()
            : base("Atm")
        {
        }

        public DbSet<CardAccount> CardAccounts { get; set; }

        public DbSet<TransactionLog> TransactionLogs { get; set; }
    }
}