using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeToBlackScript : MonoBehaviour
{
    public Animator animator;

    private string sceneToLoad;

    public void FadeToScene (string sceneName)
    {
        sceneToLoad = sceneName;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
