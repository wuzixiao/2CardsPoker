using CardsPoker.Entities;
using CardsPoker.Services;
using NUnit.Framework;
using System;
namespace CardsPokerTest
{
    [TestFixture()]
    public class PokerServiceTest
    {
        [Test()]
        public void Get_Refresh_Deck_Success()
        {
            //Arrage
            var service = new PokerService();

            //Act
            var deck = service.GetRefreshDeck(1);
            var deck2 = service.GetRefreshDeck(1);

            //Assert : have a small chance of failing
            Assert.IsTrue(deck.Cards[0].Suit != deck2.Cards[0].Suit || deck.Cards[0].Number != deck2.Cards[0].Number);
        }

        [Test()]
        public void Dispatch_Card_Success()
        {
            //Arrange
            var service = new PokerService();
            var deck = service.GetRefreshDeck(1);
            var playerNum = 4;

            //Act
            var cards = service.DispatchCards(deck, playerNum);

            //Assert
            Assert.IsTrue(cards.Length == playerNum);
            Assert.IsTrue(cards[0].Length == 2);
            Assert.IsTrue(cards[0][0].Number != cards[0][1].Number || cards[0][0].Suit != cards[0][1].Suit);
        }

        [Test()]
        public void CalculateResultTest()
        {
            //Arrange
            var service = new PokerService();
            var playerNum = 6;

            var cardsLst = new Card[playerNum][];
            cardsLst[0] = new Card[2] { new Card(Card.SUIT.CLUBS, 3), new Card(Card.SUIT.CLUBS, 2) }; //straight flush
            cardsLst[1] = new Card[2] { new Card(Card.SUIT.CLUBS, 4), new Card(Card.SUIT.CLUBS, 2) }; // flush
            cardsLst[2] = new Card[2] { new Card(Card.SUIT.DIAMONDS, 4), new Card(Card.SUIT.CLUBS, 3) }; // straight
            cardsLst[3] = new Card[2] { new Card(Card.SUIT.DIAMONDS, 3), new Card(Card.SUIT.CLUBS, 3) }; // pair
            cardsLst[4] = new Card[2] { new Card(Card.SUIT.DIAMONDS, 3), new Card(Card.SUIT.CLUBS, 9) }; // high card
            cardsLst[5] = new Card[2] { new Card(Card.SUIT.DIAMONDS, 5), new Card(Card.SUIT.CLUBS, 7) }; // high card

            //Act 
            var ret = service.CalculateResult(cardsLst, playerNum);

            //Assert
            Assert.AreEqual(new int[6] { 5,4,3,2,1,0 }, ret);

        }
    }
}
