using Assets.Scripts.Entitites;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Assets.Scripts.Clients
{
    public interface IOpenTriviaClient
    {
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<IEnumerable<Question>> GetQuestionsInitAsync(int? category, string difficulty = null, int count = 10);
    }
}