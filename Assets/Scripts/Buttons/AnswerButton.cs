using JoanMarc.Buttons.Shared;
using JoanMarc.Fade;
using JoanMarc.Fade.Shared;
using UnityEngine;
using UnityEngine.UI;

namespace JoanMarc.Buttons
{
    public class AnswerButton : MonoBehaviour, IAnswerButton
    {
        public Button button { get; set; }
        public Text text { get; set; }
        public Image image { get; set; }
        private FadeCanvasGrup _fadeItem { get; set; }
        public IFade fadeItem { get { return _fadeItem; } set { value = _fadeItem; } }
        public int number { get; set; }

        private void Awake()
        {
            button = gameObject.GetComponent<Button>();
            text = gameObject.GetComponentInChildren<Text>();
            image = gameObject.GetComponent<Image>();
            _fadeItem = gameObject.GetComponent<FadeCanvasGrup>();
            number = 0;
        }
    }
}