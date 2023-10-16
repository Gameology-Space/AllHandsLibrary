using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerStateManager : MonoBehaviour, IActiveState
{

    public enum GestureShape { TriangleCircle, Square }
    [Tooltip("Select the desired shape to be recognized.")]
    public GestureShape selectedShape;

    public bool Active
    {
        get
        {
            switch (selectedShape)
            {
                case GestureShape.TriangleCircle:
                    return FingerStates.Instance.isLeftIndexTouchingRightIndex && FingerStates.Instance.isRightThumbTouchingLeftThumb;

                case GestureShape.Square:
                    return FingerStates.Instance.isLeftIndexTouchingRightThumb && FingerStates.Instance.isLeftThumbTouchingRightIndex;

                default:
                    return false; // Default case if none of the shapes are matched
            }
        }
    }

}
