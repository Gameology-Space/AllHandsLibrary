using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HandInfoFrequency
{
    None,
    Once,
    Repeat
}

public class HandDebugSkeletonInfo : MonoBehaviour
{
    [SerializeField]
    private OVRHand hand;
    
    [SerializeField]
    private OVRSkeleton handSkeleton;

    [SerializeField]
    private HandInfoFrequency handInfoFrequency = HandInfoFrequency.Repeat;

    private bool handInfoDisplayed = false;
    private bool pauseDisplay = false;

    private void Awake()
    {
        if(!hand)
        {
            hand = GetComponent<OVRHand>();
        }
        if(!handSkeleton)
        {
            handSkeleton = GetComponent<OVRSkeleton>();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hand.IsTracked)
        {
            DisplayBoneInfo();
        }
    }

    private void DisplayBoneInfo()
    {
        foreach (var bone in handSkeleton.Bones)
        {
            Debug.Log(bone.Id + " " + bone.Transform.position);
        }
    }
}
