using Assets.Scripts.Entitites;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("MenuSettings")]
    [SerializeField] TMP_Dropdown difficulty;
    [SerializeField] TMP_Dropdown categories;
    [SerializeField] Button startButton;


    [Header("Questions")]
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] TextMeshProUGUI questionLabel;
    [SerializeField] List<Question> questions = new List<Question>();
    Question currentQuestion;

    [Header("Answers")]
    [SerializeField] GameObject[] answerButtons;
    int correctAnswerIndex;
    bool hasAnsweredEarly = true;

    [Header("Button Colors")]
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;

    //[Header("Timer")]
    //[SerializeField] Image timerImage;
    

    [Header("Scoring")]
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] QuizResult result = new();

    //[Header("ProgressBar")]
    //[SerializeField] Slider progressBar;

    public bool isComplete;


    void Awake()
    {
        
        
    }

    
    void Update()
    {
        
    }
    void OnAnswerSelect()
    {

    }
    
    void DisplayAnswer()
    {

    }

    Question GetNextQuestion()
    {

        return new Question();
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
