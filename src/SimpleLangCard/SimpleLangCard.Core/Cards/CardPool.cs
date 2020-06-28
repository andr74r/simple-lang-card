using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SimpleLangCard.Core.Cards
{
    public class CardPool
    {
        private IEnumerable<Card> _cards;
        private IEnumerator<Card> _cardEnumerator;

        public CardPool(IEnumerable<Card> cards)
        {
            _cards = cards;
            _cardEnumerator = _cards.GetEnumerator();
        }

        public void Shuffle()
        {
            var random = new Random();
            _cards = _cards.OrderBy(x => random.Next());
            _cardEnumerator = _cards.GetEnumerator();
        }

        public Card NextCard()
        {
            if (!HasCards())
            {
                return null;
            }

            if (!_cardEnumerator.MoveNext())
            {
                // do not use Reset. Can be cause of Not Supported Exception
                _cardEnumerator = _cards.GetEnumerator();

                return NextCard();
            }

            return _cardEnumerator.Current;
        }

        public bool HasCards()
        {
            return _cards.Any();
        }

        public Card Current
        {
            get
            {
                return _cardEnumerator.Current;
            }
        }
    }
}
