using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    bool isSpawn = true;
    [SerializeField] float minSpawn = 1f;
    [SerializeField] float maxSpawn = 5f;
    [SerializeField] Attacker[] attackerPrefabsArray;
   
    IEnumerator Start() {
       while(isSpawn) {
           yield return new WaitForSeconds(Random.Range(minSpawn,maxSpawn));
           SpawnAttacker();
       }
    }

    public void StopSpawn()
    {
        isSpawn = false;
    }
    
    private void SpawnAttacker() {
        // get attackerIndex
        var attackerIndex = Random.Range(0, attackerPrefabsArray.Length);
        Spawn(attackerPrefabsArray[attackerIndex]);
    }

    // Spawn Attecker
    private void Spawn(Attacker myAttacker)
    {
        Attacker newAttecker = Instantiate(myAttacker, transform.position, transform.rotation) as Attacker;
        // instantiate as child
        newAttecker.transform.parent = transform;
    }
}
