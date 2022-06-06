using Assets.Scripts.Clients;
using Assets.Scripts.Entitites;
using Bogus;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("MenuSettings")]
    [SerializeField] TMP_Dropdown difficulty;
    [SerializeField] TMP_Dropdown categories;
    [SerializeField] Button startButton;
    [SerializeField] MenuSettings menuSettings;


    [Header("Questions")]
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] TextMeshProUGUI questionLabel;
    [SerializeField] List<Question> questions = new List<Question>();
    Question currentQuestion;
    [SerializeField] string currentCorrectAnswer;
    [SerializeField] int currentQuestionIndex = 0;

    [Header("Answers")]
    [SerializeField] GameObject[] answerButtons;
    bool hasAnsweredEarly = true;

    [Header("Button Colors")]
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;

    //[Header("Timer")]
    //[SerializeField] Image timerImage;
    

    [Header("Scoring")]
    [SerializeField] TextMeshProUGUI scoreText;
    Quiz quiz;
    Faker faker = new Faker("en");

    //[Header("ProgressBar")]
    //[SerializeField] Slider progressBar;

    public bool isComplete;
    private OpenTriviaClient client;

    void Awake()
    {
        client = new OpenTriviaClient();
        
    }

    
    void Update()
    {
        
    }
    public async void OnQuizStart()
    {
        quiz = new Quiz();
        List<Question> temp = await client.GetQuestionsInitAsync(15, null, 10) as List<Question>;

        for (int i = 0; i < temp.Count; i++)
        {
            quiz.Questions[i] = temp[i];
        }

        //foreach (var question in quiz.Questions)
        //{
        //    Debug.Log(question.QuestionString);
        //    Debug.Log(question.CorrectAnswer);
        //    foreach (var incorrectAnswer in question.IncorrectAnswers)
        //    {
        //        Debug.Log(incorrectAnswer);
        //    }
        //}
    }

    void OnAnswerSelect()
    {

    }
    
    void DisplayAnswer()
    {

    }

    void GetNextQuestion()
    {
        currentQuestion = quiz.Questions[currentQuestionIndex];
        currentCorrectAnswer = currentQuestion.CorrectAnswer;
        questionText.SetText(currentQuestion.QuestionString);
    }
    void SetAnswerButtonTexts()
    {
        int correctAnswerIndex = faker.Random.Int(0, 3);
        switch (correctAnswerIndex)
        {
            case 0:

                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            default:
                break;
        }



    }
    void UpdateQuestionIndex()
    {
        currentQuestionIndex++;
    }

    void SetButtonState(bool state)
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            Button button = answerButtons[i].GetComponent<Button>();
            button.interactable = state;
        }
    }
    void SetDefaultButtonSprites()
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            Image buttonImage = answerButtons[i].GetComponent<Image>();
            buttonImage.sprite = defaultAnswerSprite;

        }
    }


}
