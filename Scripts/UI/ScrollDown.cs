using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollDown : MonoBehaviour
{
    public Scrollbar scrollbar;
    [SerializeField] float scrollbarvalue;
    private float previousScrollbarSize = 1f;
    public bool scrollToBottom = true;

    // Start is called before the first frame update
    void Start()
    {
        // Scroll to the bottom of the content area
        scrollbar.value = 0f;

        scrollbar.onValueChanged.AddListener(OnScrollbarValueChanged);
    }

    private void Update()
    {
        scrollbarvalue = scrollbar.value;
    }

    // Call this method to scroll to the bottom of the content area
    public void ScrollToBottom()
    {
        if (Mathf.Approximately(scrollbar.value, 0f))
        {
            // The scrollbar is already at the bottom, do nothing.
            return;
        }

        scrollToBottom = true;
        // Scroll to the bottom of the content area
        scrollbar.value = 0f;
        previousScrollbarSize = scrollbar.size;
    }

    private void OnScrollbarValueChanged(float value)
    {
        // Check if the user is trying to scroll up
        if (value > 0f)
        {
            scrollToBottom = false;
        }

        // Check if the scrollbar size has changed and should scroll to bottom
        if (!Mathf.Approximately(previousScrollbarSize, scrollbar.size) && scrollToBottom)
        {
            // The scrollbar size has changed, update the scrollbar value
            scrollbar.value = 0f;
            previousScrollbarSize = scrollbar.size;
        }
    }

    private void OnDestroy()
    {
        // Unsubscribe from the onValueChanged event of the scrollbar
        scrollbar.onValueChanged.RemoveListener(OnScrollbarValueChanged);
    }
}
