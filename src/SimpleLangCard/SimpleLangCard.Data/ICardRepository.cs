using System.Collections.Generic;

namespace SimpleLangCard.Data
{
    public interface ICardRepository
    {
        IEnumerable<CardEntity> GetCards();

        int SaveCard(CardEntity cardEntity);
    }
}
