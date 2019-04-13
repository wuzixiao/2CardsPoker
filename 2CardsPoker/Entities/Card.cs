using System;
namespace CardsPoker.Entities
{
    public class Card
    {
        public enum SUIT
        {
            DIAMONDS,
            HEARTS,
            CLUBS,
            SPADES
        }

        public Card(SUIT s, int n)
        {
            Suit = s;
            Number = n;
        }

        public override int GetHashCode()
        {
            return (int)Suit * 100 + Number;
        }

        public SUIT Suit { get; set; }
        public int Number { get; set; }
    }
}
