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

    private Image button1;
    private Image button2;
    private Image button3;

    public bool ready = false;
    public bool loaded = false;
    public int chose = 0;

    [SerializeField] private VibeController vibeCheck;

    // Start is called before the first frame update
    private void Start()
    {
        anim1 = thought1.GetComponent<Animator>();
        anim2 = thought2.GetComponent<Animator>();
        anim3 = thought3.GetComponent<Animator>();
        text1 = thought1.GetComponentInChildren<Text>();
        text2 = thought2.GetComponentInChildren<Text>();
        text3 = thought3.GetComponentInChildren<Text>();
        button1 = thought1.GetComponentInChildren<Image>();
        button2 = thought2.GetComponentInChildren<Image>();
        button3 = thought3.GetComponentInChildren<Image>();
        
        //text1.enabled = true;
        //text2.enabled = true;
        //text3.enabled = true;
    }

    // Update is called once per frame
    private void Update()
    {
        if (ready)
        {
            vibeCheck.is_therapist_listening = false;
            vibeCheck.is_patient_listening = true;
            thought1.GetComponent<Renderer>().enabled = true;
            thought2.GetComponent<Renderer>().enabled = true;
            thought3.GetComponent<Renderer>().enabled = true;
            anim1.SetBool("ready", true);
            anim2.SetBool("ready", true);
            anim3.SetBool("ready", true);
        }
        if (loaded)
        {
            vibeCheck.is_therapist_listening = true;
            vibeCheck.is_patient_listening = false;
            ready = false;
            anim1.SetBool("loaded", true);
            anim2.SetBool("loaded", true);
            anim3.SetBool("loaded", true);
            button1.enabled = true;
            button2.enabled = true;
            button3.enabled = true;
            //text1.enabled = true;
            //text2.enabled = true;
            //text3.enabled = true;
            anim1.SetBool("ready", false);
            anim2.SetBool("ready", false);
            anim3.SetBool("ready", false);
        }

        if (chose >= 1)
        {
            loaded = false;
            anim1.SetInteger("chosen", chose);
            anim2.SetInteger("chosen", chose);
            anim3.SetInteger("chosen", chose);
            button1.enabled = false;
            button2.enabled = false;
            button3.enabled = false;
            text1.enabled = false;
            text2.enabled = false;
            text3.enabled = false;
            anim1.SetBool("loaded", false);
            anim2.SetBool("loaded", false);
            anim3.SetBool("loaded", false);
        }

        if (anim1.GetCurrentAnimatorStateInfo(0).IsName("New State") && anim2.GetCurrentAnimatorStateInfo(0).IsName("New State") && anim3.GetCurrentAnimatorStateInfo(0).IsName("New State"))
        {
            thought1.GetComponent<Renderer>().enabled = false;
            thought2.GetComponent<Renderer>().enabled = false;
            thought3.GetComponent<Renderer>().enabled = false;
            chose = 0;
            anim1.SetInteger("chosen", 0);
            anim2.SetInteger("chosen", 0);
            anim3.SetInteger("chosen", 0);
        }
    }
}
