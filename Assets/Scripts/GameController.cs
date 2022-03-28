using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text randomNumberText;
    public AnswerButton[] answerButtonArray;

    private const int Min = 0;
    private const int Max = 9;

    private string[] Numeros = new string[] { "Cero", "Uno", "Dos", "Tres", "Cuatro", "Cinco", "Seis", "Siete", "Ocho", "Nueve" };
    private List<int> _answers;
    private int _currentNumber = 0;
    

    public void Start()
    {
        foreach(AnswerButton answerButton in answerButtonArray)
        {
            answerButton.button.onClick.AddListener(() => OnButtonClick(answerButton));
        }

        StartIdentification();
    }

    private void OnButtonClick(AnswerButton answerButton)
    {
        if(answerButton.number == _currentNumber)
        {
            answerButton.image.color = Color.green;

            StartIdentification();
        }
        else
        {
            answerButton.image.color = Color.red;
        }
    }

    private void StartIdentification()
    {
        GenerateAnswers();

        ShowAnswers();
    }

    private void GenerateAnswers()
    {
        _answers = new List<int>();
        int posicionAleatoria;
        for (int i = 0; i < answerButtonArray.Length; i++)
        {
            do
            {
                posicionAleatoria = Random.Range(Min,Max);
            } while (_answers.Contains(posicionAleatoria));
            _answers.Add(posicionAleatoria);
        }

        _currentNumber = _answers[0];

        randomNumberText.text = Numeros[_currentNumber];
    }

    private void ShowAnswers()
    {
        int randomIndex = Random.Range(0,answerButtonArray.Length);

        foreach(AnswerButton answerButton in answerButtonArray)
        {
            answerButton.text.text = _answers[randomIndex].ToString();
            answerButton.number = _answers[randomIndex];
            answerButton.image.color = Color.white;

            randomIndex = ++randomIndex % answerButtonArray.Length;
        }

    }
}
