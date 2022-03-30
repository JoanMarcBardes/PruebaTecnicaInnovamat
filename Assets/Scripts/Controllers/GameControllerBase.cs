using JoanMarc.Buttons.Shared;
using JoanMarc.Game.Shared;
using UnityEngine;

namespace JoanMarc.Controllers
{
    public class GameControllerBase : MonoBehaviour
    {
        protected IScore _score;
        protected IStatement _statement;
        protected IAnswers _answers;

        private IAnswerButton[] _answerButtonArray;
        private int _currentMistakes = 0;

        protected virtual void Start()
        {
            _answerButtonArray = _answers.GetIAnswerButton();

            foreach (IAnswerButton answerButton in _answerButtonArray)
            {
                answerButton.button.onClick.AddListener(() => OnButtonClick(answerButton));
            }

            _score.UpdateScore();

            StartIdentification();
        }

        private void OnButtonClick(IAnswerButton answerButton)
        {
            if (answerButton.number == _answers.GetCurrentNumber())
            {
                answerButton.image.color = Color.green;

                _score.AddSuccess();
                _score.UpdateScore();

                _currentMistakes = 0;

                StartCoroutine(_answers.HideButtons(StartIdentification));
            }
            else
            {
                answerButton.image.color = Color.red;
                answerButton.button.interactable = false;

                _score.AddFailure();
                _currentMistakes++;

                StartCoroutine(answerButton.fadeItem.FadeOut(() =>
                {
                    if (_currentMistakes == _answerButtonArray.Length - 1)
                    {
                        _answers.GetCurrentRightButton().image.color = Color.green;
                        _currentMistakes = 0;
                        StartCoroutine(_answers.HideButtons(StartIdentification));
                    }
                }));

                if (_currentMistakes == _answerButtonArray.Length - 1)
                {
                    _answers.GetCurrentRightButton().button.interactable = false;
                }

                _score.UpdateScore();
            }
        }

        private void StartIdentification()
        {
            _answers.GenerateAnswers();

            _statement.SetItem(_answers.GetCurrentNumber());

            StartCoroutine(_statement.ShowStatement(_answers.ShowAnswers));
        }

    }

}