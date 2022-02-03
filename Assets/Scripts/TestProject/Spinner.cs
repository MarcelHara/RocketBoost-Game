using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField] float xrotate = 0f;
    [SerializeField] float yrotate = 80f;
    [SerializeField] float zrotate = 0f;
    void Update()
    {
        gameObject.transform.Rotate(xrotate * Time.deltaTime ,yrotate * Time.deltaTime,zrotate * Time.deltaTime);
    }
}
