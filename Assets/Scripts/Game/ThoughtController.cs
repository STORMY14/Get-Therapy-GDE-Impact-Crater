using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThoughtController : MonoBehaviour
{
    public TextAsset line1;
    public TextAsset line2;
    public TextAsset line3;

    public Text choice1;
    public Text choice2;
    public Text choice3;

    public bool thoughtload = false;
    public string thoughtnum;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (thoughtload)
        {
            Debug.Log(thoughtnum);
            line1 = Resources.Load<TextAsset>("Text/S-"+thoughtnum+"-1");
            line2 = Resources.Load<TextAsset>("Text/S-"+thoughtnum+"-2");
            line3 = Resources.Load<TextAsset>("Text/S-"+thoughtnum+"-3");
            choice1.text = line1.text;
            choice2.text = line2.text;
            choice3.text = line3.text;
            thoughtload = false;
        }
    }
}
