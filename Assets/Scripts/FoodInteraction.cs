using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodInteraction : MonoBehaviour
{
    //[SerializeField] GameObject myDeathUI;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Food")
        {
            transform.parent.GetComponent<PlaySOne>().SetMyMass(collision.gameObject.GetComponent<PlaySOne>().GetMyMass());
            Object.Destroy(collision.gameObject);
        }
        if (collision.tag == "DZ")
        {
            float compareMass = collision.transform.parent.GetComponent<PlaySOne>().GetMyMass();
            float myMass = transform.parent.GetComponent<PlaySOne>().GetMyMass();
            if (compareMass < myMass)
            {
                transform.parent.GetComponent<PlaySOne>().SetMyMass(collision.transform.parent.GetComponent<PlaySOne>().GetMyMass());
                if(collision.transform.parent.name == "play1")
                {
                    GameObject.Find("UI").transform.GetChild(0).gameObject.SetActive(true);
                    FindObjectOfType<PlayerController>().SetControl(true);
                }
                Object.Destroy(collision.transform.parent.gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
