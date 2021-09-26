using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    Vector3 mousePosition;
    [SerializeField] float playerSpeed;
    float newPlayerSpeed;
    float distanceOffset;
    [SerializeField]  float playerMass = 1f;
    // Start is called before the first frame update
    void Start()
    {
        distanceOffset = 1f;
        GetComponent<SpriteRenderer>().color = FindObjectOfType<SettingsController>().GetPlayerColor();
        newPlayerSpeed = playerSpeed;
    }

    void Update()
    {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        
        Vector3 offset = mousePosition - transform.position;
        float sqrLen = offset.sqrMagnitude;
        
        if (sqrLen < 100f + playerMass + distanceOffset)
        {
            newPlayerSpeed = (playerSpeed / playerMass) * ((sqrLen-100f) / (playerMass + distanceOffset));
        }
        else
        {
            newPlayerSpeed = playerSpeed / playerMass;
        }
        transform.position = Vector2.MoveTowards(transform.position, mousePosition, newPlayerSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Food")
        {
            AddMass(collision.gameObject);
            Object.Destroy(collision.gameObject);
        }
    }
    public void AddMass(GameObject collision)
    {
        float myMass = collision.GetComponent<MassScore>().GetScore();
        playerMass += myMass;
        transform.localScale = new Vector3(transform.localScale.x + myMass, transform.localScale.y + myMass, transform.localScale.z);
    }

    public float GetMassValue()
    {
        return playerMass;
    }
}
