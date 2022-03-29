using JoanMarc.Fade.Shared;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace JoanMarc.Fade
{
    [RequireComponent(typeof(Graphic))]
    public class FadeColor : MonoBehaviour, IFade
    {
        private Graphic _graphicItem;

        void Awake()
        {
            _graphicItem = GetComponent<Graphic>();
        }

        public IEnumerator FadeIn(Action OnFadeInEnd, float fadeTime = 2.0f)
        {
            Color color = _graphicItem.color;
            float elapsedTime = 0.0f;
            while (elapsedTime < fadeTime)
            {
                yield return null;
                elapsedTime += Time.deltaTime;
                color.a = Mathf.Clamp01(elapsedTime / fadeTime);
                _graphicItem.color = color;
            }

            if (OnFadeInEnd != null) OnFadeInEnd();
        }

        public IEnumerator FadeOut(Action OnFadeOutEnd, float fadeTime = 2.0f)
        {
            Color color = _graphicItem.color;
            float elapsedTime = 0.0f;
            while (elapsedTime < fadeTime)
            {
                yield return null;
                elapsedTime += Time.deltaTime;
                color.a = 1.0f - Mathf.Clamp01(elapsedTime / fadeTime);
                _graphicItem.color = color;
            }

            if (OnFadeOutEnd != null) OnFadeOutEnd();
        }

        public void Show(bool active)
        {
            Color color = _graphicItem.color;
            color.a = active ? 1 : 0;
            _graphicItem.color = color;
        }
    }
}