using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class TextController : MonoBehaviour
{
    public TextAsset script;
    public Text text_display;
    public Slider slider;
    //the slider can be set with slider.value
    //it has to be a float, between 0 and 1

    private float increment;
    private string filenum;

    void Start()
    {
        slider.value = 1f;
        filenum = "1";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (slider.value == 0)
        {
            text_display.text = script.text;
            increment =  1.0f / ((script.text.Count() + 4) * 10);
            slider.value = increment;
        }
        else if (slider.value == 1)
        {
            increment = -0.01f;
            slider.value = 0.99f;
            script = Resources.Load<TextAsset>("Text/test"+filenum);
            filenum = "2";
        }
        else
        {
            slider.value += increment;
        }
    }
}

//getcomponent with the thoughtBubbles and set ready to true every time new text appears?
//preferably a brief moment after instead.