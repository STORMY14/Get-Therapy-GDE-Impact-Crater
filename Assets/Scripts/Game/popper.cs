using UnityEngine;

public class popper : MonoBehaviour
{
    public int bubblenum;

    public void OnPress()
    {
        GetComponentInParent<ThoughtMaker>().chose = bubblenum;
    }
}
