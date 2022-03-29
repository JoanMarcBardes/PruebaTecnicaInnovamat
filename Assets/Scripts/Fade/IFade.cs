using System;
using System.Collections;

namespace JoanMarc.Fade.Shared
{
    public interface IFade
    {
        IEnumerator FadeIn(Action OnFadeInEnd, float fadeTime = 2.0f);
        IEnumerator FadeOut(Action OnFadeOutEnd, float fadeTime = 2.0f);
        void Show(bool active);
    }
}