using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPositionMover : MonoBehaviour
{

    [SerializeField] float moveSpeed = 10f;       // Serializefield puts it in the editor
    
    // Start is called before the first frame update
    void Start()
    {
        PrintInstructions();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();         // we want it to constantly call playermovement per frame.
    }

    void PrintInstructions()
    {
        Debug.Log("The Method worked");
    }

    void PlayerMovement()       // this is a method
    {
        float xValue = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float zValue = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        transform.Translate(xValue,0,zValue);
        Debug.Log("PlayerMoving");
    }
}
