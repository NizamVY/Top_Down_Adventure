using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyMice : MonoBehaviour
{
    public GameObject enemyPrefab; // Düþmanýn prefab'ý (örneðin, bir prefab oyunda yaratýlmýþ bir düþman objesi olabilir)
    public float spawnRadius = 15f; // Düþmanýn spawn edilebileceði maksimum yarýçap
    public float spawnInterval = 4f; // Düþmanlarýn spawn edilme sýklýðý (sn)

    private float nextSpawnTime; // Bir sonraki spawn zamaný

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        { 
            Spawn(); 
            nextSpawnTime = Time.time + spawnInterval; // Bir sonraki spawn zamanýný güncelle
        }
    }

    void Spawn()
    {
        // Rastgele spawn noktasý oluþtur
        Vector3 spawnPosition = Random.insideUnitCircle * spawnRadius;
        spawnPosition.z = 0f; // Z eksenini sýfýrla

        // Spawn noktasýnda düþmaný yarat
        GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }

}
