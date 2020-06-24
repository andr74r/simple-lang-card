using SimpleLangCard.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleLangCard.Core.Cards
{
    public class CardManager
    {
        private readonly ICardRepository _cardRepository;

        public CardManager(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }
        public CardPool GetCardPool()
        {
            var cards = _cardRepository.GetCards();

            var cardPool = new CardPool(cards.Select(x => new Card(x.Id, x.Original, x.Translation)));

            return cardPool;
        }

        public Card SaveCard(Card card)
        {
            var id = _cardRepository.SaveCard(new CardEntity
            {
                Id = card.Id,
                Original = card.Original,
                Translation = card.Translation
            });

            return new Card(id, card.Original, card.Translation);
        }
    }
}
