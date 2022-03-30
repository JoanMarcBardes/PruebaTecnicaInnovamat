using JoanMarc.Buttons.Shared;
using System;
using System.Collections;

namespace JoanMarc.Game.Shared
{
    public interface IAnswers
    {
        public IAnswerButton GetCurrentRightButton();

        public int GetCurrentNumber();

        public IAnswerButton[] GetIAnswerButton();

        public void Init(int lenghtList);

        public void GenerateAnswers();

        public void ShowAnswers();

        public IEnumerator HideButtons(Action OnEndhideButtons);
    }
}