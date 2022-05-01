using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEditor;
using UnityEditor.UI;
using UnityEngine;

public class popper : MonoBehaviour
{
    public int bubblenum;
    // Start is called before the first frame update
    private SpriteRenderer renderer;
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    public void OnPress()
    {
        Debug.Log(bubblenum);
        GetComponentInParent<ThoughtMaker>().chose = bubblenum;
    }
}
