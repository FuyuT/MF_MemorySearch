using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelOut : MonoBehaviour
{
    Image FadePanel;
   
    public bool IsFadeOut = false;
    float  Speed = 0.02f;
    float  Red, Green, Blue, Alpha;


    // Start is called before the first frame update
    void Start()
    {
        FadePanel = GetComponent<Image>();
        Red = FadePanel.color.r;
        Green = FadePanel.color.g;
        Blue = FadePanel.color.b;
        Alpha = FadePanel.color.a;
    }

    // Update is called once per frame
    void Update()
    {
        if(IsFadeOut)
        {
            Fade();
        }
    }

    void Fade()
    {
        Alpha += Speed;
        FadePanel.color = new Color(Red, Green, Blue, Alpha);
        if(Alpha>=1)
        {
            IsFadeOut = false;
        }
    }
}
