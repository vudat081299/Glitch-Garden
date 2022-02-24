using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DefenderButtons : MonoBehaviour
{
    [SerializeField] Defender defenderPrefabs;

    private void Start()
    {
        LabelButtonWithCost();
    }

    private void LabelButtonWithCost()
    {
        Text costText = GetComponentInChildren<Text>();
        if (!costText)
        {
            Debug.Log("costText error");
        } else
        {
            costText.text = defenderPrefabs.GetStarCost().ToString();
        }
    }

    private void OnMouseDown() {
        Debug.Log("click click");
        var buttons = FindObjectsOfType<DefenderButtons>();
        
        foreach (DefenderButtons button in buttons)
        {
            button.GetComponent<SpriteRenderer>().color = new Color32(51,51,51,255);
        }
        GetComponent<SpriteRenderer>().color = Color.white;

        FindObjectOfType<DefenderSpawners>().SetSelectedDefender(defenderPrefabs);
    }

}
