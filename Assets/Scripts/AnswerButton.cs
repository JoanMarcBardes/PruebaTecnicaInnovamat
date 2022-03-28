using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour
{
    public Button button;
    public Text text;
    public Image image;
    public int number;

    public void Start()
    {
        button = gameObject.GetComponent<Button>();
        text = gameObject.GetComponentInChildren<Text>();
        image = gameObject.GetComponent<Image>();
    }
}
