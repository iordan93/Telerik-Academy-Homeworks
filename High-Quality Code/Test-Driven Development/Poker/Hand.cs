namespace Poker
{
    using System;
    using System.Collections.Generic;

    public class Hand : IHand
    {
        private IList<ICard> cards;

        public Hand(IList<ICard> cards)
        {
            this.Cards = cards;
        }

        public Hand(params ICard[] cards)
        {
            this.Cards = cards;
        }

        public IList<ICard> Cards
        {
            get
            {
                return this.cards;
            }

            private set
            {
                this.cards = value;
            }
        }

        public override string ToString()
        {
            return string.Join(string.Empty, this.Cards);
        }
    }
}
