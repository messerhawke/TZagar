using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ColorChoose : MonoBehaviour
{
    [SerializeField] GameObject myExampleObject;
    Image myExampleImage;
    TMP_Dropdown myDropDown;
    void Start()
    {
        myDropDown = GetComponent<TMP_Dropdown>();
        myExampleImage = myExampleObject.GetComponent<Image>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetExampleColor()
    {
        if (myDropDown.value == 0)
        {
            myExampleImage.color = Color.red;
        }
        if (myDropDown.value == 1)
        {
            myExampleImage.color = Color.green;
        }
        if (myDropDown.value == 2)
        {
            myExampleImage.color = Color.blue;
        }
        if (myDropDown.value == 3)
        {
            myExampleImage.color = Color.yellow;
        }
        if (myDropDown.value == 4)
        {
            myExampleImage.color = new Color(0.9f, 0.6f, 0f, 1f);
        }
        if (myDropDown.value == 5)
        {
            myExampleImage.color = new Color(0.6f, 0.3f, 0f, 1f);
        }
        if (myDropDown.value == 6)
        {
            myExampleImage.color = Color.white;
        }
        if (myDropDown.value == 7)
        {
            myExampleImage.color = Color.black;
        }
        if (myDropDown.value == 8)
        {
            myExampleImage.color = Color.magenta;
        }
        FindObjectOfType<SettingsController>().SetPlayerColor(myExampleImage.color);
    }
}
