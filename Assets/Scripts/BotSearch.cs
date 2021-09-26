using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotSearch : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" | collision.tag == "Player")
        {
            transform.parent.GetComponent<EnemyController>().SetSearchingObject(collision.gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" | collision.tag == "Player")
        {
            transform.parent.GetComponent<EnemyController>().SetSearchingObject(collision.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" | collision.tag == "Player")
        {
            transform.parent.GetComponent<EnemyController>().ClearSearchingObject(collision.gameObject);
        }
    }


}
