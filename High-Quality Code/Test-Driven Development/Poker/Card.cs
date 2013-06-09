namespace Poker
{
    using System;

    public class Card : ICard
    {
        private CardFace face;
        private CardSuit suit;

        public Card(CardFace face, CardSuit suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        public CardFace Face
        {
            get
            {
                return this.face;
            }

            private set
            {
                this.face = value;
            }
        }

        public CardSuit Suit
        {
            get
            {
                return this.suit;
            }

            private set
            {
                this.suit = value;
            }
        }

        public override string ToString()
        {
            string face = this.GetFaceName(this.Face);
            string suit = this.GetSuitName(this.Suit);

            return face + suit;
        }

        public override bool Equals(object obj)
        {
            Card other = obj as Card;
            if (other != null)
            {
                return this.Face == other.Face && this.Suit == other.Suit;
            }

            return false;
        }

        private string GetFaceName(CardFace face)
        {
            string cardFace = string.Empty;

            switch (face)
            {
                case CardFace.Two:
                case CardFace.Three:
                case CardFace.Four:
                case CardFace.Five:
                case CardFace.Six:
                case CardFace.Seven:
                case CardFace.Eight:
                case CardFace.Nine:
                case CardFace.Ten:
                    cardFace = ((int)face).ToString();
                    break;
                case CardFace.Jack:
                    cardFace = "J";
                    break;
                case CardFace.Queen:
                    cardFace = "Q";
                    break;
                case CardFace.King:
                    cardFace = "K";
                    break;
                case CardFace.Ace:
                    cardFace = "A";
                    break;
                default:
                    throw new ArgumentException("The face of the input card is invalid.");
            }

            return cardFace;
        }

        private string GetSuitName(CardSuit suit)
        {
            string cardSuit = string.Empty;

            switch (suit)
            {
                case CardSuit.Clubs:
                    cardSuit = "♣";
                    break;
                case CardSuit.Diamonds:
                    cardSuit = "♦";
                    break;
                case CardSuit.Hearts:
                    cardSuit = "♥";
                    break;
                case CardSuit.Spades:
                    cardSuit = "♠";
                    break;
                default:
                    throw new ArgumentException("The suit of the input card is invalid.");
            }

            return cardSuit;
        }
    }
}
