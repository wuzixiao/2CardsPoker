using System;
using System.Collections.Generic;

namespace CardsPoker.Entities
{
    public class Deck
    {
        public Deck()
        {
            Cards = new List<Card>();
            for(var i = 2; i < 15; i++)
            {
                Cards.Add(new Card(Card.SUIT.CLUBS, i));
                Cards.Add(new Card(Card.SUIT.DIAMONDS, i));
                Cards.Add(new Card(Card.SUIT.HEARTS, i));
                Cards.Add(new Card(Card.SUIT.SPADES, i));
            }
        }

        public List<Card> Cards { get; set; }
    }
}
