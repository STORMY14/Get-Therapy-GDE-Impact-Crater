using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class BackgroundController : MonoBehaviour
{
    // True = Happy
    // False = Sad
    public bool current_patient_mood;
    private bool last_patient_mood;

    private bool isLoopingRed;
    private bool isLoopingGreen;
    private bool transitionToRed;
    private bool transitionToGreen;

    // Green = 0s - 5s
    // Green To Red = 5s - 10s
    // Red = 10s - 15s
    // Red To Green = 15s - 20s
    public VideoPlayer vid_player;

    public double time;

    private void Start()
    {
        current_patient_mood = true;
        last_patient_mood = true;

        isLoopingRed = false;
        isLoopingGreen = true;
        transitionToRed = false;
        transitionToGreen = false;
    }

    private void Update()
    {
        time = vid_player.time;

        playBackground();

        checkNewMood();
    }

    private void loopGreen()
    {
        if (vid_player.time >= 5)
        {
            vid_player.time = 0;
        }
    }

    private void loopRed()
    {
        if (vid_player.time >= 15)
        {
            vid_player.time = 10;
        }
    }

    private void ToRed()
    {
        if (vid_player.time >= 10)
        {
            transitionToRed = false;
            isLoopingRed = true;
        }
    }

    private void ToGreen()
    {
        if (vid_player.time >= 19.9)
        {
            transitionToGreen = false;
            isLoopingGreen = true;
        }
    }

    private void playBackground()
    {
        if (transitionToGreen is true)
        {
            ToGreen();
        }
        else if (transitionToRed is true)
        {
            ToRed();
        }
        else if (isLoopingGreen is true)
        {
            loopGreen();
        }
        else if (isLoopingRed is true)
        {
            loopRed();
        }
    }

    private void checkNewMood()
    {
        if (current_patient_mood != last_patient_mood)
        {
            isLoopingGreen = false;
            isLoopingRed = false;

            if (current_patient_mood is true)
            {
                //vid_player.time = 15;
                transitionToGreen = true;
            }
            else if (current_patient_mood is false)
            {
                //vid_player.time = 5;
                transitionToRed = true;
            }
            last_patient_mood = current_patient_mood;
        }
    }
}
