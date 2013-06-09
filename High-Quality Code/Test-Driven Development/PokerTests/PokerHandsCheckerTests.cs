namespace PokerTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Poker;

    [TestClass]
    public class PokerHandsCheckerTests
    {
        [TestMethod]
        public void PokerHandsCheckerConstructorTest()
        {
            IPokerHandsChecker checker = new PokerHandsChecker();
            Assert.IsNotNull(checker);
        }

        [TestMethod]
        public void IsValidHandCorrectDataTest()
        {
            ICard firstCard = new Card(CardFace.Five, CardSuit.Diamonds);
            ICard secondCard = new Card(CardFace.Seven, CardSuit.Hearts);
            ICard thirdCard = new Card(CardFace.Two, CardSuit.Clubs);
            ICard fourthCard = new Card(CardFace.Ace, CardSuit.Hearts);
            ICard fifthCard = new Card(CardFace.Three, CardSuit.Spades);
            IHand hand = new Hand(firstCard, secondCard, thirdCard, fourthCard, fifthCard);

            IPokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsTrue(checker.IsValidHand(hand));
        }

        [TestMethod]
        public void IsValidHandCorrectDataTest2()
        {
            ICard firstCard = new Card(CardFace.Ace, CardSuit.Hearts);
            ICard secondCard = new Card(CardFace.Three, CardSuit.Diamonds);
            ICard thirdCard = new Card(CardFace.Five, CardSuit.Clubs);
            ICard fourthCard = new Card(CardFace.Jack, CardSuit.Spades);
            ICard fifthCard = new Card(CardFace.Queen, CardSuit.Clubs);
            IHand hand = new Hand(firstCard, secondCard, thirdCard, fourthCard, fifthCard);

            IPokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsTrue(checker.IsValidHand(hand));
        }

        [TestMethod]
        public void IsValidTooManyCardsTest()
        {
            ICard firstCard = new Card(CardFace.Ace, CardSuit.Hearts);
            ICard secondCard = new Card(CardFace.Three, CardSuit.Diamonds);
            ICard thirdCard = new Card(CardFace.Five, CardSuit.Clubs);
            ICard fourthCard = new Card(CardFace.Jack, CardSuit.Spades);
            ICard fifthCard = new Card(CardFace.Queen, CardSuit.Clubs);
            ICard sixthCard = new Card(CardFace.King, CardSuit.Diamonds);
            IHand hand = new Hand(firstCard, secondCard, thirdCard, fourthCard, fifthCard, sixthCard);
      
            IPokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsValidHand(hand));
        }

        [TestMethod]
        public void IsValidTooFewCardsTest()
        {
            ICard firstCard = new Card(CardFace.Ace, CardSuit.Hearts);
            ICard secondCard = new Card(CardFace.Three, CardSuit.Diamonds);
            ICard thirdCard = new Card(CardFace.Five, CardSuit.Clubs);
            ICard fourthCard = new Card(CardFace.Jack, CardSuit.Spades);
            IHand hand = new Hand(firstCard, secondCard, thirdCard, fourthCard);
     
            IPokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsValidHand(hand));
        }

        [TestMethod]
        public void IsValidSingleCardTest()
        {
            ICard firstCard = new Card(CardFace.Ace, CardSuit.Hearts);
            IHand hand = new Hand(firstCard);
       
            IPokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsValidHand(hand));
        }

        [TestMethod]
        public void IsFlushTrueTest()
        {
            ICard firstCard = new Card(CardFace.Ace, CardSuit.Hearts);
            ICard secondCard = new Card(CardFace.Three, CardSuit.Hearts);
            ICard thirdCard = new Card(CardFace.Five, CardSuit.Hearts);
            ICard fourthCard = new Card(CardFace.Jack, CardSuit.Hearts);
            ICard fifthCard = new Card(CardFace.Seven, CardSuit.Hearts);
            IHand hand = new Hand(firstCard, secondCard, thirdCard, fourthCard, fifthCard);
        
            IPokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsTrue(checker.IsFlush(hand));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IsFlushInvalidCardTest()
        {
            ICard firstCard = new Card(CardFace.Ace, CardSuit.Hearts);
            ICard secondCard = new Card(CardFace.Three, CardSuit.Hearts);
            ICard thirdCard = new Card(CardFace.Ace, CardSuit.Hearts);
            ICard fourthCard = new Card(CardFace.Jack, CardSuit.Hearts);
            ICard fifthCard = new Card(CardFace.Seven, CardSuit.Hearts);
            IHand hand = new Hand(firstCard, secondCard, thirdCard, fourthCard, fifthCard);

            IPokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsTrue(checker.IsFlush(hand));
        }

        [TestMethod]
        public void IsFlushFalseOneDifferentSuitTest()
        {
            ICard firstCard = new Card(CardFace.Ace, CardSuit.Hearts);
            ICard secondCard = new Card(CardFace.Three, CardSuit.Hearts);
            ICard thirdCard = new Card(CardFace.Five, CardSuit.Hearts);
            ICard fourthCard = new Card(CardFace.Jack, CardSuit.Diamonds);
            ICard fifthCard = new Card(CardFace.Seven, CardSuit.Hearts);
            IHand hand = new Hand(firstCard, secondCard, thirdCard, fourthCard, fifthCard);
       
            IPokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsFlush(hand));
        }

        [TestMethod]
        public void IsFlushFalseThreeDifferentSuitsTest()
        {
            ICard firstCard = new Card(CardFace.Ace, CardSuit.Clubs);
            ICard secondCard = new Card(CardFace.Three, CardSuit.Hearts);
            ICard thirdCard = new Card(CardFace.Five, CardSuit.Hearts);
            ICard fourthCard = new Card(CardFace.Jack, CardSuit.Diamonds);
            ICard fifthCard = new Card(CardFace.Seven, CardSuit.Spades);
            IHand hand = new Hand(firstCard, secondCard, thirdCard, fourthCard, fifthCard);
          
            IPokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsFlush(hand));
        }

        [TestMethod]
        public void IsFourOfAKindTrueTest()
        {
            ICard firstCard = new Card(CardFace.Ace, CardSuit.Hearts);
            ICard secondCard = new Card(CardFace.Ace, CardSuit.Diamonds);
            ICard thirdCard = new Card(CardFace.Ace, CardSuit.Spades);
            ICard fourthCard = new Card(CardFace.Ace, CardSuit.Clubs);
            ICard fifthCard = new Card(CardFace.Seven, CardSuit.Hearts);
            IHand hand = new Hand(firstCard, secondCard, thirdCard, fourthCard, fifthCard);

            IPokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsTrue(checker.IsFourOfAKind(hand));
        }
        
        [TestMethod]
        public void IsFourOfAKindFalseTwoCardsTest()
        {
            ICard firstCard = new Card(CardFace.Ace, CardSuit.Clubs);
            ICard secondCard = new Card(CardFace.Ace, CardSuit.Hearts);
            ICard thirdCard = new Card(CardFace.Five, CardSuit.Hearts);
            ICard fourthCard = new Card(CardFace.Jack, CardSuit.Diamonds);
            ICard fifthCard = new Card(CardFace.Seven, CardSuit.Spades);
            IHand hand = new Hand(firstCard, secondCard, thirdCard, fourthCard, fifthCard);

            IPokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsFourOfAKind(hand));
        }
        
        [TestMethod]
        public void IsFourOfAKindFalseThreeCardsTest()
        {
            ICard firstCard = new Card(CardFace.Ace, CardSuit.Hearts);
            ICard secondCard = new Card(CardFace.Ace, CardSuit.Diamonds);
            ICard thirdCard = new Card(CardFace.Eight, CardSuit.Spades);
            ICard fourthCard = new Card(CardFace.Ace, CardSuit.Clubs);
            ICard fifthCard = new Card(CardFace.Queen, CardSuit.Hearts); 
            IHand hand = new Hand(firstCard, secondCard, thirdCard, fourthCard, fifthCard);
            
            IPokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsFourOfAKind(hand));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IsFourOfAKindInvalidCardTest()
        {
            ICard firstCard = new Card(CardFace.Ace, CardSuit.Clubs);
            ICard secondCard = new Card(CardFace.Ace, CardSuit.Hearts);
            ICard thirdCard = new Card(CardFace.Five, CardSuit.Hearts);
            ICard fourthCard = new Card(CardFace.Ace, CardSuit.Clubs);
            ICard fifthCard = new Card(CardFace.Seven, CardSuit.Spades);
            IHand hand = new Hand(firstCard, secondCard, thirdCard, fourthCard, fifthCard);

            IPokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsFourOfAKind(hand));
        }

        [TestMethod]
        public void IsOnePairTrueTest()
        {
            ICard firstCard = new Card(CardFace.Queen, CardSuit.Hearts);
            ICard secondCard = new Card(CardFace.Queen, CardSuit.Clubs);
            ICard thirdCard = new Card(CardFace.Ace, CardSuit.Spades);
            ICard fourthCard = new Card(CardFace.Seven, CardSuit.Clubs);
            ICard fifthCard = new Card(CardFace.Eight, CardSuit.Hearts);
            IHand hand = new Hand(firstCard, secondCard, thirdCard, fourthCard, fifthCard);

            IPokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsTrue(checker.IsOnePair(hand));
        }

        [TestMethod]
        public void IsOnePairFalseNoPairsTest()
        {
            ICard firstCard = new Card(CardFace.Three, CardSuit.Hearts);
            ICard secondCard = new Card(CardFace.Four, CardSuit.Spades);
            ICard thirdCard = new Card(CardFace.Five, CardSuit.Hearts);
            ICard fourthCard = new Card(CardFace.Six, CardSuit.Diamonds);
            ICard fifthCard = new Card(CardFace.Seven, CardSuit.Spades);
            IHand hand = new Hand(firstCard, secondCard, thirdCard, fourthCard, fifthCard);

            IPokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsOnePair(hand));
        }

        [TestMethod]
        public void IsOnePairFalseTwoPairsTest()
        {
            ICard firstCard = new Card(CardFace.Four, CardSuit.Hearts);
            ICard secondCard = new Card(CardFace.Four, CardSuit.Spades);
            ICard thirdCard = new Card(CardFace.Five, CardSuit.Hearts);
            ICard fourthCard = new Card(CardFace.Five, CardSuit.Diamonds);
            ICard fifthCard = new Card(CardFace.Seven, CardSuit.Spades);
            IHand hand = new Hand(firstCard, secondCard, thirdCard, fourthCard, fifthCard);

            IPokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsOnePair(hand));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IsOnePairInvalidHandTest()
        {
            ICard firstCard = new Card(CardFace.Four, CardSuit.Hearts);
            ICard secondCard = new Card(CardFace.Five, CardSuit.Spades);
            ICard thirdCard = new Card(CardFace.Five, CardSuit.Hearts);
            ICard fourthCard = new Card(CardFace.Five, CardSuit.Diamonds);
            ICard fifthCard = new Card(CardFace.Seven, CardSuit.Spades);
            ICard sixthCard = new Card(CardFace.Seven, CardSuit.Spades);
            IHand hand = new Hand(firstCard, secondCard, thirdCard, fourthCard, fifthCard, sixthCard);

            IPokerHandsChecker checker = new PokerHandsChecker();

            checker.IsOnePair(hand);
        }

        [TestMethod]
        public void IsThreeOfAKindTrueTest()
        {
            ICard firstCard = new Card(CardFace.Three, CardSuit.Clubs);
            ICard secondCard = new Card(CardFace.Three, CardSuit.Spades);
            ICard thirdCard = new Card(CardFace.Three, CardSuit.Hearts);
            ICard fourthCard = new Card(CardFace.Six, CardSuit.Diamonds);
            ICard fifthCard = new Card(CardFace.Seven, CardSuit.Spades);
            IHand hand = new Hand(firstCard, secondCard, thirdCard, fourthCard, fifthCard);

            IPokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsTrue(checker.IsThreeOfAKind(hand));
        }

        [TestMethod]
        public void IsThreeOfAKindFalseTooFewMatchesTest()
        {
            ICard firstCard = new Card(CardFace.Three, CardSuit.Clubs);
            ICard secondCard = new Card(CardFace.Ace, CardSuit.Spades);
            ICard thirdCard = new Card(CardFace.Three, CardSuit.Hearts);
            ICard fourthCard = new Card(CardFace.Six, CardSuit.Diamonds);
            ICard fifthCard = new Card(CardFace.Seven, CardSuit.Spades);
            IHand hand = new Hand(firstCard, secondCard, thirdCard, fourthCard, fifthCard);

            IPokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsThreeOfAKind(hand));
        }

        [TestMethod]
        public void IsThreeOfAKindFalseTooManyMatchesTest()
        {
            ICard firstCard = new Card(CardFace.Three, CardSuit.Hearts);
            ICard secondCard = new Card(CardFace.Three, CardSuit.Clubs);
            ICard thirdCard = new Card(CardFace.Three, CardSuit.Diamonds);
            ICard fourthCard = new Card(CardFace.Three, CardSuit.Spades);
            ICard fifthCard = new Card(CardFace.Seven, CardSuit.Spades);
            IHand hand = new Hand(firstCard, secondCard, thirdCard, fourthCard, fifthCard);

            IPokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsThreeOfAKind(hand));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IsThreeOfAKindInvalidHandTest()
        {
            ICard firstCard = new Card(CardFace.Four, CardSuit.Hearts);
            ICard secondCard = new Card(CardFace.Five, CardSuit.Spades);
            ICard thirdCard = new Card(CardFace.Five, CardSuit.Hearts);
            ICard fourthCard = new Card(CardFace.Five, CardSuit.Diamonds);
            ICard fifthCard = new Card(CardFace.Seven, CardSuit.Spades);
            ICard sixthCard = new Card(CardFace.Seven, CardSuit.Spades);
            IHand hand = new Hand(firstCard, secondCard, thirdCard, fourthCard, fifthCard, sixthCard);

            IPokerHandsChecker checker = new PokerHandsChecker();

            checker.IsThreeOfAKind(hand);
        }

        [TestMethod]
        public void IsFullHouseTrueTest()
        {
            ICard firstCard = new Card(CardFace.Three, CardSuit.Hearts);
            ICard secondCard = new Card(CardFace.Three, CardSuit.Clubs);
            ICard thirdCard = new Card(CardFace.Three, CardSuit.Diamonds);
            ICard fourthCard = new Card(CardFace.Six, CardSuit.Hearts);
            ICard fifthCard = new Card(CardFace.Six, CardSuit.Spades);
            IHand hand = new Hand(firstCard, secondCard, thirdCard, fourthCard, fifthCard);

            IPokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsTrue(checker.IsFullHouse(hand));
        }

        [TestMethod]
        public void IsFullHouseFalseTooFewCardsTest()
        {
            ICard firstCard = new Card(CardFace.Three, CardSuit.Hearts);
            ICard secondCard = new Card(CardFace.Three, CardSuit.Clubs);
            ICard thirdCard = new Card(CardFace.Four, CardSuit.Diamonds);
            ICard fourthCard = new Card(CardFace.Six, CardSuit.Hearts);
            ICard fifthCard = new Card(CardFace.Six, CardSuit.Spades);
            IHand hand = new Hand(firstCard, secondCard, thirdCard, fourthCard, fifthCard);

            IPokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsFullHouse(hand));
        }

        [TestMethod]
        public void IsFullHouseFalseNoPairTest()
        {
            ICard firstCard = new Card(CardFace.Three, CardSuit.Hearts);
            ICard secondCard = new Card(CardFace.Three, CardSuit.Clubs);
            ICard thirdCard = new Card(CardFace.Three, CardSuit.Diamonds);
            ICard fourthCard = new Card(CardFace.Six, CardSuit.Hearts);
            ICard fifthCard = new Card(CardFace.Seven, CardSuit.Spades);
            IHand hand = new Hand(firstCard, secondCard, thirdCard, fourthCard, fifthCard);

            IPokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsFullHouse(hand));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IsFullHouseInvalidHandTest()
        {
            ICard firstCard = new Card(CardFace.Four, CardSuit.Hearts);
            ICard secondCard = new Card(CardFace.Five, CardSuit.Spades);
            ICard thirdCard = new Card(CardFace.Five, CardSuit.Hearts);
            ICard fourthCard = new Card(CardFace.Five, CardSuit.Hearts);
            ICard fifthCard = new Card(CardFace.Seven, CardSuit.Spades);
            IHand hand = new Hand(firstCard, secondCard, thirdCard, fourthCard, fifthCard);

            IPokerHandsChecker checker = new PokerHandsChecker();

            checker.IsFullHouse(hand);
        }
    }
}