using JoanMarc.Buttons.Shared;
using JoanMarc.Game.Shared;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JoanMarc.Game
{
    public class Answers : MonoBehaviour, IAnswers
    {
        protected IAnswerButton[] _answerButtonArray;
        protected IAnswerButton _currentRightButton;

        protected int _currentNumber = 0;
        protected int _lenghtList = 0;
        private List<int> _answersList;

        public IAnswerButton GetCurrentRightButton() { return _currentRightButton; }
        public int GetCurrentNumber() { return _currentNumber; }

        public IAnswerButton[] GetIAnswerButton() { return _answerButtonArray; }

        public virtual void Init(int lenghtList)
        {
            _lenghtList = lenghtList;

            DontShowButtons();
        }

        public void GenerateAnswers()
        {
            _answersList = new List<int>();
            int randomNumber;
            for (int i = 0; i < _answerButtonArray.Length; i++)
            {
                do
                {
                    randomNumber = UnityEngine.Random.Range(0, _lenghtList);
                } while (_answersList.Contains(randomNumber));
                _answersList.Add(randomNumber);
            }

            _currentNumber = _answersList[0];
        }

        public void ShowAnswers()
        {
            int randomIndex = UnityEngine.Random.Range(0, _answerButtonArray.Length);

            foreach (IAnswerButton answerButton in _answerButtonArray)
            {
                answerButton.text.text = _answersList[randomIndex].ToString();
                answerButton.number = _answersList[randomIndex];
                answerButton.image.color = Color.white;
                answerButton.fadeItem.Show(true);

                if (answerButton.number == _currentNumber) _currentRightButton = answerButton;

                randomIndex = ++randomIndex % _answerButtonArray.Length;
            }

            ShowButtons();
        }

        private void ShowButtons()
        {
            foreach (IAnswerButton answerButton in _answerButtonArray)
            {

                StartCoroutine(answerButton.fadeItem.FadeIn(() =>
                {
                    answerButton.button.interactable = true;
                }));
            }
        }

        public IEnumerator HideButtons(Action OnEndhideButtons)
        {
            yield return null;
            bool first = true;
            foreach (IAnswerButton answerButton in _answerButtonArray)
            {
                answerButton.button.interactable = false;
                StartCoroutine(answerButton.fadeItem.FadeOut(() =>
                {
                    if (first)
                    {
                        OnEndhideButtons();
                        first = false;
                    }
                }));
            }
        }

        private void DontShowButtons()
        {
            foreach (IAnswerButton answerButton in _answerButtonArray)
            {
                answerButton.fadeItem.Show(false);
            }
        }
    }
}