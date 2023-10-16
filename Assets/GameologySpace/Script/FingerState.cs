using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class FingerStates : MonoBehaviour
{
    // Define the data structure to track the states
    Dictionary<Enums.HandSide, Dictionary<Enums.FingerName, List<Enums.FingerName>>> fingerTouchStates;

    private Dictionary<string, Coroutine> touchStateCoroutines = new Dictionary<string, Coroutine>();


    public bool isLeftIndexTouchingRightIndex;
    public bool isLeftIndexTouchingRightThumb;
    public bool isLeftThumbTouchingRightIndex;
    public bool isRightThumbTouchingLeftThumb;

    [SerializeField]
    private float timeToWaitBeforeResettingState = 2.5f;

    // Static instance of the class
    public static FingerStates Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep this instance alive across scenes
        }
        else
        {
            Destroy(gameObject); // Destroy additional instances if any
        }

        // Other initialization code
    }


    void Start()
    {
        // Initialize the dictionary
        fingerTouchStates = new Dictionary<Enums.HandSide, Dictionary<Enums.FingerName, List<Enums.FingerName>>>();

        // Subscribe to the events
        BallTouching.OnFingerTouching += HandleFingerTouching;
        BallTouching.OnFingerStoppedTouching += HandleFingerStoppedTouching;
    }

    void OnDisable()
    {
        // Unsubscribe from the events when the object is disabled to avoid memory leaks
        BallTouching.OnFingerTouching -= HandleFingerTouching;
        BallTouching.OnFingerStoppedTouching -= HandleFingerStoppedTouching;
    }

    void HandleFingerTouching(HandDebugBoneInfo finger1, HandDebugBoneInfo finger2)
    {
        
        // Check if the left index finger is touching the right index finger or right thumb
        if ((finger1.fingerName == Enums.FingerName.Index && finger1.handSide == Enums.HandSide.Left &&
             finger2.fingerName == Enums.FingerName.Index && finger2.handSide == Enums.HandSide.Right) ||
            (finger1.fingerName == Enums.FingerName.Index && finger1.handSide == Enums.HandSide.Right &&
             finger2.fingerName == Enums.FingerName.Index && finger2.handSide == Enums.HandSide.Left))
        {
            isLeftIndexTouchingRightIndex = true;
            string stateName = "isLeftIndexTouchingRightIndex";

            // if there's already a coroutine running for this state, stop it
            if (touchStateCoroutines.ContainsKey(stateName) && touchStateCoroutines[stateName] != null)
            {
                StopCoroutine(touchStateCoroutines[stateName]);
            }

            // remove it from the dictionary
            touchStateCoroutines.Remove(stateName);
        }
        
        if ((finger1.fingerName == Enums.FingerName.Index && finger1.handSide == Enums.HandSide.Left &&
                  finger2.fingerName == Enums.FingerName.Thumb && finger2.handSide == Enums.HandSide.Right) ||
                 (finger1.fingerName == Enums.FingerName.Thumb && finger1.handSide == Enums.HandSide.Right &&
                  finger2.fingerName == Enums.FingerName.Index && finger2.handSide == Enums.HandSide.Left))
        {
            isLeftIndexTouchingRightThumb = true;
            string stateName = "isLeftIndexTouchingRightThumb";

            // if there's already a coroutine running for this state, stop it
            if (touchStateCoroutines.ContainsKey(stateName) && touchStateCoroutines[stateName] != null)
            {
                StopCoroutine(touchStateCoroutines[stateName]);
            }
            // remove it from the dictionary
            touchStateCoroutines.Remove(stateName);
        }

        // Check if the left thumb is touching the right index finger
        if ((finger1.fingerName == Enums.FingerName.Thumb && finger1.handSide == Enums.HandSide.Left &&
             finger2.fingerName == Enums.FingerName.Index && finger2.handSide == Enums.HandSide.Right) ||
            (finger1.fingerName == Enums.FingerName.Index && finger1.handSide == Enums.HandSide.Right &&
             finger2.fingerName == Enums.FingerName.Thumb && finger2.handSide == Enums.HandSide.Left))
        {
            isLeftThumbTouchingRightIndex = true;
            string stateName = "isLeftThumbTouchingRightIndex";

            // if there's already a coroutine running for this state, stop it
            if (touchStateCoroutines.ContainsKey(stateName) && touchStateCoroutines[stateName] != null)
            {
                StopCoroutine(touchStateCoroutines[stateName]);
            }
            // remove it from the dictionary
            touchStateCoroutines.Remove(stateName);
        }

        // Check if the right thumb is touching the left thumb
        if ((finger1.fingerName == Enums.FingerName.Thumb && finger1.handSide == Enums.HandSide.Right &&
             finger2.fingerName == Enums.FingerName.Thumb && finger2.handSide == Enums.HandSide.Left) ||
            (finger1.fingerName == Enums.FingerName.Thumb && finger1.handSide == Enums.HandSide.Left &&
             finger2.fingerName == Enums.FingerName.Thumb && finger2.handSide == Enums.HandSide.Right))
        {
            isRightThumbTouchingLeftThumb = true;
            string stateName = "isRightThumbTouchingLeftThumb";

            // if there's already a coroutine running for this state, stop it
            if (touchStateCoroutines.ContainsKey(stateName) && touchStateCoroutines[stateName] != null)
            {
                StopCoroutine(touchStateCoroutines[stateName]);
            }
            // remove it from the dictionary
            touchStateCoroutines.Remove(stateName);
        }
    }

    void HandleFingerStoppedTouching(HandDebugBoneInfo finger1, HandDebugBoneInfo finger2)
    {

        // Check if the left index finger has stopped touching the right index finger or right thumb
        if ((finger1.fingerName == Enums.FingerName.Index && finger1.handSide == Enums.HandSide.Left &&
             finger2.fingerName == Enums.FingerName.Index && finger2.handSide == Enums.HandSide.Right) ||
            (finger1.fingerName == Enums.FingerName.Index && finger1.handSide == Enums.HandSide.Right &&
             finger2.fingerName == Enums.FingerName.Index && finger2.handSide == Enums.HandSide.Left))
        {
            string stateName = "isLeftIndexTouchingRightIndex";

            // if there's no coroutine running for this state, start a new one
            if (!touchStateCoroutines.ContainsKey(stateName) || touchStateCoroutines[stateName] == null)
            {
                touchStateCoroutines[stateName] = StartCoroutine(WaitAndSetFalse(stateName));
            }
        }
        
        if ((finger1.fingerName == Enums.FingerName.Index && finger1.handSide == Enums.HandSide.Left &&
                  finger2.fingerName == Enums.FingerName.Thumb && finger2.handSide == Enums.HandSide.Right) ||
                 (finger1.fingerName == Enums.FingerName.Thumb && finger1.handSide == Enums.HandSide.Right &&
                  finger2.fingerName == Enums.FingerName.Index && finger2.handSide == Enums.HandSide.Left))
        {
            string stateName = "isLeftIndexTouchingRightThumb";

            // if there's no coroutine running for this state, start a new one
            if (!touchStateCoroutines.ContainsKey(stateName) || touchStateCoroutines[stateName] == null)
            {
                touchStateCoroutines[stateName] = StartCoroutine(WaitAndSetFalse(stateName));
            }
        }

        // Check if the left thumb has stopped touching the right index finger
        if ((finger1.fingerName == Enums.FingerName.Thumb && finger1.handSide == Enums.HandSide.Left &&
             finger2.fingerName == Enums.FingerName.Index && finger2.handSide == Enums.HandSide.Right) ||
            (finger1.fingerName == Enums.FingerName.Index && finger1.handSide == Enums.HandSide.Right &&
             finger2.fingerName == Enums.FingerName.Thumb && finger2.handSide == Enums.HandSide.Left))
        {
            string stateName = "isLeftThumbTouchingRightIndex";

            // if there's no coroutine running for this state, start a new one
            if (!touchStateCoroutines.ContainsKey(stateName) || touchStateCoroutines[stateName] == null)
            {
                touchStateCoroutines[stateName] = StartCoroutine(WaitAndSetFalse(stateName));
            }
        }

        // Check if the right thumb has stopped touching the left thumb
        if ((finger1.fingerName == Enums.FingerName.Thumb && finger1.handSide == Enums.HandSide.Right &&
             finger2.fingerName == Enums.FingerName.Thumb && finger2.handSide == Enums.HandSide.Left) ||
            (finger1.fingerName == Enums.FingerName.Thumb && finger1.handSide == Enums.HandSide.Left &&
             finger2.fingerName == Enums.FingerName.Thumb && finger2.handSide == Enums.HandSide.Right))
        {
            string stateName = "isRightThumbTouchingLeftThumb";

            // if there's no coroutine running for this state, start a new one
            if (!touchStateCoroutines.ContainsKey(stateName) || touchStateCoroutines[stateName] == null)
            {
                touchStateCoroutines[stateName] = StartCoroutine(WaitAndSetFalse(stateName));
            }
        }
    }

    IEnumerator WaitAndSetFalse(string stateName)
    {
        // wait for 1 second
        yield return new WaitForSeconds(timeToWaitBeforeResettingState);

        // then set corresponding boolean to false
        switch (stateName)
        {
            case "isLeftIndexTouchingRightIndex":
                isLeftIndexTouchingRightIndex = false;
                break;
            case "isLeftIndexTouchingRightThumb":
                isLeftIndexTouchingRightThumb = false;
                break;
            case "isLeftThumbTouchingRightIndex":
                isLeftThumbTouchingRightIndex = false;
                break;
            case "isRightThumbTouchingLeftThumb":
                isRightThumbTouchingLeftThumb = false;
                break;
        }

        // and remove the coroutine from the dictionary
        touchStateCoroutines.Remove(stateName);
    }
}
