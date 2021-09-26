using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float mySpeed = 2f;
    Vector3 mousePosition;
    float newPlayerSpeed;
    float distanceOffset;
    bool isControlLocked = false;
    bool isESCActive = false;
    void Start()
    {
        distanceOffset = 1f;
        transform.GetChild(0).GetComponent<SpriteRenderer>().color = FindObjectOfType<SettingsStorage>().GetColorValue();
        newPlayerSpeed = mySpeed;
    }

    void Update()
    {
        if (!isControlLocked)
        {
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

            Vector3 offset = mousePosition - transform.position;
            float sqrLen = offset.sqrMagnitude;
            float playerMass = GetComponent<PlaySOne>().GetMyMass();
            if (sqrLen < 100f + playerMass + distanceOffset)
            {
                newPlayerSpeed = (mySpeed / playerMass) * ((sqrLen - 100f) / (playerMass + distanceOffset));
            }
            else
            {
                newPlayerSpeed = mySpeed / playerMass;
            }
            transform.position = Vector2.MoveTowards(transform.position, mousePosition, newPlayerSpeed * Time.deltaTime);

            if (Input.GetButtonDown("Cancel"))
            {
                if(isESCActive == false)
                {
                    GameObject.Find("UI").transform.GetChild(1).gameObject.SetActive(true);
                    isESCActive = true;
                }
                else if (isESCActive == true)
                {
                    GameObject.Find("UI").transform.GetChild(1).gameObject.SetActive(false);
                    isESCActive = false;
                }
                    
            }
        }
    }

    public void SetControl(bool isLocked)
    {
        isControlLocked = isLocked;
    }
    public void SetESCStatus(bool isLocked)
    {
        isESCActive = isLocked;
    }
}
