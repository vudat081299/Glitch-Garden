using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizard : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherCollision)
    {
        GameObject gameObj = otherCollision.gameObject;

        // if the otherObj has a defender component
        if (gameObj.GetComponent<Defender>())
        {
            // call the Attack method
            GetComponent<Attacker>().Attack(gameObj);
        }
    }
}
