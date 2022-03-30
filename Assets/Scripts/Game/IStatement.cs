using System;
using System.Collections;

namespace JoanMarc.Game.Shared
{
    public interface IStatement
    {
        public void Init();

        public int GetItemsLength();

        public abstract void SetItem(int currentNumber);

        public IEnumerator ShowStatement(Action OnEndShowStatement);
    }
}