using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsStorage : MonoBehaviour
{
    Color colorValue = Color.red;
    float volumeValue = 1f;

    
    // Start is called before the first frame update
    public void SetColorValue(Color setColor)
    {
        colorValue = setColor;
    }

    public void SetVolumeValue(float volume)
    {
        volumeValue = volume;
    }

    public Color GetColorValue()
    {
        return colorValue;
    }

    public float GetVolumeValue()
    {
        return volumeValue;
    }
}
