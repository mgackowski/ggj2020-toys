using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    public static UIHandler instance;
    public static Text bottomText;

    private void Awake()
    {
        instance = this;    
    }

    void Start()
    {
        bottomText = GameObject.FindGameObjectWithTag("BottomText").GetComponent<Text>();
    }

    public static void ChangeBottomText(string newText)
    {
        bottomText.text = newText;
    }

    public static void FadeOutBottomText(string newText, float duration)
    {
        ChangeBottomText(newText);
        instance.StartCoroutine(UIHandler.FadeOut(bottomText,duration));
    }

    public static IEnumerator FadeOut(Text text, float duration)
    {
        Color original = text.color;
        for (float alpha = 1f; alpha>=0; alpha -= (Time.deltaTime / duration))
        {
            Color textColor = text.color;
            textColor.a = alpha;
            text.color = textColor;
            yield return null;
        }
        text.text = "";
        text.color = original;
    }

    // Update is called once per frame
    void Update()
    {
        
    }



}
