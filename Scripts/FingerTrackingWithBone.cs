using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerTrackingWithBone : MonoBehaviour
{
    public Camera sceneCamera;
    public OVRHand leftHand;
    public OVRHand rightHand;
    public OVRSkeleton leftSkeleton;
    public OVRSkeleton rightSkeleton;

    public Transform leftHandStart;
    public Transform leftIndexFinger;
    public Transform rightHandStart;
    public Transform rightIndexFinger;

    public Vector3 leftHandStartPos;
    public Vector3 leftIndexFingerPos;
    public Vector3 rightHandStartPos;
    public Vector3 rightIndexFingerPos;

    //public Vector3 rightDirection;
    //public Vector3 leftDirection;

    //public RayInteractor leftRayInteractor;
    //public RayInteractor rightRayInteractor;

    // Make this a singleton
    public static FingerTrackingWithBone instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHandInfo(leftHand, leftSkeleton, true);
        UpdateHandInfo(rightHand, rightSkeleton, false);
        //rightDirection = rightIndexFingerPos - rightHandStartPos;
        //rightDirection = rightRayInteractor.Forward;
        //rightDirection = rightDirection.normalized;
        //leftDirection = leftIndexFingerPos - leftHandStartPos;
        //leftDirection = leftRayInteractor.Forward;
        //leftDirection = leftDirection.normalized;
    }

    void UpdateHandInfo(OVRHand hand, OVRSkeleton skeleton, bool isLeftHand)
    {
        if (hand.IsTracked)
        {
            // Loop through all the bones in the skeleton
            foreach (var b in skeleton.Bones)
            {
                // If bone is the index tip
                if (b.Id == OVRSkeleton.BoneId.Hand_Middle1)
                {
                    // Store its transform and position
                    if (isLeftHand)
                    {
                        leftIndexFinger = b.Transform;
                        leftIndexFingerPos = b.Transform.position;
                    }
                    else
                    {
                        rightIndexFinger = b.Transform;
                        rightIndexFingerPos = b.Transform.position;
                    }
                }

                // If bone is the hand start
                if (b.Id == OVRSkeleton.BoneId.Hand_Start)
                {
                    // Store its transform and position
                    if (isLeftHand)
                    {
                        leftHandStart = b.Transform;
                        leftHandStartPos = b.Transform.position;
                    }
                    else
                    {
                        rightHandStart = b.Transform;
                        rightHandStartPos = b.Transform.position;
                    }
                }
            }
        }
    }
}
