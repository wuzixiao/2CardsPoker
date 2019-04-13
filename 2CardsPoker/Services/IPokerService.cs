using System;
using System.Collections.Generic;
using CardsPoker.Entities;

namespace CardsPoker.Services
{
    public interface IPokerService
    {
        Deck GetRefreshDeck(int x);
        Card[][] DispatchCards(Deck deck, int playerNumber);
        int[] CalculateResult(Card[][] cardsLst, int playerNumber);
    }
}
