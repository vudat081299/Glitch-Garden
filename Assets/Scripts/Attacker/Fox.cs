using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherCollision)
    {
        GameObject otherObj = otherCollision.gameObject;

        // check the defender is gravestone
        if (otherObj.GetComponent<GraveStone>())
        {
            GetComponent<Animator>().SetTrigger("jumpTrigger");
        }
        // if the gameObj has a defender component
        else if (otherObj.GetComponent<Defender>())
        {
            // call the Attack method
            GetComponent<Attacker>().Attack(otherObj);
        }
    }
}
