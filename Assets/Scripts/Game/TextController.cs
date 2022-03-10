using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{

    public Slider slider;
    //the slider can be set with slider.value
    //it has to be a float, between 0 and 1

    private float increment;
    private bool going_up = true;

    void Start()
    {
        slider.value = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value == 0)
        {
            going_up = true;
            //increment = get number of characters in string, add 20, and  divide 1 by that
            //slider.value = increment
        }
        else if (slider.value == 1)
        {
            going_up = false;
            increment = -0.01f;
            slider.value = 0.99f;
        }
        else
        {
            slider.value += increment;
        }
    }
}
