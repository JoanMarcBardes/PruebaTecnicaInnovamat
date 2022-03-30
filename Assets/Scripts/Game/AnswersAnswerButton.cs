using JoanMarc.Buttons;
using UnityEngine;

namespace JoanMarc.Game
{
    public class AnswersAnswerButton : Answers
    {
        [SerializeField] private AnswerButton[] answerButton;

        public override void Init(int lenghtList)
        {
            _answerButtonArray = answerButton;

            base.Init(lenghtList);
        }

    }
}