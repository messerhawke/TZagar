using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsStorage : MonoBehaviour
{
    Color colorValue = Color.red;
    float volumeValue = 1f;
    List<HighScoreEntry> highScoreEntryList;
    private void Awake()
    {
        highScoreEntryList = new List<HighScoreEntry>()//EXAMPLE 
        {
            new HighScoreEntry { score = 0, name = "---"},
            new HighScoreEntry { score = 0, name = "---"},
            new HighScoreEntry { score = 0, name = "---"},
            new HighScoreEntry { score = 0, name = "---"},
            new HighScoreEntry { score = 0, name = "---"},
            new HighScoreEntry { score = 0, name = "---"},
            new HighScoreEntry { score = 0, name = "---"},
            new HighScoreEntry { score = 0, name = "---"},
            new HighScoreEntry { score = 0, name = "---"},
            new HighScoreEntry { score = 0, name = "---"}
        };
    }

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

    public List<HighScoreEntry> GetHighScoreEntry()
    {
        return highScoreEntryList;
    }
    public void SetHighScoreEntry(List<HighScoreEntry> myHighScoreEntryList)
    {
        highScoreEntryList = myHighScoreEntryList;
    }
    public void AddHighScoreEntry(string myName, int myScore)
    {
        highScoreEntryList.Add(new HighScoreEntry() { score = myScore, name = myName });
    }
    public class HighScoreEntry
    {
        public int score;
        public string name;
    }
}
