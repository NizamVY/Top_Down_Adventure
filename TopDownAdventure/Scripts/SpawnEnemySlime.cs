using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemySlime : MonoBehaviour
{
    public GameObject enemyPrefab; // Düþmanýn prefab'ý (örneðin, bir prefab oyunda yaratýlmýþ bir düþman objesi olabilir)
    public float spawnRadius = 16f; // Düþmanýn spawn edilebileceði maksimum yarýçap
    public float spawnInterval = 8f; // Düþmanlarýn spawn edilme sýklýðý (sn)

    private float nextSpawnTime; // Bir sonraki spawn zamaný

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        { // Eðer bir sonraki spawn zamaný gelmiþse
            Spawn(); // Düþmaný spawn et
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
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }

}
