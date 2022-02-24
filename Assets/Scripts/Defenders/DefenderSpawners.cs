using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawners : MonoBehaviour
{
    Defender defender;
    GameObject defenderParent;


    private void Start()
    {
        CreateDefenderParent();
    }

    private void CreateDefenderParent()
    {
        defenderParent = GameObject.Find("Defenders");
        if (!defenderParent)
        {
            defenderParent = new GameObject("Defenders");
        }
    }

    // get mouse click
    private void OnMouseDown() {

        AttempToPlaceDefenderAt(getPositionClick());
    }

    // set selectedDefender
    public void SetSelectedDefender(Defender selectedDefender)
    {
        defender = selectedDefender;
    }

    // place defender with position
    private void AttempToPlaceDefenderAt(Vector2 gridPos) 
    {
        var StarDisplay = FindObjectOfType<StarDisplay>();
        int defenderCost = defender.GetStarCost();

        // check have enough Star to spawm
        if (StarDisplay.HaveEnoughStar(defenderCost))
        {
            SpawnDefender(gridPos);
            StarDisplay.SpendStars(defenderCost);
        }
    }

    // return Vector2
    private Vector2 getPositionClick() {
        // get position of mouseClick
        Vector2 click = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(click);
        Vector2 gridPos = SnaptoGrid(worldPos);
        return gridPos;

    }

    private Vector2 SnaptoGrid(Vector2 rawWorldPos) {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX, newY);
    }

    private void SpawnDefender(Vector2 worldPos) {
        // instantiate new gameObject
        Defender newDefenders = Instantiate(defender, worldPos, Quaternion.identity) as Defender;
        newDefenders.transform.parent = defenderParent.transform;
    }
}
