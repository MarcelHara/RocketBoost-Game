using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        switch(other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Hit Friendly");
                break;
            case "Finish":
                Debug.Log("Finished Game");
                break;
            case "Fuel":
                Debug.Log("Hit Fuel");
                break;
            default:
                Debug.Log("Hit object you blew up");
                break;
        }
    }
}
