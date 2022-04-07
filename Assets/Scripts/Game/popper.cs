using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class popper : MonoBehaviour
{
    // Start is called before the first frame update
    private SpriteRenderer renderer;
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void PrintEvent(Sprite s)
    {
        renderer.enabled = false;
    }
}
