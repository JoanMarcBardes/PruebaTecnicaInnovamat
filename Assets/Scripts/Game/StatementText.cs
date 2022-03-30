using JoanMarc.Fade;
using UnityEngine;
using UnityEngine.UI;

namespace JoanMarc.Game
{
    public class StatementText : Statement
    {
        [SerializeField] private FadeGraphic fadeItem;
        [SerializeField] private Text itemRandomNumberText;
        [SerializeField] private string[] numbers = new string[] { "Cero", "Uno", "Dos", "Tres", "Cuatro", "Cinco", "Seis", "Siete", "Ocho", "Nueve" };

        public override void Init()
        {
            _items = numbers;
            _fadeItem = fadeItem;
            base.Init();
        }

        public override void SetItem(int currentNumber)
        {
            itemRandomNumberText.text = numbers[currentNumber];
        }
    }
}