namespace SimpleLangCard.Core.Cards
{
    public class Card
    {
        public int Id { get; private set; }

        public string Original { get; private set; }

        public string Translation { get; private set; }

        public Card(int id, string original, string translation)
        {
            Id = id;
            Original = original;
            Translation = translation;
        }
    }
}
