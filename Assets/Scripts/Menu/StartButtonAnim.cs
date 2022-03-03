using UnityEngine;

public class StartButtonAnim : MonoBehaviour
{
    public Animator stamp_anim;

    public FadeToBlackScript fadeToBlack;

    public void playStampAnim()
    {
        stamp_anim.Play("Stamp");
    }

    public void playFade()
    {
        fadeToBlack.FadeToScene("Gameplay");
    }
}
