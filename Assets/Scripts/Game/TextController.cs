using System;
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

    public GameObject thought_maker;
    public GameObject thought_controller;
    
    private float increment;
    private string filenum;
    private int textnum;

    private string[] route1 = {"0", "1", "1-1", "1-1-1", "1-1-1-1", "1-1-1-1-1"};
    private string[] route2 = {"0", "2", "2-2", "2-2-2", "2-2-2-2", "2-2-2-2-2"};
    private string[] routeon;

    void Start()
    {
        slider.value = 1f;
        textnum = 0;
        routeon = route1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (slider.value == 0)
        {
            script = Resources.Load<TextAsset>("Text/P-"+routeon[textnum]);
            textnum += 1;
            text_display.text = script.text;
            increment =  1.0f / ((script.text.Count() + 3) * 10);
            slider.value = increment;
            thought_maker.GetComponent<ThoughtMaker>().loaded = true;
            thought_controller.GetComponent<ThoughtController>().thoughtnum = routeon[textnum-1];
            thought_controller.GetComponent<ThoughtController>().thoughtload = true;
        }
        else if (slider.value == 1)
        {
            script = Resources.Load<TextAsset>("Text/T-"+routeon[textnum]);
            text_display.text = script.text;
            increment =  -(1.0f / ((script.text.Count() + 3) * 10));
            slider.value = 1 + increment;
            thought_maker.GetComponent<ThoughtMaker>().ready = true;
        }
        else
        {
            slider.value += increment;
        }
    }
    
    public void SwitchRoute()
    {
        routeon = route2;
    }
}

//getcomponent with the thoughtBubbles and set ready to true every time new text appears?
//preferably a brief moment after instead.