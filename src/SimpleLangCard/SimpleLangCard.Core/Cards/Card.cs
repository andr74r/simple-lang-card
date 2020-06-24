namespace SimpleLangCard.Core.Cards
{
    public class Card
    {
        public int Id { get; private set; }

        public string Original { get; private set; }

        public string Translation { get; private set; }

        public Card(int id, string original, string translation)
            : this(original, translation)
        {
            Id = id;
        }

        public Card(string original, string translation)
        {
            Original = original;
            Translation = translation;
        }
    }
}
