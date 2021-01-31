using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    public static UIHandler instance;
    public static Text bottomText;
    public static Image logo;
    public static Image memory;


    private void Awake()
    {
        instance = this;    
    }

    void Start()
    {
        bottomText = GameObject.FindGameObjectWithTag("BottomText").GetComponent<Text>();
        logo = GameObject.FindGameObjectWithTag("Logo").GetComponent<Image>();
        memory = GameObject.FindGameObjectWithTag("Logo").GetComponent<Image>();
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

    public static void disableLogo()
    {
        logo.enabled = false;
    }

    public static void displayMemory(int number)
    {
        //memory.enabled = true;
        //Sprite sprite = memory.gameObject.GetComponent<Memory>().memories[number];
        //memory.sprite = sprite;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void fadeIn(Image img)
    {
        instance.StartCoroutine(FadeIn(img));
    }

    public static IEnumerator FadeIn(Image img)
    {
        img.enabled = true;
        //Color original = img.color;
        //Color transition = img.color;
        //transition.a = 0f;

        for (float alpha = 0f; alpha <= 1f; alpha += (Time.deltaTime / 5f))
        {
            Color imgColor = img.color;
            imgColor.a = alpha;
            img.color = imgColor;
            yield return null;
        }
        //text.color = original;
    }



}
