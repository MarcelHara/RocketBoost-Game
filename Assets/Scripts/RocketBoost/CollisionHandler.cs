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
        int nextsceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        if(nextsceneIndex == SceneManager.sceneCountInBuildSettings)  // if the scene is the same as in index then set index to 0
        {
            nextsceneIndex = 0;
        }
        SceneManager.LoadScene(nextsceneIndex);   // loads the scene we have selected which is 0
    }
}
