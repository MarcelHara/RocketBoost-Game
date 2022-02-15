using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    /// <summary>
    /// using switch statements instead of just doing if else if else constantly
    /// </summary>
    /// <param name="other"></param>
    void OnCollisionEnter(Collision other)
    {
        switch(other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Hit Friendly");
                break;
            case "Finish":
                finishGame();
                break;
            case "Fuel":
                Debug.Log("Hit Fuel");
                break;
            default:
                sceneReload();
                break;
        }
    }

    void sceneReload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void finishGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
