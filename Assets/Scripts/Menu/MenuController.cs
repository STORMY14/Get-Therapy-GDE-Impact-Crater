using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour
{
    public Animator clipboard1_anim;
    public Animator clipboard2_anim;
    public Animator clipboard3_anim;

    public GameObject clipboard1;
    public GameObject clipboard2;
    public GameObject clipboard3;


    public Animator logo_anim;

    private bool start = false;

    enum TouchType {Tap, SwipeLeft, SwipeRight, None};
    TouchType touchInput;

    private Vector2 startTouchPosition;
    private Vector2 currentTouchPosition;
    private Vector2 endTouchPosition;
    private bool stopTouch = false;

    public float swipeRange;
    public float tapRange;

    void Update()
    {
        touchInput = checkTouchInput();

        if (start is false && touchInput == TouchType.Tap)
        {
            transition();
        }

        if (clipboard1.activeSelf is true)
        {
            if (touchInput == TouchType.SwipeLeft)
            {
                moveClipboardLeft();
            }
            else if (touchInput == TouchType.SwipeRight)
            {
                moveClipboardRight();
            }
        }
    }

    private void spawnClipboards()
    {
        clipboard1.SetActive(true);
        clipboard2.SetActive(true);
        clipboard3.SetActive(true);

        clipboard1_anim.Play("Spawn_Left");
        clipboard2_anim.Play("Spawn_Mid");
        clipboard3_anim.Play("Spawn_Right");
    }

    private void moveClipboardLeft()
    {
        if (clipboard1_anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !clipboard1_anim.IsInTransition(0))
        {
            clipboard1_anim.SetTrigger("Move_Left");
            clipboard2_anim.SetTrigger("Move_Left");
            clipboard3_anim.SetTrigger("Move_Left");
        }
    }

    private void moveClipboardRight()
    {
        if (clipboard1_anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !clipboard1_anim.IsInTransition(0))
        {
            clipboard1_anim.SetTrigger("Move_Right");
            clipboard2_anim.SetTrigger("Move_Right");
            clipboard3_anim.SetTrigger("Move_Right");
        }
    }


    private void transition()
    {
        start = true;
        logo_anim.SetTrigger("Slide_Out");
        spawnClipboards();
    }

    private TouchType checkTouchInput()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPosition = Input.GetTouch(0).position;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            currentTouchPosition = Input.GetTouch(0).position;
            Vector2 distance = currentTouchPosition - startTouchPosition;

            if (!stopTouch)
            {
                if (distance.x < -swipeRange)
                {
                    stopTouch = true;
                    return TouchType.SwipeLeft;
                }
                else if (distance.x > swipeRange)
                {
                    stopTouch = true;
                    return TouchType.SwipeRight;
                }
            }
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            stopTouch = false;
            endTouchPosition = Input.GetTouch(0).position;
            Vector2 distance = endTouchPosition - startTouchPosition;

            if (Mathf.Abs(distance.x) < tapRange && Mathf.Abs(distance.y) < tapRange)
            {
                return TouchType.Tap;
            }
        }

        return TouchType.None;
    }
}
