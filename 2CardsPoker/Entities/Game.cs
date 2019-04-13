using System;
using System.Collections.Generic;
using CardsPoker.Services;

namespace CardsPoker.Entities
{
    public class Game
    {
        private readonly int _roundNum;
        private readonly int _playerNum;
        private readonly IPokerService _pokerService;

        public Game(int round, int player, IPokerService pokerService)
        {
            _roundNum = round;
            _playerNum = player;
            _pokerService = pokerService;
        }

        public void Start()
        {
            var leftRound = _roundNum;
            var scoreBoard = new int[_playerNum];
            while (leftRound > 0)
            {
                var deck = _pokerService.GetRefreshDeck(MainClass.ShuffleTimes);

                //list of cards = service.Dispatch(deck, _cardNumber, playerNum)
                var cardsLst = _pokerService.DispatchCards(deck, _playerNum);

                //Calculate score for each player
                var result = _pokerService.CalculateResult(cardsLst, _playerNum);

                //Accumulate result
                for(var i = 0; i < _playerNum; i++)
                {
                    scoreBoard[i] += result[i];
                }

                leftRound--;
            }


            for(var i = 0; i < _playerNum; i++)
            {
                Console.WriteLine("Player{0} : {1}", i+1, scoreBoard[i]);
            }
        }
    }
}
