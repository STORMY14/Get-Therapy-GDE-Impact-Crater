using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class BackgroundController : MonoBehaviour
{
    // True = Happy
    // False = Sad
    public bool current_patient_mood = true;
    private bool last_patient_mood = true;

    public VideoClip Red;
    public VideoClip Green;
    public VideoClip RedToGreen;
    public VideoClip GreenToRed;

    public VideoPlayer vid_player;

    private void Update()
    {
        if (current_patient_mood != last_patient_mood)
        {
            if (current_patient_mood is true)
            {
                vid_player.clip = RedToGreen;
                vid_player.loopPointReached += ToGreen;
            }
            else
            {
                vid_player.clip = GreenToRed;
                vid_player.loopPointReached += ToRed;
            }
            last_patient_mood = current_patient_mood;
        }
    }

    private void ToRed(UnityEngine.Video.VideoPlayer vp)
    {
        vp.clip = Red;
    }

    private void ToGreen(UnityEngine.Video.VideoPlayer vp)
    {
        vp.clip = Green;
    }
}
