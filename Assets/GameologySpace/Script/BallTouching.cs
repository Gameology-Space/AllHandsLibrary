using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTouching : MonoBehaviour
{
    public delegate void FingerTouching(HandDebugBoneInfo finger1, HandDebugBoneInfo finger2);
    public delegate void FingerStoppedTouching(HandDebugBoneInfo finger1, HandDebugBoneInfo finger2);

    public static event FingerTouching OnFingerTouching;
    public static event FingerStoppedTouching OnFingerStoppedTouching;

    private static void FingerTouchingEvent(HandDebugBoneInfo finger1, HandDebugBoneInfo finger2)
    {
        OnFingerTouching?.Invoke(finger1, finger2);
    }

    private static void FingerStoppedTouchingEvent(HandDebugBoneInfo finger1, HandDebugBoneInfo finger2)
    {
        OnFingerStoppedTouching?.Invoke(finger1, finger2);
    }


    HandDebugBoneInfo parent;
    HandDebugBoneInfo collidingParent;

    Enums.HandSide collidingHandSide;
    Enums.FingerName collidingFingerName;

    // Start is called before the first frame update
    void Start()
    {
        parent = GetComponentInParent<HandDebugBoneInfo>();
    }


    void OnTriggerEnter(Collider other)
    {
        collidingParent = other.GetComponentInParent<HandDebugBoneInfo>();

        collidingHandSide = collidingParent.handSide;
        collidingFingerName = collidingParent.fingerName;

        if (collidingFingerName != Enums.FingerName.NotTracked && parent.fingerName != Enums.FingerName.NotTracked)
        {
            //Debug.Log("<color=yellow>" + parent.handSide.ToString() + ":" + parent.fingerName.ToString() + " --collided with-- " + collidingHandSide.ToString() + ":" + collidingFingerName.ToString() + "</color>");
            FingerTouchingEvent(parent, collidingParent);
        }
    }

    void OnTriggerExit(Collider other)
    {
        collidingParent = other.GetComponentInParent<HandDebugBoneInfo>();

        collidingHandSide = collidingParent.handSide;
        collidingFingerName = collidingParent.fingerName;

        if (collidingFingerName != Enums.FingerName.NotTracked && parent.fingerName != Enums.FingerName.NotTracked)
        {
            FingerStoppedTouchingEvent(parent, collidingParent);
        }
    }

}
