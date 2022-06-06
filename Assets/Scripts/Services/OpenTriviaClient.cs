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
    public class OpenTriviaClient : IOpenTriviaClient
    {
        HttpClient client;

        public OpenTriviaClient()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://opentdb.com/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<Question>> GetQuestionsInitAsync(int? category, string difficulty = null, int count = 10)
        {
            if (category != null)
            {
                var response = await CheckCategoryCountAsync((int)category);
                if (difficulty != null)
                {
                    switch (difficulty)
                    {
                        case "Easy":
                            if (count > response.total_easy_question_count)
                            {
                                count = response.total_easy_question_count;
                            }
                            break;
                        case "Medium":
                            if (count > response.total_medium_question_count)
                            {
                                count = response.total_medium_question_count;
                            }
                            break;
                        case "Hard":
                            if (count > response.total_hard_question_count)
                            {
                                count = response.total_hard_question_count;
                            }
                            break;
                        default:
                            break;
                    }

                }

            }


            string queryString = QueryBuilder(category, difficulty, count);

            return await GetQuestionsAsync(queryString);
        }

        private static string QueryBuilder(int? category, string difficulty, int count)
        {
            var queryBuilder = new StringBuilder($"api.php?amount={count}&type=multiple");

            if (difficulty != null) queryBuilder = queryBuilder.Append($"&difficulty={difficulty}");
            if (category != null) queryBuilder = queryBuilder.Append($"&category={category}");
            var queryString = queryBuilder.ToString();
            return queryString;
        }

        private async Task<IEnumerable<Question>> GetQuestionsAsync(string path)
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
        public async Task<CategoryQuestionCount> CheckCategoryCountAsync(int index)
        {
            string path = $"api_count.php?category={index}";
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Root root = JsonConvert.DeserializeObject<Root>(content);
                return root.category_question_count;
            }

            return null;
        }





    }
}
