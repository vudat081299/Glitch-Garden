using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        // make it actice entire of game
        DontDestroyOnLoad(this);

        audioSource = GetComponent<AudioSource>();
        // get value form playerFref (like UserDefault in swift)
        audioSource.volume = PlayerPrefController.GetVolumn();
    }

    public void setVolumn(float volumn)
    {
        audioSource.volume = volumn;
    }
}
