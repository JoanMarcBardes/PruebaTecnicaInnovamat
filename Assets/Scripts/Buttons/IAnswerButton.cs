using JoanMarc.Fade.Shared;
using UnityEngine.UI;

namespace JoanMarc.Buttons.Shared
{
    public interface IAnswerButton
    {
        public Button button { get; set; }
        public Text text { get; set; }
        public Image image { get; set; }
        public IFade fadeItem { get; set; }
        public int number { get; set; }
    }
}