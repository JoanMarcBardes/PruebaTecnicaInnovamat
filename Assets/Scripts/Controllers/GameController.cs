using JoanMarc.Buttons;
using JoanMarc.Fade;
using JoanMarc.Controllers.Shared;
using UnityEngine;
using UnityEngine.UI;

namespace JoanMarc.Controllers
{

    public class GameController : GameControllerBase
    {
        [SerializeField] private Text itemRandomNumberText;
        [SerializeField] private FadeColor fadeColor;
        [SerializeField] private AnswerButton[] answerButton;
        [SerializeField] private string[] numbers = new string[] { "Cero", "Uno", "Dos", "Tres", "Cuatro", "Cinco", "Seis", "Siete", "Ocho", "Nueve" };

        private void Awake()
        {
            _fadeItem = fadeColor;
            _answerButtonArray = answerButton;
            _lenghtList = numbers.Length;
        }

        protected override void SetItem()
        {
            itemRandomNumberText.text = numbers[_currentNumber];
        }
    }
}