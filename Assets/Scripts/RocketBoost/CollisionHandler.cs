using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    //refs,vars
    public float waitTimer = 1f;
    AudioSource audioSource;
    [SerializeField] AudioClip audioCrash;
    [SerializeField] AudioClip audioVictory;
    [SerializeField] ParticleSystem crashParticles;
    bool isPlaying = false;
    //runtime
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        crashParticles = crashParticles.GetComponent<ParticleSystem>();
        crashParticles.Stop();
    }

    // methods
    void startCrash()
    {
        isPlaying = true;
        audioSource.PlayOneShot(audioCrash, 0.5f);
        crashParticles.Play();
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
        isPlaying = true;
        audioSource.PlayOneShot(audioVictory, 1f);
        GetComponent<Movement>().enabled = false;
        Invoke("finishGame", waitTimer);
    }

    //Collision handler

    /// <summary>
    /// using switch statements instead of just doing if else if else constantly
    /// </summary>
    /// <param name="other"></param>
    void OnCollisionEnter(Collision other)
    {

        if (isPlaying) { return; } //if isplaying is true just return. instead of writing another else statement.
        
        switch (other.gameObject.tag) // this acts as the else.
        {
            case "Friendly":
                Debug.Log("Hit Friendly not implement");
                break;
            case "Finish":
                nextSceneDelay();
                break;
            case "Fuel":
                Debug.Log("Fuel hit not implemented");
                break;
            default:
                startCrash();
                break;
        }
    }   
}
