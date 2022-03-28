using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{
    public Image _image = null;

    public void Show()
    {
        StartCoroutine(FadeIn(true, _image));
    }

    public void Hidde()
    {
        StartCoroutine(FadeIn(false, _image));
    }

    IEnumerator FadeIn(bool fadeIn, Image image, float fadeTime = 2.0f)
    {
        if (fadeIn) image.enabled = true;
        float elapsedTime = 0.0f;
        Color c = image.color;
        while (elapsedTime < fadeTime)
        {
            yield return null;
            elapsedTime += Time.deltaTime;
            c.a = fadeIn ? Mathf.Clamp01(elapsedTime / fadeTime) : 1.0f - Mathf.Clamp01(elapsedTime / fadeTime);
            image.color = c;
        }
        if (!fadeIn) image.enabled = false;
    }
}
