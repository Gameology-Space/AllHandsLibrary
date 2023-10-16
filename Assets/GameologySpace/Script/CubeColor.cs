using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeColor : MonoBehaviour
{
    private Renderer rend;

    private void Start()
    {
        rend = GetComponent<Renderer>();
    }

    public void TurnTriangle()
    {
        StartCoroutine(TurnColor(new Color(64 / 255f, 226 / 255f, 160 / 255f)));
    }

    public void TurnCircle()
    {
        StartCoroutine(TurnColor(new Color(255 / 255f, 102 / 255f, 102 / 255f)));
    }

    public void TurnCross()
    {
        StartCoroutine(TurnColor(new Color(124 / 255f, 178 / 255f, 232 / 255f)));
    }

    public void TurnSquare()
    {
        StartCoroutine(TurnColor(new Color(255 / 255f, 105 / 255f, 248 / 255f)));
    }

    public void TurnBlack()
    {
        StartCoroutine(TurnColor(new Color(0 / 255f, 0 / 255f, 0 / 255f)));
    }

    private IEnumerator TurnColor(Color color)
    {
        rend.material.color = color;
        yield return new WaitForSeconds(1f);
        rend.material.color = Color.grey;
    }
}
