namespace PokerTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Poker;

    [TestClass]
    public class HandTests
    {
        [TestMethod]
        public void HandConstructorTest()
        {
            ICard firstCard = new Card(CardFace.King, CardSuit.Diamonds);
            ICard secondCard = new Card(CardFace.Five, CardSuit.Hearts);
            ICard thirdCard = new Card(CardFace.Jack, CardSuit.Clubs);
            ICard fourthCard = new Card(CardFace.Ten, CardSuit.Spades);
            ICard fifthCard = new Card(CardFace.Three, CardSuit.Hearts);

            IHand hand = new Hand(firstCard, secondCard, thirdCard, fourthCard, fifthCard);

            Assert.IsNotNull(hand);
            Assert.IsTrue(hand.Cards.Contains(firstCard));
            Assert.IsTrue(hand.Cards.Contains(secondCard));
            Assert.IsTrue(hand.Cards.Contains(thirdCard));
            Assert.IsTrue(hand.Cards.Contains(fourthCard));
            Assert.IsTrue(hand.Cards.Contains(fifthCard));
        }

        [TestMethod]
        public void HandConstructorListTest()
        {
            ICard firstCard = new Card(CardFace.King, CardSuit.Diamonds);
            ICard secondCard = new Card(CardFace.Five, CardSuit.Hearts);
            ICard thirdCard = new Card(CardFace.Jack, CardSuit.Clubs);
            ICard fourthCard = new Card(CardFace.Ten, CardSuit.Spades);
            ICard fifthCard = new Card(CardFace.Three, CardSuit.Hearts);
            IList<ICard> cards = new List<ICard>();
            cards.Add(firstCard);
            cards.Add(secondCard);
            cards.Add(thirdCard);
            cards.Add(fourthCard);
            cards.Add(fifthCard);

            IHand hand = new Hand(cards);

            Assert.IsNotNull(hand);
            Assert.IsNotNull(hand.Cards);
            Assert.AreEqual(5, hand.Cards.Count);
            Assert.IsTrue(hand.Cards.Contains(firstCard));
            Assert.IsTrue(hand.Cards.Contains(secondCard));
            Assert.IsTrue(hand.Cards.Contains(thirdCard));
            Assert.IsTrue(hand.Cards.Contains(fourthCard));
            Assert.IsTrue(hand.Cards.Contains(fifthCard));
        }

        [TestMethod]
        public void HandConstructorSingleCardTest()
        {
            ICard firstCard = new Card(CardFace.King, CardSuit.Diamonds);

            IHand hand = new Hand(firstCard);

            Assert.IsNotNull(hand);
            Assert.IsTrue(hand.Cards.Contains(firstCard));
        }

        [TestMethod]
        public void HandConstructorSomeCardsAddedTest()
        {
            ICard firstCard = new Card(CardFace.King, CardSuit.Diamonds);
            ICard secondCard = new Card(CardFace.Five, CardSuit.Hearts);
            ICard thirdCard = new Card(CardFace.Jack, CardSuit.Clubs);
            ICard fourthCard = new Card(CardFace.Ten, CardSuit.Spades);
            ICard fifthCard = new Card(CardFace.Three, CardSuit.Hearts);

            IHand hand = new Hand(firstCard, secondCard);

            Assert.IsNotNull(hand);
            Assert.IsTrue(hand.Cards.Contains(firstCard));
            Assert.IsTrue(hand.Cards.Contains(secondCard));
            Assert.IsFalse(hand.Cards.Contains(thirdCard));
            Assert.IsFalse(hand.Cards.Contains(fourthCard));
            Assert.IsFalse(hand.Cards.Contains(fifthCard));
        }

        [TestMethod]
        public void HandConstructorRepeatedCardTest()
        {
            ICard firstCard = new Card(CardFace.King, CardSuit.Diamonds);

            IHand hand = new Hand(firstCard, firstCard, firstCard, firstCard, firstCard, firstCard, firstCard, firstCard, firstCard, firstCard);

            Assert.IsNotNull(hand);
            Assert.IsTrue(hand.Cards.Contains(firstCard));
            Assert.AreEqual(10, hand.Cards.Count);
        }

        [TestMethod]
        public void HandToStringTest()
        {
            ICard firstCard = new Card(CardFace.King, CardSuit.Diamonds);
            ICard secondCard = new Card(CardFace.Five, CardSuit.Hearts);
            ICard thirdCard = new Card(CardFace.Jack, CardSuit.Clubs);
            ICard fourthCard = new Card(CardFace.Ten, CardSuit.Spades);
            ICard fifthCard = new Card(CardFace.Three, CardSuit.Hearts);

            IHand hand = new Hand(firstCard, secondCard, thirdCard, fourthCard, fifthCard);
            string expected = "K♦5♥J♣10♠3♥";
            string actual = hand.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void HandToStringTest2()
        {
            ICard firstCard = new Card(CardFace.Five, CardSuit.Diamonds);
            ICard secondCard = new Card(CardFace.Seven, CardSuit.Hearts);
            ICard thirdCard = new Card(CardFace.Two, CardSuit.Clubs);
            ICard fourthCard = new Card(CardFace.Ace, CardSuit.Hearts);
            ICard fifthCard = new Card(CardFace.Three, CardSuit.Spades);

            IHand hand = new Hand(firstCard, secondCard, thirdCard, fourthCard, fifthCard);
            string expected = "5♦7♥2♣A♥3♠";
            string actual = hand.ToString();

            Assert.AreEqual(expected, actual);
        }
    }
}
