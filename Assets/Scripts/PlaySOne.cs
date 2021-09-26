using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySOne : MonoBehaviour
{
    [SerializeField] float myMass = 1f;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMyMass(float addMass)
    {
        myMass += addMass;
        transform.localScale = new Vector3(transform.localScale.x + addMass, transform.localScale.y + addMass, transform.localScale.z);
    }
    public float GetMyMass()
    {
        return myMass;
    }
}
