using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DebugWindowItems : MonoBehaviour
{
    public GameObject DebugWindowItemsPrefab;
    public GameObject DebugWindow;
    public GameObject ScrollView;

    // Instantiate the DebugWindowItemsPrefab under the DebugWindow
    public void InstantiateDebugWindowItemsPrefab(string ItemDescription)
    {
        
        GameObject DebugWindowItems = Instantiate(DebugWindowItemsPrefab, DebugWindow.transform);
        TextMeshProUGUI DebugWindowItemsText = DebugWindowItems.GetComponent<TextMeshProUGUI>();
        DebugWindowItemsText.text = ItemDescription;

        ScrollDown scrolldown = ScrollView.GetComponent<ScrollDown>();
        scrolldown.ScrollToBottom();
    }
    
    
}
