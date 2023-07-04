using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    internal class Deck
    {
        List<Card> _cardDeck;

        public Deck(List<Card> cardDeck) 
        {
            _cardDeck = cardDeck;
        }

        public void AddCard()
        {
            List<string> cardName = new List<string> { "Ace", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Knight", "Qeen", "King" };
            List<int> cardPoint = new List<int> { 0, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10 };
            List<string> cardType = new List<string> { "Spades", "Clover", "Diamond", "Heart" };

            for (int i = 0; i < cardType.Count; i++) 
            {
                for (int j = 0; j < cardName.Count; j++)
                {
                    _cardDeck.Add(new Card(cardName[j], cardPoint[j], cardType[i]));
                }
            }


        }

        public void PrintCardDeck()
        {
            for (int i = 0; i < 52; i++)
            {
                Console.WriteLine(_cardDeck[i]._cardName + "|" + _cardDeck[i]._cardPoint + "|" +_cardDeck[i]._cardType);
            }
        }

        public void ShuffleCardDeck()
        {
            Random rd = new Random();
            for (int i = 0; i < 10000; i++)
            {
                int randomNum = rd.Next(0, _cardDeck.Count);
                Card tempCard = _cardDeck[0];

                _cardDeck[0] = _cardDeck[randomNum];
                _cardDeck[randomNum] = tempCard;
            }
        }
        public Card GetFirstCard()
        {
            Card firstCard = _cardDeck[0];
            _cardDeck.RemoveAt(0);

            return firstCard;
        }
    }
}
