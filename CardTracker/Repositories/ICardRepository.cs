using CardTracker.Models;
using System.Collections.Generic;

namespace CardTracker.Repositories
{
    public interface ICardRepository
    {
        void Add(Card card);
        void Delete(int id);
        List<Card> GetAll();
        Card GetById(int id);
        void Update(Card card);
    }
}