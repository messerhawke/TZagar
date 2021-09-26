using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    [SerializeField] AudioMixer myMixer;
    //Color myPlayerColor = Color.red;//Sozdat hranenie znachenii ETOT CLASS i sozdat obrabotchik v menuu DRUGUI CLASS
    private void Start()
    {
        myMixer.SetFloat("MyExposedVolume", Mathf.Log10(FindObjectOfType<SettingsStorage>().GetVolumeValue()) * 20);
    }
    public void SetVolumeLevel(float sliderVolume)
    {
        myMixer.SetFloat("MyExposedVolume", Mathf.Log10(sliderVolume) * 20);
        FindObjectOfType<SettingsStorage>().SetVolumeValue(sliderVolume);
    }
    public void SetPlayerColor(Color setColor)
    {
        //myPlayerColor = setColor;
        FindObjectOfType<SettingsStorage>().SetColorValue(setColor);
    }

    public Color GetPlayerColor()
    {
        return FindObjectOfType<SettingsStorage>().GetColorValue();
    }

    public float GetVolumeValue()
    {
        return FindObjectOfType<SettingsStorage>().GetVolumeValue();
    }

    public void SyncSlider()
    {
        transform.GetChild(3).GetComponent<Slider>().value = FindObjectOfType<SettingsStorage>().GetVolumeValue();
    }
}
