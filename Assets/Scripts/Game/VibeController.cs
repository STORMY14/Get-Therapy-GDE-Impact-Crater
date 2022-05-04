using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibeController : MonoBehaviour
{
    [Range(-1.0f, 1.0f)]
    public float patient_vibe;

    public bool is_therapist_listening;
    public bool is_patient_listening;

    [SerializeField] private Animator patient_animator;
    [SerializeField] private Animator therapist_animator;

    [SerializeField] private GameObject scribble;
    [SerializeField] private Transform scribble_anchor;

    [SerializeField] private BackgroundController background;

    void Start()
    {
        is_therapist_listening = false;
        is_patient_listening = true;
    }

    void Update()
    {
        updateAnims();
        updateScribble();
        updateBackground();
    }

    void updateAnims()
    {
        therapist_animator.SetBool("is_listening", is_therapist_listening);
        patient_animator.SetBool("is_listening", is_patient_listening);
        patient_animator.SetFloat("vibe", patient_vibe);
    }

    void updateScribble()
    {
        scribble.transform.localScale = new Vector3(30 - (patient_vibe * 30), 30 - (patient_vibe * 30), 0);
        scribble.transform.position = scribble_anchor.position;
    }

    void updateBackground()
    {
        if (patient_vibe >= 0)
        {
            background.current_patient_mood = true;
        }
        else
        {
            background.current_patient_mood = false;
        }
    }

    public void goodVibes()
    {
        patient_vibe += 0.3f;
        patient_vibe = Mathf.Clamp(patient_vibe, -1, 1);
    }

    public void badVibes()
    {
        patient_vibe -= 0.3f;
        patient_vibe = Mathf.Clamp(patient_vibe, -1, 1);
    }
}
