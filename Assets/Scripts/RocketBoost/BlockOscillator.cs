using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockOscillator : MonoBehaviour
{
    Vector3 startingPos;
    [SerializeField] Vector3 movingBlock;
    [SerializeField] [Range(0,-0.5f)] float movingFactor;  // the range box makes it a slider instead of just a number

    void Start()
    {
        startingPos = transform.position; // grabs the current position of startingPos
    }

    private void Update()
    {
        Vector3 offset = movingBlock * movingFactor;
        transform.position = startingPos + offset;
    }
}
