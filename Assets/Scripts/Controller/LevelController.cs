using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] float waitToLoad = 4f;
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel;
    int numberOfAttacker = 0;
    bool levelTimerFinish = false;

    private void Start()
    {
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
    }
    // get number of attacker when spawn
    public void AttackerSpawned()
    {
        numberOfAttacker++;
    }

    // get number of attacker when kill
    public void AttackerKilled()
    {
        numberOfAttacker--;

        if (numberOfAttacker <= 0 && levelTimerFinish)
        {
            StartCoroutine(HandleWinCondition());
        }
    }

    // handle win conditon
    IEnumerator HandleWinCondition()
    {
        winLabel.SetActive(true);
        // play sound
        GetComponent<AudioSource>().Play();
        // timer
        yield return new WaitForSeconds(waitToLoad);
        // load next screen
        FindObjectOfType<LevelLoader>().LoadNextScene();
    }

    // handle lose condition
    public void HandleLoseCondition()
    {
        Time.timeScale = 0;
        loseLabel.SetActive(true);

    }

    // handle when timer is finished cd
    public void LevelTimerFinished()
    {
        levelTimerFinish = true;
        StopSpawners();
    }

    private void StopSpawners()
    {
        AttackerSpawner[] attackerSpawnerArray = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in attackerSpawnerArray)
        {
            spawner.StopSpawn();
        }
    }
}
