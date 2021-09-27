using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class LeaderboardController : MonoBehaviour
{
    private int maxEntries = 5;
    private int numberOfEntries = 0;
    private Transform leaderboarTempalte;
    private Transform leaderboarContainer;
    private List<LeaderBoardEntry> leaderBoardList;
    private List<Transform> leaderBoardTransformList;

    private void Awake()
    {
        leaderBoardList = new List<LeaderBoardEntry>()//EXAMPLE 
        {
            new LeaderBoardEntry { score = 0, name = "---"},
            new LeaderBoardEntry { score = 0, name = "---"},
            new LeaderBoardEntry { score = 0, name = "---"},
            new LeaderBoardEntry { score = 0, name = "---"},
            new LeaderBoardEntry { score = 0, name = "---"}
        };
    }
    private void Start()
    {
        InvokeRepeating("TableCAll", 0, 2);
    }

    private void CreateHighScoreEntryTransform(LeaderBoardEntry highScoreEntry, Transform container, List<Transform> transformList)
    {
        if (numberOfEntries < maxEntries)
        {
            float templateHeight = 40f;
            Transform entryTransform = Instantiate(leaderboarTempalte, container);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
            entryTransform.gameObject.SetActive(true);
            int score = highScoreEntry.score;
            entryTransform.Find("ScoreText").GetComponent<TextMeshProUGUI>().text = score.ToString();
            string name = highScoreEntry.name;
            entryTransform.Find("NameText").GetComponent<TextMeshProUGUI>().text = name;
            numberOfEntries++;
            transformList.Add(entryTransform);
        }
    }

    private class LeaderBoardEntry
    {
        public int score;
        public string name;
        
    }

    private void TableCAll()
    {
        if(GameObject.FindGameObjectsWithTag("TableBoard").Length > 1)
            for (int j = 1; j <= GameObject.FindGameObjectsWithTag("TableBoard").Length; j++)
            {
                GameObject.Destroy(GameObject.Find("LeaderboardContainer").transform.GetChild(j).gameObject);
            }
        numberOfEntries = 0;
        leaderboarContainer = transform.Find("LeaderboardContainer");
        leaderboarTempalte = leaderboarContainer.Find("LeaderBoardLine");
        leaderboarTempalte.gameObject.SetActive(false);

        for (int i = 0; i < FindObjectOfType<Spawner>().transform.GetChild(1).transform.childCount; i++)
        {
            string newName = FindObjectOfType<Spawner>().transform.GetChild(1).transform.GetChild(i).name;
            int newScore = (int)((FindObjectOfType<Spawner>().transform.GetChild(1).transform.GetChild(i).GetComponent<PlaySOne>().GetMyMass() * 100) - 99);
            leaderBoardList.Add(new LeaderBoardEntry() { score = newScore, name = newName });
        }
        if (FindObjectsOfType<PlayerController>().Length >= 1)
        {
            string newName = "YOU";
            int newScore = (int)((FindObjectOfType<PlayerController>().GetComponent<PlaySOne>().GetMyMass() * 100) - 99);
            leaderBoardList.Add(new LeaderBoardEntry() { score = newScore, name = newName });
        }
        
        for (int i = 0; i < leaderBoardList.Count; i++)//SORT
        {
            for (int j = i + 1; j < leaderBoardList.Count; j++)
            {
                if (leaderBoardList[j].score > leaderBoardList[i].score)
                {
                    LeaderBoardEntry tmp = leaderBoardList[i];
                    leaderBoardList[i] = leaderBoardList[j];
                    leaderBoardList[j] = tmp;
                }
            }
        }
        leaderBoardList = leaderBoardList.GroupBy(t => t.name).Select(g => g.First()).ToList();
        leaderBoardTransformList = new List<Transform>();
        if (numberOfEntries <= maxEntries)
            foreach (LeaderBoardEntry highScoreEntry in leaderBoardList)
            {
                CreateHighScoreEntryTransform(highScoreEntry, leaderboarContainer, leaderBoardTransformList);
            }
    }
}
