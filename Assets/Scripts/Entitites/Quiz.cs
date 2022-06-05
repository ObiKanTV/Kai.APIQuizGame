
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Entitites
{
    public class Quiz
    {
        public ICollection<Question> Questions { get; set; }
        public APIQuerySettings Settings { get; set; }
        public QuizResult Result { get; set; }

    }
}
