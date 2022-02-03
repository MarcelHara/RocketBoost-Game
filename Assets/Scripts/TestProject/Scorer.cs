using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorer : MonoBehaviour
{

    int hits = 0;
    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag != "Hit")
        {
        hits++;   // you can do ++ to add 1 or just hits = hits + 1;
        Debug.Log("I have hit the object this many times: " + hits);
        }
    }
}
