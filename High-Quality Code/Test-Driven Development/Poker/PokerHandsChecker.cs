namespace Poker
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PokerHandsChecker : IPokerHandsChecker
    {
        public const int CardsPerHand = 5;

        public bool IsValidHand(IHand hand)
        {
            return !this.HasDuplicateCards(hand) && this.HasRightNumberOfCards(hand);
        }

        public bool IsStraightFlush(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsFourOfAKind(IHand hand)
        {
            this.InvalidHandExceptionThrower(hand);

            // Cards from a single face and all suits
            Dictionary<CardFace, int> cardsCount = GetCardsCountByFace(hand);

            if (cardsCount.ContainsValue(4))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsFullHouse(IHand hand)
        {
            this.InvalidHandExceptionThrower(hand);

            // Three cards from one suit and two cards from another suit, e. g. 
            if (this.IsThreeOfAKind(hand) && this.IsOnePair(hand))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsFlush(IHand hand)
        {
            this.InvalidHandExceptionThrower(hand);

            // Four cards from the same suit
            CardSuit suit = hand.Cards[0].Suit;
            foreach (Card currentSuit in hand.Cards)
            {
                if (suit != currentSuit.Suit)
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsStraight(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            this.InvalidHandExceptionThrower(hand);

            // Three cards from the same suit
            Dictionary<CardFace, int> cardsCount = GetCardsCountByFace(hand);

            if (cardsCount.ContainsValue(3))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsTwoPair(IHand hand)
        {
            // Two pairs of suits
            this.InvalidHandExceptionThrower(hand);

            Dictionary<CardFace, int> cards = GetCardsCountByFace(hand);

            var sortedCards = cards.Where(x => x.Value == 2).Select(x => x);

            if (sortedCards.Count() == 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsOnePair(IHand hand)
        {
            this.InvalidHandExceptionThrower(hand);

            // Exactly two cards of the same face
            Dictionary<CardFace, int> currentCards = GetCardsCountByFace(hand);

            var sortedCards = currentCards.Where(x => x.Value == 2).Select(x => x);

            if (sortedCards.Count() == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsHighCard(IHand hand)
        {
            throw new NotImplementedException();
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            throw new NotImplementedException();
        }

        private static Dictionary<CardFace, int> GetCardsCountByFace(IHand hand)
        {
            Dictionary<CardFace, int> cardsCount = new Dictionary<CardFace, int>();

            foreach (Card card in hand.Cards)
            {
                if (cardsCount.ContainsKey(card.Face))
                {
                    cardsCount[card.Face]++;
                }
                else
                {
                    cardsCount.Add(card.Face, 1);
                }
            }

            return cardsCount;
        }

        private bool HasDuplicateCards(IHand hand)
        {
            for (int i = 0; i < hand.Cards.Count; i++)
            {
                for (int j = i + 1; j < hand.Cards.Count; j++)
                {
                    if (hand.Cards[i].Equals(hand.Cards[j]))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private bool HasRightNumberOfCards(IHand hand)
        {
            return hand.Cards.Count == CardsPerHand;
        }

        private void InvalidHandExceptionThrower(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                throw new ArgumentException("The hand is not valid.");
            }
        }
    }
}
