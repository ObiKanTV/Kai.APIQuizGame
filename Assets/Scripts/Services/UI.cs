using Assets.Scripts.Entitites;
using Assets.Scripts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine.UI;

namespace Assets.Scripts.Services
{
    public class UI : IUI
    {
        private readonly Button[] answerButtons;
        private readonly TMP_Dropdown categoryDropdown;
        private readonly TextMeshProUGUI questionText;

        public UI(Button[] answerButtons, TMP_Dropdown categoryDropdown, TextMeshProUGUI questionText)
        {
            this.answerButtons = answerButtons;
            this.categoryDropdown = categoryDropdown;
            this.questionText = questionText;
        }
        public void SetButtonState(bool state)
        {
            for (int i = 0; i < answerButtons.Length; i++)
            {
                Button button = answerButtons[i].GetComponent<Button>();
                button.interactable = state;
            }
        }
        public void ClearAnswerButtonTexts()
        {
            throw new NotImplementedException();
        }

        public void SetQuestionText(string questionString)
        {
            questionText.text = questionString;
        }

        public void SetAnswerButtonTexts(Question question, int correctAnswerIndex)
        {
            int incorrectIndex = 0;
            for (int i = 0; i < 4; i++)
            {
                if (i == correctAnswerIndex)
                {
                    answerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = question.CorrectAnswer;
                }
                else
                {
                    answerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = question.IncorrectAnswers[incorrectIndex];
                    incorrectIndex++;
                }
            }
        }

        public void SetDropDownAlternatives(IEnumerable<Category> categories)
        {
            throw new NotImplementedException();
        }
        public void ClearDropDownAlternatives()
        {
            throw new NotImplementedException();
        }

        public void UpdateProgress(int totalQuestions, int answeredQuestions, int correctAnsweredQuestions)
        {
            throw new NotImplementedException();
        }
    }
}
