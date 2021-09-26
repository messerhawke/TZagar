using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 2f;
    [Tooltip("Range from 1 to 100, default 2")]
    [SerializeField] float difficultyMultiplier;

    bool isWandering = false;
    bool isRunning = false;
    bool isFollowing = false;
    bool isNPCStuck = false;

    float compareMass;
    GameObject opponentGameObject;
    float myCoef;
    int wayXSign, wayYSign;

    void Update()
    {
        float myMass = GetComponent<PlaySOne>().GetMyMass();
        float newMoveSpeed = moveSpeed / myMass;
        if (!isRunning | !isFollowing)
        {
            if (!isWandering)
            {
                StartCoroutine("Wander");
            }
            if (isWandering)
            {

                newMoveSpeed = moveSpeed / myMass;
                transform.position += (transform.right * Time.deltaTime * newMoveSpeed * myCoef * wayXSign) +
                                      (transform.up * Time.deltaTime * newMoveSpeed * (1 - myCoef) * wayYSign);
            }
        }
        if (isRunning)
        {
            newMoveSpeed = (moveSpeed / myMass) / (difficultyMultiplier);
            
            transform.position = Vector2.MoveTowards(transform.position, opponentGameObject.transform.position, -newMoveSpeed * Time.deltaTime);
        }
        if (isFollowing)
        {
            newMoveSpeed = (moveSpeed / myMass) / (difficultyMultiplier);
            transform.position = Vector2.MoveTowards(transform.position, opponentGameObject.transform.position, newMoveSpeed * Time.deltaTime);
        }
    }
    IEnumerator Wander()
    {
        isWandering = true;
        int wanderingTime = Random.Range(30, 150) / 60;
        myCoef = Random.Range(0, 101) / 100f;
        wayXSign = Random.Range(0, 2) * 2 - 1;
        wayYSign = Random.Range(0, 2) * 2 - 1;
        yield return new WaitForSeconds(wanderingTime);
        isWandering = false;
    }
    public void SetSearchingObject(GameObject searchResult)
    {
        opponentGameObject = searchResult;
        float myMass = GetComponent<PlaySOne>().GetMyMass();
        //Debug.Log(searchResult.name);
        compareMass = searchResult.transform.parent.GetComponent<PlaySOne>().GetMyMass();
        if (compareMass > myMass)
        {
            isRunning = true;
            isFollowing = false;
            //Debug.Log("Running...");
        }
        else if (compareMass < myMass)
        {
            isRunning = false;
            isFollowing = true;
            //Debug.Log("Following...");
        }
    }
    public void ClearSearchingObject(GameObject searchResult)
    {
        opponentGameObject = null;
        isRunning = false;
        isFollowing = false;
    }
}


