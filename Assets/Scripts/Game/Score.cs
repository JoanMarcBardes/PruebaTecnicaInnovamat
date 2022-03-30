using JoanMarc.Game.Shared;
using UnityEngine;
using UnityEngine.UI;

namespace JoanMarc.Game
{
    public class Score : MonoBehaviour, IScore
    {
        [SerializeField] private Text hitsText;
        [SerializeField] private Text failuresText;

        [SerializeField] private string SuccessesString = "Aciertos";
        [SerializeField] private string FailuresString = "Fallos";

        [SerializeField] private int _successes = 0;
        [SerializeField] private int _failures = 0;

        public void AddSuccess()
        {
            ++_successes;
        }

        public void AddFailure()
        {
            ++_failures;
        }

        public void UpdateScore()
        {
            hitsText.text = SuccessesString + " " + _successes.ToString();
            failuresText.text = FailuresString + " " + _failures.ToString();
        }
    }
}