using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnPoseIcon : MonoBehaviour
{
    [SerializeField]
    List<GameObject> prefabList = new List<GameObject>();

    [SerializeField]
    private GameObject displayParent;

    public void SpawnTriangle()
    {
        GameObject element = Instantiate(prefabList[3], displayParent.transform);
        StartCoroutine(FadeAndDestroy(element));
    }

    public void SpawnCircle()
    {
        GameObject element = Instantiate(prefabList[0], displayParent.transform);
        StartCoroutine(FadeAndDestroy(element));
    }

    public void SpawnSquare()
    {
        GameObject element = Instantiate(prefabList[2], displayParent.transform);
        StartCoroutine(FadeAndDestroy(element));
    }

    public void SpawnCross()
    {
        GameObject element = Instantiate(prefabList[1], displayParent.transform);
        StartCoroutine(FadeAndDestroy(element));
    }

    public void SpawnBasicOne()
    {
        GameObject element = Instantiate(prefabList[4], displayParent.transform);
        StartCoroutine(FadeAndDestroy(element));
    }

    public void SpawnBasicTwo()
    {
        GameObject element = Instantiate(prefabList[5], displayParent.transform);
        StartCoroutine(FadeAndDestroy(element));
    }

    public void SpawnBasicThree()
    {
        GameObject element = Instantiate(prefabList[6], displayParent.transform);
        StartCoroutine(FadeAndDestroy(element));
    }

    public void SpawnBasicFour()
    {
        GameObject element = Instantiate(prefabList[7], displayParent.transform);
        StartCoroutine(FadeAndDestroy(element));
    }

    public void SpawnBasicFive()
    {
        GameObject element = Instantiate(prefabList[8], displayParent.transform);
        StartCoroutine(FadeAndDestroy(element));
    }

    public void SpawnBasicFist()
    {
        GameObject element = Instantiate(prefabList[9], displayParent.transform);
        StartCoroutine(FadeAndDestroy(element));
    }

    IEnumerator FadeAndDestroy(GameObject element)
    {
        // Wait for 3 seconds
        yield return new WaitForSeconds(3f);

        // Get the Image component and set the opacity to 50%
        Image image = element.GetComponent<Image>();
        if (image != null)
        {
            Color color = image.color;
            color.a = 0.5f; // 50% opacity
            image.color = color;
        }

        // Wait for 2 more seconds (total of 5 seconds from the start of the coroutine)
        yield return new WaitForSeconds(2f);

        // Destroy the element
        Destroy(element);
    }
}
