using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResultsController : MonoBehaviour
{
    [SerializeField] int maxEntries;
    int numberOfEntries = 0;
    private Transform entryTempalte;
    private Transform entryContainer;
    private List<SettingsStorage.HighScoreEntry> highScoreEntryList;
    private List<Transform> highScroreEntryTransformList;

    private void Awake()
    {
        entryContainer = transform.Find("AllEntries");
        entryTempalte = entryContainer.Find("TemplateEntry");
        entryTempalte.gameObject.SetActive(false);
        highScoreEntryList = FindObjectOfType<SettingsStorage>().GetHighScoreEntry();


        for (int i = 0; i < highScoreEntryList.Count; i++)//SORT
        {
            for (int j = i + 1; j < highScoreEntryList.Count; j++)
            {
                if(highScoreEntryList[j].score > highScoreEntryList[i].score)
                {
                    SettingsStorage.HighScoreEntry tmp = highScoreEntryList[i];
                    highScoreEntryList[i] = highScoreEntryList[j];
                    highScoreEntryList[j] = tmp;
                }
            }
        }
        highScroreEntryTransformList = new List<Transform>();
        if(numberOfEntries <= maxEntries)
        foreach (SettingsStorage.HighScoreEntry highScoreEntry in highScoreEntryList)
        {
            CreateHighScoreEntryTransform(highScoreEntry, entryContainer, highScroreEntryTransformList);
        }
        
    }

    private void CreateHighScoreEntryTransform(SettingsStorage.HighScoreEntry highScoreEntry, Transform container, List<Transform> transformList)
    {
        if(numberOfEntries < maxEntries)
        {
            float templateHeight = 40f;
            Transform entryTransform = Instantiate(entryTempalte, container);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
            entryTransform.gameObject.SetActive(true);

            int rank = transformList.Count + 1;
            string rankString;
            switch (rank)
            {
              case 1: rankString = "1ST"; break;
              case 2: rankString = "2ND"; break;
              case 3: rankString = "3RD"; break;
              default: rankString = rank + "TH"; break;
            }

            entryTransform.Find("PositionText").GetComponent<TextMeshProUGUI>().text = rankString;
            int score = highScoreEntry.score;
            entryTransform.Find("ScoreText").GetComponent<TextMeshProUGUI>().text = score.ToString();
            string name = highScoreEntry.name;
            entryTransform.Find("NameText").GetComponent<TextMeshProUGUI>().text = name;
            numberOfEntries++;
            transformList.Add(entryTransform);
        }
    }
}
