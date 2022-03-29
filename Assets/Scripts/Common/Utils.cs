using System;
using System.Collections;
using UnityEngine;

namespace JoanMarc.Common
{
    public static class Utils
    {
        public static IEnumerator WaitForSeconds(Action OnWaitForSecondsEnd, int seconds = 2)
        {
            yield return new WaitForSeconds(seconds);

            if (OnWaitForSecondsEnd != null) OnWaitForSecondsEnd();
        }
    }
}