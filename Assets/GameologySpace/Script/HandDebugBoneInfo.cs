using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HandDebugBoneInfo : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI boneText;

    [SerializeField]
    private MeshRenderer boneRenderer;


    private OVRBone bone;

    
  
    private string boneName;

    
    public Enums.HandSide handSide;
    public Enums.FingerName fingerName;
    
    public void AddBone(OVRBone bone, Enums.HandSide leftRight)
    {
        this.bone = bone;
        handSide = leftRight;
        boneName = bone.Id.ToString();

        if(boneName == "Hand_ThumbTip")
        {
            fingerName = Enums.FingerName.Thumb;
        }
        else if(boneName == "Hand_IndexTip")
        {
            fingerName = Enums.FingerName.Index;
        }
        else if (boneName == "Hand_MiddleTip")
        {
            fingerName = Enums.FingerName.Middle;
        }
        else if (boneName == "Hand_RingTip")
        {
            fingerName = Enums.FingerName.Ring;
        }
        else if (boneName == "Hand_PinkyTip")
        {
            fingerName = Enums.FingerName.Pinky;
        }
        else
        {
            fingerName = Enums.FingerName.NotTracked;
        }
    }   

    // Update is called once per frame
    void Update()
    {
        if (bone == null)
        {
            return;
        }

        boneText.text = bone.Id.ToString();

        if (bone.Id.ToString() == "Hand_ThumbTip")
        {
            boneRenderer.material.color = Color.red;
        }
        else if (bone.Id.ToString() == "Hand_IndexTip")
        {
            boneRenderer.material.color = Color.green;
        }
        else if (bone.Id.ToString() == "Hand_MiddleTip")
        {
            boneRenderer.material.color = Color.blue;
        }
        else if (bone.Id.ToString() == "Hand_RingTip")
        {
            boneRenderer.material.color = Color.yellow;
        }
        else if (bone.Id.ToString() == "Hand_PinkyTip")
        {
            boneRenderer.material.color = Color.magenta;
        }
        else
        {
            boneRenderer.material.color = Color.white;
        }


        boneText.transform.rotation = Quaternion.LookRotation(boneText.transform.position - Camera.main.transform.position);
        transform.position = bone.Transform.position;
        transform.rotation = bone.Transform.rotation;
    }

}
