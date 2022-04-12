using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockOscillator : MonoBehaviour
{
    Vector3 startingPos;
    [SerializeField] Vector3 movingBlock;
    [SerializeField] [Range(0,-0.5f)] float movingFactor;  // the range box makes it a slider instead of just a number
    [SerializeField] float period = 2f;  // period is how long lasting the sine wave will be aka 2 SECONDS DEFAULT

    void Start()
    {
        startingPos = transform.position; // grabs the current position of startingPos
    }

    private void Update()
    {
        OscillationMovement();
        Vector3 offset = movingBlock * movingFactor;
        transform.position = startingPos + offset;
    }

    private void OscillationMovement()
    {
        float cycles = Time.time / period; // cycles is the currenct elapsed time x period

        const float tau = Mathf.PI * 2; // tau is 2 pi, 6.28318 and is 1 complete CYCLE around the circle
        float rawsineWave = Mathf.Sin(cycles * tau);   // cycles x tau  
        movingFactor = (rawsineWave - 0.5f) / 2f;
    }
}
