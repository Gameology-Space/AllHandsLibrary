using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HandDebugBoneDisplay : MonoBehaviour
{
    [SerializeField]
    private OVRHand hand;

    [SerializeField]
    private OVRSkeleton handskeleton;

    [SerializeField]
    private GameObject pointerPosePrefab;

    [SerializeField]
    private GameObject bonePrefab;





    private Transform pointerPose;

    private bool bonesAdded;

    [SerializeField]
    private Enums.HandSide handSide;

    private void Awake()
    {
        if(!handskeleton)
        {
            handskeleton = hand.GetComponent<OVRSkeleton>();
       
        }
        if(!hand)
        {
            hand = GetComponent<OVRHand>();
        }
        Debug.Log("<color=green>" + transform.name.ToString() + "</color>");

        if (transform.name.ToString() == "LeftHand")
        {
            handSide = Enums.HandSide.Left;
        }
        else if (transform.name.ToString() == "RightHand")
        {
            handSide = Enums.HandSide.Right;
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
            if (!pointerPose)
            {
                pointerPose = Instantiate(pointerPosePrefab).transform;
            }

            if (hand.IsPointerPoseValid)
            {
                pointerPose.position = hand.PointerPose.position;
                pointerPose.rotation = hand.PointerPose.rotation;
            }

            if (!bonesAdded)
            {
                CreateBones();
            }   
        }
    }

    private void CreateBones()
    {
        foreach (var bone in handskeleton.Bones)
        {
            Instantiate(bonePrefab, bone.Transform)
                .GetComponent<HandDebugBoneInfo>()
                .AddBone(bone, handSide);
        }
        bonesAdded = true;
    }
}
