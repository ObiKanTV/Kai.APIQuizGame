using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Entitites
{
    public class Question
    {
        public string QuestionString { get; set; }
        //0 to 3 index of which answer was the correct one after it has been retrieved.
        public int? CorrectAnswerIndex { get; set; }
        public string CorrectAnswer { get; set; }
        public string[] IncorrectAnswers { get; set; } = new string[3];
    }

}
