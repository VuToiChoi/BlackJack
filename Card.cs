using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    internal class Card
    {
        public string _cardName;
        public int _cardPoint;
        public string _cardType;

        public Card (string cardName, int cardPoint, string cardType)
        {
            _cardName = cardName;
            _cardPoint = cardPoint;
            _cardType = cardType;
        }
    }
}
