using JoanMarc.Common;
using JoanMarc.Fade.Shared;
using JoanMarc.Game.Shared;
using System;
using System.Collections;
using UnityEngine;

namespace JoanMarc.Game
{
    public abstract class Statement : MonoBehaviour, IStatement
    {
        protected IFade _fadeItem;
        protected object[] _items;

        public virtual void Init()
        {
            _fadeItem.Show(false);
        }

        public int GetItemsLength()
        {
            return _items.Length;
        }

        public abstract void SetItem(int currentNumber);

        public IEnumerator ShowStatement(Action OnEndShowStatement)
        {
            yield return null;

            AnimationItem(OnEndShowStatement);
        }

        private void AnimationItem(Action OnEndShowStatement)
        {
            StartCoroutine(_fadeItem.FadeIn(() => OnEndFadeInItem(OnEndShowStatement)));
        }

        private void OnEndFadeInItem(Action OnEndShowStatement)
        {
            StartCoroutine(Utils.WaitForSeconds(() => FadeOutItem(OnEndShowStatement)));
        }

        private void FadeOutItem(Action OnEndShowStatement)
        {
            StartCoroutine(_fadeItem.FadeOut(OnEndShowStatement));
        }
    }
}