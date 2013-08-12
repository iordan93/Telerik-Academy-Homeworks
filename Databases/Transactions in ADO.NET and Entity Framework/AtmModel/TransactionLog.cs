namespace AtmModel
{
    using System;

    public class TransactionLog
    {
        public int Id { get; set; }

        public int CardAccountId;

        public virtual CardAccount Account { get; set; }

        public decimal OldMoney { get; set; }

        public decimal NewMoney { get; set; }
    }
}
