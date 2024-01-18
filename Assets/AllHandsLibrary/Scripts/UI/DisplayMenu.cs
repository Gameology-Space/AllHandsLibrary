using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayMenu : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private Vector3 menuLocation;
    [SerializeField] private GameObject headRotation;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnMenu(string handside)
    {
        if (handside == "left")
        {
            menuLocation = FingerTrackingWithBone.instance.leftIndexFingerPos;
        }
        else if (handside == "right")
        {
            menuLocation = FingerTrackingWithBone.instance.rightIndexFingerPos;
        }
        else
        {
            Debug.Log("Error: handside must be either 'left' or 'right'");
        }

        //move menu to location, set active
        menu.transform.position = menuLocation;
        menu.transform.rotation = Quaternion.Euler(30f, headRotation.transform.rotation.eulerAngles.y, 0f);
        menu.SetActive(true);
    }

    public void HideMenu()
    {
        if (menu.activeSelf)
        { 
            menu.SetActive(false);
        }
    }
}
