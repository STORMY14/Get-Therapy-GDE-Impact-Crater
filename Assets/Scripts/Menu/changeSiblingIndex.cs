using UnityEngine;

public class changeSiblingIndex : MonoBehaviour
{
    public Transform clipboard;

    public void backLeft()
    {
        clipboard.SetSiblingIndex(2);
    }

    public void frontMid()
    {
        clipboard.SetSiblingIndex(5);
    }

    public void backRight()
    {
        clipboard.SetSiblingIndex(3);
    }
}
