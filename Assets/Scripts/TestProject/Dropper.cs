using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{

    [SerializeField] float timer = 3f;
    MeshRenderer renderer;
    
    Rigidbody rd;
    
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();    // caching a reference so we can use renderer anywhere so its quicker then writing getcomponent consantly
        renderer.enabled = false;

        rd = GetComponent<Rigidbody>();   //makes the gravity false when you hit start
        rd.useGravity = false;
    }
    
    void Update()
    {
        Dropping();
    }
    
    void Dropping()
    {
        if(Time.time > timer)
        {
            renderer.enabled = true;
            rd.useGravity = true;
            Debug.Log("Dropping Cubes");
        }
    }
}
