using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Tooltip("PlayZone Coords")]
    [SerializeField] float minX;
    [SerializeField] float maxX;
    [SerializeField] float minY;
    [SerializeField] float maxY;
    [Tooltip("Amount of Enemies")]
    [SerializeField] int minEnemies;
    [SerializeField] int maxEnemies;
    [Tooltip("Size of Enemies")]
    [SerializeField] int minMass;
    [SerializeField] int maxMass;
    [Tooltip("Amount of Food in PlayZone")]
    [SerializeField] int maxPellets;
    [Tooltip("Respawn time")]
    [SerializeField] float timePellets;
    [SerializeField] float timeEnemies;
    [SerializeField] GameObject myEnemyFab;
    [SerializeField] GameObject pelletFab;
    Color[] myListColors = new Color[] { Color.red, Color.green, Color.blue, Color.yellow, Color.white, Color.black, Color.magenta };
    //[SerializeField] GameObject enemyFab;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.GetChild(0).transform.childCount < maxPellets)
        {
            //SpawnNextFood();
            //Invoke("SpawnNextFood", timePellets);
            StartCoroutine(SpawnNextObject(pelletFab, 0, timePellets));
        }
        if (transform.GetChild(1).transform.childCount < minEnemies)
        {
            //SpawnNextFood();
            StartCoroutine(SpawnNextObject(myEnemyFab, 1, timeEnemies));
        }
        if (transform.GetChild(1).transform.childCount > maxEnemies)
        {
            Destroy(transform.GetChild(1).transform.GetChild(transform.GetChild(1).transform.childCount));
        }
    }

    void SpawnNextFood()
    {
        GameObject newBox = Instantiate(pelletFab);
        newBox.transform.SetParent(transform.GetChild(0));
        newBox.GetComponent<SpriteRenderer>().color = myListColors[Random.Range(0, myListColors.Length)];
        float tmp1 = Random.Range(minX, maxX);
        float tmp2 = Random.Range(minY, maxY);
        float tmpSum = Mathf.Abs(tmp1) + Mathf.Abs(tmp2);
        
        if (Mathf.Abs(tmp1) > maxX)
            if (tmp1 > 0)
                tmp1 = maxX;
            else if (tmp1 < 0)
                tmp1 = -maxX;
        if (Mathf.Abs(tmp2) > maxY)
            if (tmp2 > 0)
                tmp2 = maxY;
            else if (tmp2 < 0)
                tmp2 = -maxY;
        newBox.transform.position = new Vector3(tmp1, tmp2, 0);
    }

    IEnumerator SpawnNextObject(GameObject myFab, int childIndex, float myTime)
    {
        
        GameObject newObject = Instantiate(myFab);
        newObject.transform.SetParent(transform.GetChild(childIndex));
        if (myFab.name == "myEnemy")
        {
            newObject.transform.GetChild(0).GetComponent<SpriteRenderer>().color = myListColors[Random.Range(0, myListColors.Length)];
            float myRandomMass = Random.Range(minMass, maxMass);
            newObject.GetComponent<PlaySOne>().SetMyMass(myRandomMass);
        }
        else
            newObject.GetComponent<SpriteRenderer>().color = myListColors[Random.Range(0, myListColors.Length)];
        float tmp1 = Random.Range(minX, maxX);
        float tmp2 = Random.Range(minY, maxY);
        float tmpSum = Mathf.Abs(tmp1) + Mathf.Abs(tmp2);

        if (Mathf.Abs(tmp1) > maxX)
            if (tmp1 > 0)
                tmp1 = maxX;
            else if (tmp1 < 0)
                tmp1 = -maxX;
        if (Mathf.Abs(tmp2) > maxY)
            if (tmp2 > 0)
                tmp2 = maxY;
            else if (tmp2 < 0)
                tmp2 = -maxY;
        newObject.transform.position = new Vector3(tmp1, tmp2, 0);
        yield return new WaitForSeconds(myTime);
    }
}
