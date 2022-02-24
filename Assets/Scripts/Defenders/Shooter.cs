using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile, gun;
    AttackerSpawner myLaneSpawner;
    Animator shooterAnimator;
    GameObject projectileParent;

    private void Start()
    {
        SetLaneSpawner();
        shooterAnimator = GetComponent<Animator>();
        createParent();

    }

    private void Update()
    {
        if (IsAttackerInLane())
        { 
            shooterAnimator.SetBool("atackOrNot", true);
        } else
        {
            shooterAnimator.SetBool("atackOrNot", false);
        }
    }

    private void createParent()
    {
        projectileParent = GameObject.Find("Projectiles");
        if (!projectileParent)
        {
            projectileParent = new GameObject("Projectiles"); 
        }
    }

    private void SetLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();

        foreach (AttackerSpawner spawner in spawners )
        {
            bool isInSameLane = (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);

            if (isInSameLane)
            {
                myLaneSpawner = spawner;
            }
        }
    }

    public bool IsAttackerInLane()
    {
        // if my lane spawner child count less or equal to 0 return fale
        if (myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        } else
        {
            return true;
        }
    }
    public void Fire() {
       GameObject newObj = Instantiate(projectile, gun.transform.position, transform.rotation) as GameObject;
        newObj.transform.parent = projectileParent.transform;
    }
}
