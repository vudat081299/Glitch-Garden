using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollider : MonoBehaviour
{
    // gameObject hit colliderBox
    private void OnTriggerExit2D(Collider2D collision)
    {
        FindObjectOfType<BaseLife>().DecreaseLife();
        if (collision.gameObject != null) {
            Destroy(collision.gameObject);
        }
    }
}
