
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Entitites
{
    public class Quiz
    {
        public Quiz(int numberOfQuestions = 10)
        {
            //Result.NumberOfQuestions = numberOfQuestions;
        }
        public Question[] Questions { get; set; } = new Question[10];
        public APIQuerySettings Settings { get; set; } = new APIQuerySettings();
        public QuizResult Result { get; set; }  = new QuizResult();


    }
}
