using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassScore : MonoBehaviour
{
    [Tooltip ("How much mass get for object")]
    [SerializeField] float myScore;
    public float GetScore()
    {  
        
        return myScore;
        
    }
}
