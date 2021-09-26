using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultInputController : MonoBehaviour
{
    [SerializeField] int scoreHolder;
    [SerializeField] Text myNameText;
    [SerializeField] string myName;
    

    public void SetScoreHolder(int myHolder)
    {
        scoreHolder = myHolder;
    }
    public void SetMyNickName()
    {
        myName = myNameText.text;
    }
    
    public void AddNewHighScore()
    {
        FindObjectOfType<SettingsStorage>().AddHighScoreEntry(myName, scoreHolder);
    }
}
