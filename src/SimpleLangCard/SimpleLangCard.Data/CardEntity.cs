using SQLite;

namespace SimpleLangCard.Data
{
    public class CardEntity
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        public string Original { get; set; }

        public string Translation { get; set; }
    }
}
