using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    // create SerializeField for walkSpeed
    [Range (0f,5f)]
    float currentSpeed = 1f;
    GameObject currentTarget;

    // init
    private void Awake()
    {
        LevelController levelController = FindObjectOfType<LevelController>();
        if (levelController != null)
        {
            levelController.AttackerSpawned();
        }
    }

    //deinit
    private void OnDestroy()
    {
        LevelController levelController = FindObjectOfType<LevelController>();
        if (levelController != null)
        {
            levelController.AttackerKilled();
        }
    }

    void Update()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
        UpdateAnimationState();
    }

    // make attacker stop attack 
    private void UpdateAnimationState()
    {
        if (!currentTarget)
        {
            GetComponent<Animator>().SetBool("isAttacking", false);
        }
    }

    public void SetMovementSpeed (float speed) {
        currentSpeed = speed;
    }

    
    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("isAttacking", true);
        currentTarget = target;
    }

     public void StrikeCurrentTarget(float damage)
    {
        // if has no target then return
        if (!currentTarget) { return; }
        Health health = currentTarget.GetComponent<Health>();

        if (health)
        {
            health.DealDamage(damage);
        }
    }
}
