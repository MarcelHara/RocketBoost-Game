using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //refs,vars
    Rigidbody rigidb;
    AudioSource audioSource;
    [SerializeField] float thrust = 25f;
    [SerializeField] float rotationThrust = 25f;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] ParticleSystem thrusterParticles;

    //movement mech
    void thrustMechanic()
    {
        if(Input.GetKey(KeyCode.Space))      // do keycode so you can makesure you spell the right action.
        {
            rigidb.AddRelativeForce(Vector3.up * thrust * Time.deltaTime);
            if (!audioSource.isPlaying)   // ! means false so if we are not playing then play audio
            {
                audioSource.PlayOneShot(mainEngine, 0.5f);
            }
            if(!thrusterParticles.isPlaying)
            {
                thrusterParticles.Play();
            }
        }
        else
        {
            thrusterParticles.Stop();
            audioSource.Stop();
        }
    }

    //rotation mech
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
    // math for rotation
    void ApplyRotation(float rotateThisFrame)
    {
        rigidb.freezeRotation = true;   // freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotateThisFrame * Time.deltaTime); 
        rigidb.freezeRotation = false;   // unfreeze rotation so physics system can overtake
    }

    //runtime
    void Update()
    {
        thrustMechanic();
        rotationMechanic();
    }

    private void Awake()
    {
        thrusterParticles = thrusterParticles.GetComponent<ParticleSystem>();
    }
    void Start()
    {
        rigidb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }
}
