using Assets.Scripts.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine.UI;

namespace Assets.Scripts.Interfaces
{
    public interface IUI
    {
        public void SetButtonState(bool state);
        public void SetDropDownAlternatives(IEnumerable<Category> categories);
        public void ClearDropDownAlternatives();
        public void SetAnswerButtonTexts(Question question, int correctAnswerIndex);
        public void ClearAnswerButtonTexts();
        public void SetQuestionText(string questionString);
        public void UpdateProgress(int totalQuestions, int answeredQuestions, int correctAnsweredQuestions);
    }
}
