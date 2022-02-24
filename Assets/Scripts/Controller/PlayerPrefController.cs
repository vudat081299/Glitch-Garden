using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefController : MonoBehaviour
{
    const string MASTER_VOLUMS_KEY = "master volumn";
    const string MASTER_DIF_KEY = "master dif";

    const float minVl = 0f;
    const float maxVl = 1f;

    const float minDif = 0f;
    const float maxDif = 2f;

    public static void saveVolumn(float number)
    {
        if (number >= minVl && number <= maxVl)
        {
            PlayerPrefs.SetFloat(MASTER_VOLUMS_KEY, number);
        }
        else
        {
            Debug.Log("volumn error");
        }
    }

    public static void saveDif(float number)
    {
        if (number >= minDif && number <= maxDif)
        {
            PlayerPrefs.SetFloat(MASTER_DIF_KEY, number);
        }
        else
        {
            Debug.Log("Dif error");
        }
    }

    public static float GetVolumn()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUMS_KEY);
    }

    public static float GetDif()
    {
        return PlayerPrefs.GetFloat(MASTER_DIF_KEY);
    }
}
