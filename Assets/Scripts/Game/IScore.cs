namespace JoanMarc.Game.Shared
{
    public interface IScore
    {
        public void AddSuccess();

        public void AddFailure();

        public void UpdateScore();
    }
}