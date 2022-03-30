using JoanMarc.Game;
using UnityEngine;

namespace JoanMarc.Controllers
{
    public class GameController : GameControllerBase
    {
        [SerializeField] private Score score;
        [SerializeField] private Statement statement;
        [SerializeField] private Answers answers;

        private void Awake()
        {
            _score = score;
            _statement = statement;
            _answers = answers;
        }

        protected override void Start()
        {
            _statement.Init();

            _answers.Init(_statement.GetItemsLength());

            base.Start();
        }
    }
}