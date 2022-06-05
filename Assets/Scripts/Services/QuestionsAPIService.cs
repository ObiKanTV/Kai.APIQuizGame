using Assets.Scripts.Entitites;
using Assets.Scripts.Entitites.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Clients
{
    public class QuestionsAPIService
    {
        HttpClient client;

        public QuestionsAPIService()
        {
            client = new HttpClient();
        }

        public async Task RunAsync()
        {
            client.BaseAddress = new Uri("https://opentdb.com/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<Question>> GetQuestionsInitAsync(int? category , string difficulty = null, int count = 10)
        {
            var queryBuilder = new StringBuilder($"api.php?amount{count}&type=multiple");

            if (difficulty != null) queryBuilder = queryBuilder.Append($"&difficulty={difficulty}");
            if (category != null) queryBuilder = queryBuilder.Append($"&category={category}");

            return await GetQuestionsAsync(queryBuilder.ToString());
        }

        public async Task<IEnumerable<Question>> GetQuestionsAsync(string path)
        {
            List<Question> questions = new List<Question>();

            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Root root = JsonConvert.DeserializeObject<Root>(content);
                if (root.response_code == 0)
                {
                   foreach (var result in root.results)
                   {
                       var question = new Question() 
                       { 
                           CorrectAnswer = result.correct_answer,
                           QuestionString = result.question,
                       };
                       for (int i = 0; i < result.incorrect_answers.Count; i++)
                       {
                           question.IncorrectAnswers[i] = result.incorrect_answers[i];
                       }
                       questions.Add(question);
                   }
                }
            }

            return questions;
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            var categories = new List<Category>();
            string path = "api_category.php";
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Root root = JsonConvert.DeserializeObject<Root>(content);
                categories.AddRange(root.categories);
            }
            return categories;
        }

           



    }
}
