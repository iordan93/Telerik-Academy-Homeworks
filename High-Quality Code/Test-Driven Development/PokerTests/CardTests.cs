namespace PokerTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Poker;

    [TestClass]
    public class CardTests
    {
        [TestMethod]
        public void CardConstructorTest()
        {
            ICard card = new Card(CardFace.Nine, CardSuit.Diamonds);
            Assert.AreEqual(card.Face, CardFace.Nine);
            Assert.AreEqual(card.Suit, CardSuit.Diamonds);
        }

        [TestMethod]
        public void AllCardsConstructorsTest()
        {
            const int CardSuits = 4;
            const int CardFaces = 13;
            for (int suit = 0; suit < CardSuits; suit++)
            {
                for (int face = 0; face < CardFaces; face++)
                {
                    ICard card = new Card((CardFace)face, (CardSuit)suit);
                    Assert.AreEqual((CardFace)face, card.Face);
                    Assert.AreEqual((CardSuit)suit, card.Suit);
                }
            }
        }

        [TestMethod]
        public void AceOfSpadesToStringTest()
        {
            ICard card = new Card(CardFace.Ace, CardSuit.Spades);
            string expected = "A♠";

            Assert.AreEqual(expected, card.ToString());
        }

        [TestMethod]
        public void TenOfClubsToStringTest()
        {
            ICard card = new Card(CardFace.Ten, CardSuit.Clubs);
            string expected = "10♣";

            Assert.AreEqual(expected, card.ToString());
        }

        [TestMethod]
        public void QueenOfHeartsToStringTest()
        {
            ICard card = new Card(CardFace.Queen, CardSuit.Hearts);
            string expected = "Q♥";

            Assert.AreEqual(expected, card.ToString());
        }

        [TestMethod]
        public void JackOfHeartsToStringTest()
        {
            ICard card = new Card(CardFace.Jack, CardSuit.Hearts);
            string expected = "J♥";

            Assert.AreEqual(expected, card.ToString());
        }

        [TestMethod]
        public void TwoOfDiamondsToStringTest()
        {
            ICard card = new Card(CardFace.Two, CardSuit.Diamonds);
            string expected = "2♦";

            Assert.AreEqual(expected, card.ToString());
        }

        [TestMethod]
        public void SevenOfHeartsToStringTest()
        {
            ICard card = new Card(CardFace.Seven, CardSuit.Hearts);
            string expected = "7♥";

            Assert.AreEqual(expected, card.ToString());
        }

        [TestMethod]
        public void EqualsSameCardTest()
        {
            ICard firstCard = new Card(CardFace.Seven, CardSuit.Hearts);
            ICard secondCard = new Card(CardFace.Seven, CardSuit.Hearts);

            Assert.IsTrue(firstCard.Equals(secondCard));
        }

        [TestMethod]
        public void DoesNotEqualDifferentSuitTest()
        {
            ICard firstCard = new Card(CardFace.Seven, CardSuit.Hearts);
            ICard secondCard = new Card(CardFace.Eight, CardSuit.Diamonds);

            Assert.IsFalse(firstCard.Equals(secondCard));
        }

        [TestMethod]
        public void DoesNotEqualDifferentFaceTest()
        {
            ICard firstCard = new Card(CardFace.Seven, CardSuit.Hearts);
            ICard secondCard = new Card(CardFace.Eight, CardSuit.Hearts);

            Assert.IsFalse(firstCard.Equals(secondCard));
        }

        [TestMethod]
        public void DoesNotEqualDifferentCardTest()
        {
            ICard firstCard = new Card(CardFace.Seven, CardSuit.Hearts);
            ICard secondCard = new Card(CardFace.Eight, CardSuit.Spades);

            Assert.IsFalse(firstCard.Equals(secondCard));
        }

        [TestMethod]
        public void DoesNotEqualDifferentObjectTest()
        {
            ICard card = new Card(CardFace.Seven, CardSuit.Hearts);
            IHand hand = new Hand(card, card, card, card, card);

            Assert.IsFalse(card.Equals(hand));
        }
    }
}
