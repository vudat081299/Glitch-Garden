using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] Slider volumnSlider;
    [SerializeField] float defaultVl = 0.8f;

    [SerializeField] Slider difSlider;
    [SerializeField] float defaultDif = 0f;

    // Start is called before the first frame update
    void Start()
    {
        volumnSlider.value = PlayerPrefController.GetVolumn();
        difSlider.value = PlayerPrefController.GetDif();
        
    }

    // Update is called once per frame
    void Update()
    {
        var musicPlayer = FindObjectOfType<MusicPlayer>();
        if (musicPlayer)
        {
            musicPlayer.setVolumn(volumnSlider.value);
        }
        else
        {
            Debug.Log("volumn set error");
        }
    }

    // handle save value to local
    public void SaveAndExit()
    {
        PlayerPrefController.saveVolumn(volumnSlider.value);
        PlayerPrefController.saveDif(difSlider.value);
        FindObjectOfType<LevelLoader>().LoadMainScene();
    }

    public void SetDefault()
    {
        volumnSlider.value = defaultVl;
        difSlider.value = 0f;
    }

}
