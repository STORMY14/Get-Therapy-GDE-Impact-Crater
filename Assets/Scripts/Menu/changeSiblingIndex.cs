using UnityEngine;

public class changeSiblingIndex : MonoBehaviour
{
    public Transform clipboard;

    public void backLeft()
    {
        clipboard.SetSiblingIndex(1);
    }

    public void frontMid()
    {
        clipboard.SetSiblingIndex(4);
    }

    public void backRight()
    {
        clipboard.SetSiblingIndex(2);
    }
}
