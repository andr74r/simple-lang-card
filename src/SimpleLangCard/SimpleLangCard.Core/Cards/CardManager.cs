using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleLangCard.Core.Cards
{
    public class CardManager
    {
        public CardPool GetCardPool()
        {
            var cards = new List<Card>
            {
                new Card(1, "To Come Across", "Наткнуться"),
                new Card(2, "Наткнуться", "To Come Across")
            };

            var cardPool = new CardPool(cards);

            return cardPool;
        }
    }
}
