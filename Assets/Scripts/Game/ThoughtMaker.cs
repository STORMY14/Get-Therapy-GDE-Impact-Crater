using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThoughtMaker : MonoBehaviour
{
    public GameObject thought1;
    public GameObject thought2;
    public GameObject thought3;

    private Animator anim1;
    private Animator anim2;
    private Animator anim3;

    private Text text1;
    private Text text2;
    private Text text3;

    public bool ready = false;

    public int chose = 0;
    // Start is called before the first frame update
    private void Start()
    {
        anim1 = thought1.GetComponent<Animator>();
        anim2 = thought2.GetComponent<Animator>();
        anim3 = thought3.GetComponent<Animator>();
        text1 = thought1.GetComponentInChildren<Text>();
        text2 = thought2.GetComponentInChildren<Text>();
        text3 = thought3.GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (ready)
        {
            anim1.SetBool("loaded", true);
            anim2.SetBool("loaded", true);
            anim3.SetBool("loaded", true);
        }

        if (chose >= 1)
        {
            anim1.SetInteger("chosen", chose);
            anim2.SetInteger("chosen", chose);
            anim3.SetInteger("chosen", chose);
        }
    }
}
