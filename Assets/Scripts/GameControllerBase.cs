using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerBase : MonoBehaviour
{
    [SerializeField] private Text hitsText;
    [SerializeField] private Text failuresText;

    protected IAnswerButton[] _answerButtonArray;
    protected IFade _fadeItem;
    protected IAnswerButton _currentRightButton;

    private const string Successes = "Aciertos";
    private const string Failures = "Fallos";

    protected int _currentNumber = 0;
    protected int _lenghtList = 0;
    private List<int> _answers;
    private int _successes = 0;
    private int _failures = 0;
    private int _currentMistakes = 0;

    public void Start()
    {
        foreach(IAnswerButton answerButton in _answerButtonArray)
        {
            answerButton.button.onClick.AddListener(() => OnButtonClick(answerButton));
        }

        DontShowButtons();
        UpdateScore();
        StartIdentification();
    }

    private void OnButtonClick(IAnswerButton answerButton)
    {
        if(answerButton.number == _currentNumber)
        {
            answerButton.image.color = Color.green;

            _successes++;
            _currentMistakes = 0;

            UpdateScore();
            HideButtons();
        }
        else
        {
            answerButton.image.color = Color.red;
            answerButton.button.interactable = false;

            _failures++;
            _currentMistakes++;

            StartCoroutine(answerButton.fadeItem.FadeOut(() => {
                if (_currentMistakes == _answerButtonArray.Length - 1)
                {
                    _currentRightButton.image.color = Color.green;
                    _currentMistakes = 0;
                    HideButtons();
                }
            }));

            if (_currentMistakes == _answerButtonArray.Length - 1)
            {
                _currentRightButton.button.interactable = false;
            }

            UpdateScore();
        }
    }

    private void UpdateScore()
    {
        hitsText.text = Successes + " " + _successes.ToString();
        failuresText.text = Failures + " " + _failures.ToString();
    }

    private void StartIdentification()
    {
        GenerateAnswers();

        SetItem();

        AnimationItem();
    }

    private void GenerateAnswers()
    {
        _answers = new List<int>();
        int randomNumber;
        for (int i = 0; i < _answerButtonArray.Length; i++)
        {
            do
            {
                randomNumber = UnityEngine.Random.Range(0, _lenghtList);
            } while (_answers.Contains(randomNumber));
            _answers.Add(randomNumber);
        }

        _currentNumber = _answers[0];
    }

    protected virtual void SetItem() { }

    private void AnimationItem()
    {
        StartCoroutine(_fadeItem.FadeIn(OnEndFadeInItem));
    }

    private void OnEndFadeInItem()
    {
        StartCoroutine(WaitForSeconds(FadeOutItem));
    }

    private void FadeOutItem()
    {
        StartCoroutine(_fadeItem.FadeOut(ShowAnswers));
    }

    IEnumerator WaitForSeconds(Action OnWaitForSecondsEnd, int seconds = 2)
    {
        yield return new WaitForSeconds(seconds);

        if (OnWaitForSecondsEnd != null) OnWaitForSecondsEnd();
    }

    private void ShowAnswers()
    {
        int randomIndex = UnityEngine.Random.Range(0, _answerButtonArray.Length);

        foreach (IAnswerButton answerButton in _answerButtonArray)
        {
            answerButton.text.text = _answers[randomIndex].ToString();
            answerButton.number = _answers[randomIndex];
            answerButton.image.color = Color.white;
            answerButton.fadeItem.Show(true);

            if (answerButton.number == _currentNumber) _currentRightButton = answerButton;

            randomIndex = ++randomIndex % _answerButtonArray.Length;
        }

        ShowButtons();
    }

    private void ShowButtons()
    {
        foreach (AnswerButton answerButton in _answerButtonArray)
        {
            
            StartCoroutine(answerButton.fadeItem.FadeIn( () => {
                answerButton.button.interactable = true;
            }));
        }
    }

    private void HideButtons()
    {
        bool first = true;
        foreach (AnswerButton answerButton in _answerButtonArray)
        {
            answerButton.button.interactable = false;
            StartCoroutine(answerButton.fadeItem.FadeOut(() => {
               if (first)
                {
                    StartIdentification();
                    first = false;
                }
            }));
        }
    }

    private void DontShowButtons()
    {
        foreach (AnswerButton answerButton in _answerButtonArray)
        {
            answerButton.fadeItem.Show(false);
        }
    }
}
