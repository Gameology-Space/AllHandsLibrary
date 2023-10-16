using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventWrapperDebugLog : MonoBehaviour
{

    // Function to be called by event, show debug log the name of the object which this script is attached to
    public void DebugLog(GameObject CallingEvent)
    {
        Debug.Log("<color=green>" + CallingEvent.name + "</color>");
    }
}
