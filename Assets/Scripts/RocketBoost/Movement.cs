using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rigidb;

    AudioSource audioSource;


    [SerializeField] float thrust = 25f;
    [SerializeField] float rotationThrust = 25f;
    [SerializeField] AudioClip mainEngine;

    void thrustMechanic()
    {
        if(Input.GetKey(KeyCode.Space))      // do keycode so you can makesure you spell the right action.
        {
            rigidb.AddRelativeForce(Vector3.up * thrust * Time.deltaTime);
            if(!audioSource.isPlaying)   // ! means false so if we are not playing then play audio
            {
                audioSource.PlayOneShot(mainEngine, 0.5f);
            }
        }
        else
        {
            audioSource.Stop();
        }
    }

    void rotationMechanic()
    {
        if(Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationThrust);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotationThrust);
        }
    }

    void ApplyRotation(float rotateThisFrame)
    {
        rigidb.freezeRotation = true;   // freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotateThisFrame * Time.deltaTime); 
        rigidb.freezeRotation = false;   // unfreeze rotation so physics system can overtake
    }

    void Update()
    {
        thrustMechanic();
        rotationMechanic();
    }

    void Start()
    {
        rigidb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }
}
