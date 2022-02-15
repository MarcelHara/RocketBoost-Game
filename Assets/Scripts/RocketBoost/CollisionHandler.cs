using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    public float waitTimer = 1f;
    
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
                nextSceneDelay();
                break;
            case "Fuel":
                Debug.Log("Hit Fuel");
                break;
            default:
                startCrash();
                break;
        }
    }



    void startCrash()
    {
        GetComponent<Movement>().enabled = false;
        Invoke("sceneReload", waitTimer);
    }
    void sceneReload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void finishGame()
    {
        int nextsceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        if(nextsceneIndex == SceneManager.sceneCountInBuildSettings)  // if the scene is the same as in index then set index to 0
        {
            nextsceneIndex = 0;
        }
        SceneManager.LoadScene(nextsceneIndex);   // loads the scene we have selected which is 0
    }
/// <summary>
/// added scene delay 
/// </summary>
    void nextSceneDelay()
    {
        GetComponent<Movement>().enabled = false;
        Invoke("finishGame", waitTimer);
    }
}
