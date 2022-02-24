using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] int timeToWait = 3;
    int currentScreneIndex;
    // Start is called before the first frame update
    void Start()
    {
        // get scene current index
        currentScreneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentScreneIndex == 0) {
            StartCoroutine(WaitForTime());
        } 
    }

    IEnumerator WaitForTime() {
        yield return new WaitForSeconds(timeToWait);
        LoadNextScene();
    }


    public void RestartScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentScreneIndex);
    }

    public void LoadMainScene()
    {
        // set timeScale to 1 when return main screen
        Time.timeScale = 1;
        SceneManager.LoadScene("Start Screen");
    }

    public void LoadOptionsScene()
    { 
        SceneManager.LoadScene("Options Screen");
    }

    public void LoadNextScene() {
        SceneManager.LoadScene(currentScreneIndex + 1);
    }

    public void LoadGameOverScene()
    {
        SceneManager.LoadScene("Lose Screen");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
