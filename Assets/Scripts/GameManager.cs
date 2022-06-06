using Assets.Scripts.Clients;
using Assets.Scripts.Entitites;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Services;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("GameSettings")]
    [SerializeField] int numberOfQuestions = 10;
    [SerializeField] int correctAnswerDisplayTime = 5;


    [Header("MenuSettings")]
    
    [SerializeField] Button startButton;
    [SerializeField] MenuSettings menuSettings;


    [Header("Questions")]
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] TextMeshProUGUI questionLabel;
    [SerializeField] List<Question> questions = new List<Question>();
    Question currentQuestion;
    [SerializeField] string currentCorrectAnswer;
    [SerializeField] int currentCorrectAnswerIndex = 0;
    [SerializeField] int currentQuestionIndex = 0;

    [Header("Answers")]
    [SerializeField] Button[] answerButtons;
    bool hasAnsweredEarly = true;

    [Header("Button Colors")]
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;

    //[Header("Timer")]
    //[SerializeField] Image timerImage;

    [Header("Components")]
    [SerializeField] Canvas mainMenu;
    [SerializeField] Canvas quizCanvas;
    [SerializeField] Canvas endResults;
    [SerializeField] TMP_Dropdown difficulty;
    [SerializeField] TMP_Dropdown categoryDropdown;

    [Header("Scoring")]
    [SerializeField] TextMeshProUGUI scoreText;
    Quiz quiz;
    IUI ui;

    //[Header("ProgressBar")]
    //[SerializeField] Slider progressBar;

    public bool isComplete;
    private OpenTriviaClient client;

    void Awake()
    {
        client = new OpenTriviaClient();
        ui = new UI(answerButtons, categoryDropdown, questionText);
    }

    void Update()
    {
        
    }

    public async void OnQuizStart()
    {
        quiz = new Quiz(numberOfQuestions);
        List<Question> temp = await client.GetQuestionsInitAsync(15, null, 10) as List<Question>;

        for (int i = 0; i < temp.Count; i++)
        {
            quiz.Questions[i] = temp[i];
        }

        GetNextQuestion();
        mainMenu.gameObject.SetActive(false);
        quizCanvas.gameObject.SetActive(true);

    }
    public void BackToMainMenu()
    {

    }

    public void OnAnswerSelect(int index)
    {
        UpdateQuestionIndex();
        quiz.Result.AnsweredQuestions++;
        if (index == currentCorrectAnswerIndex) CorrectAnswer();
        else IncorrectAnswer();

        if (quiz.Result.AnsweredQuestions < quiz.Result.NumberOfQuestions) GetNextQuestion();
        else EndGameResult();
    }

    private void EndGameResult()
    {
        quizCanvas.gameObject.SetActive(false);
        endResults.gameObject.SetActive(true);
    }

    void IncorrectAnswer()
    {

        DisplayAnswer();
    }
    void CorrectAnswer()
    {
        
        quiz.Result.CorrectAnswers++;
        DisplayAnswer();
    }
    
    void DisplayAnswer()
    {

    }

    void GetNextQuestion()
    {
        currentQuestion = quiz.Questions[currentQuestionIndex];
        currentCorrectAnswer = currentQuestion.CorrectAnswer;
        ui.SetQuestionText(currentQuestion.QuestionString);
        SetAnswerButtonTexts();
    }
    void SetAnswerButtonTexts()
    {
        currentCorrectAnswerIndex = Random.Range(0, 3);
        ui.SetAnswerButtonTexts(currentQuestion, currentCorrectAnswerIndex);
    }
    void UpdateQuestionIndex()
    {
        currentQuestionIndex++;
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
