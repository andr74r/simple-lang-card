using SQLite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace SimpleLangCard.Data
{
    public class CardRepository : ICardRepository
    {
        private const string DbName = "cards.db";

        private readonly SQLiteConnection _database;

        public CardRepository()
        {
            _database = new SQLiteConnection(GetDatabasePath());
            _database.CreateTable<CardEntity>();
        }

        public IEnumerable<CardEntity> GetCards()
        {
            return _database.Table<CardEntity>().ToList();
        }

        public int SaveCard(CardEntity cardEntity)
        {
            if (cardEntity.Id != 0)
            {
                _database.Update(cardEntity);
                return cardEntity.Id;
            }
            else
            {
                return _database.Insert(cardEntity);
            }
        }

        public void DeleteCard(int id)
        {
            _database.Delete<CardEntity>(id);
        }

        private static string GetDatabasePath()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DbName);
        }
    }
}
