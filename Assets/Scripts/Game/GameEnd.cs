using UnityEngine;
using UnityEngine.UI;

public class GameEnd : MonoBehaviour
{
    [SerializeField] private Text speech_text;
    [SerializeField] private GameObject thought_bubbles;

    void Update()
    {
        if (speech_text.text == "Thank you." || speech_text.text == "-he left-")
        {
            Debug.Log("END");
            thought_bubbles.SetActive(false);
        }
    }
}
