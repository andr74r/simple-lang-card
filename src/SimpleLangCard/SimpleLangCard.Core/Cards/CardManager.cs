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

        public Card Add(string original, string translation)
        {
            var id = _cardRepository.SaveCard(new CardEntity
            {
                Original = original,
                Translation = translation
            });

            return new Card(id, original, translation);
        }

        public void DeleteCard(Card card)
        {
            _cardRepository.DeleteCard(card.Id);
        }
    }
}
