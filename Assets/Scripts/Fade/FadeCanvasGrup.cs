using JoanMarc.Fade.Shared;
using System;
using System.Collections;
using UnityEngine;

namespace JoanMarc.Fade
{
    [RequireComponent(typeof(CanvasGroup))]
    public class FadeCanvasGrup : MonoBehaviour, IFade
    {
        private CanvasGroup _canvasGroup;

        void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        public IEnumerator FadeIn(Action OnFadeInEnd, float fadeTime = 2.0f)
        {
            float elapsedTime = 0.0f;
            while (elapsedTime < fadeTime)
            {
                yield return null;
                elapsedTime += Time.deltaTime;
                _canvasGroup.alpha = Mathf.Clamp01(elapsedTime / fadeTime);
            }

            if (OnFadeInEnd != null) OnFadeInEnd();
        }

        public IEnumerator FadeOut(Action OnFadeOutEnd, float fadeTime = 2.0f)
        {
            float elapsedTime = 0.0f;
            while (elapsedTime < fadeTime)
            {
                yield return null;
                elapsedTime += Time.deltaTime;
                if (1.0f - Mathf.Clamp01(elapsedTime / fadeTime) < _canvasGroup.alpha)
                {
                    _canvasGroup.alpha = 1.0f - Mathf.Clamp01(elapsedTime / fadeTime);
                }
            }

            if (OnFadeOutEnd != null) OnFadeOutEnd();
        }

        public void Show(bool active)
        {
            _canvasGroup.alpha = active ? 1 : 0;
        }
    }
}