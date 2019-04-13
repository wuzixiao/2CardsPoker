using System;
using System.Linq;
using CardsPoker.Entities;

namespace CardsPoker.Services
{
    public class PokerService : IPokerService
    {
        public PokerService()
        {
        }


        public int[] CalculateResult(Card[][] cardsLst, int playerNum)
        {
            if(cardsLst.Length != playerNum)
            {
                throw new ArgumentException();
            }
            var scores = new int[playerNum];
            for(var i = 0; i < cardsLst.Length; i++)
            {
                scores[i] = CalculateOnePlayer(cardsLst[i]);
            }

            var ret = new int[playerNum];
            for(var i = 0; i < playerNum-1; i++)
            {
                for(var j = i+1; j < playerNum; j++)
                {
                    if(scores[i] > scores[j])
                    {
                        ret[i]++;
                    }
                    else
                    {
                        ret[j]++;
                    }
                }
            }

            return ret;
        }

        private int CalculateOnePlayer(Card[] cards)
        {
            if(cards.Length != MainClass.CardNumber)
            {
                throw new ArgumentException();
            }

            var sum = 0;
            for(var i = 0; i < cards.Length; i++)
            {
                sum += cards[i].GetHashCode();
            }
            if(cards[0].Suit == cards[1].Suit && Math.Abs(cards[0].Number-cards[1].Number) == 1)
            {
                sum *= 10000;
            }
            else if(cards[0].Suit == cards[1].Suit)
            {
                sum *= 1000;
            }
            else if(Math.Abs(cards[0].Number-cards[1].Number) == 1)
            {
                sum *= 100;
            }
            else if(cards[0].Number == cards[1].Number)
            {
                sum *= 10;
            }
            else
            {
                sum = Math.Max(cards[0].GetHashCode(), cards[1].GetHashCode());
            }

            return sum;
        }

        public Card[][] DispatchCards(Deck deck, int playerNumber)
        {
            var ret = new Card[playerNumber][];
            for (var i = 0; i < playerNumber; i++)
            {
                ret[i] = new Card[MainClass.CardNumber];
                for (var j = 0; j < MainClass.CardNumber; j++)
                {
                    if (!deck.Cards.Any())
                    {
                        throw new ArgumentException();
                    }

                    ret[i][j] = deck.Cards[0];
                    deck.Cards.RemoveAt(0);
                }
            }

            return ret;
        }

        public Deck GetRefreshDeck(int x)
        {
            var deck = new Deck();
            for(var i = 0; i < x; i++)
            {
                deck.Cards.Shuffle();
            }

            return deck;
        }
    }
}
