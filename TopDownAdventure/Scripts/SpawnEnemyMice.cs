using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyMice : MonoBehaviour
{
    public GameObject enemyPrefab; // D��man�n prefab'� (�rne�in, bir prefab oyunda yarat�lm�� bir d��man objesi olabilir)
    public float spawnRadius = 15f; // D��man�n spawn edilebilece�i maksimum yar��ap
    public float spawnInterval = 4f; // D��manlar�n spawn edilme s�kl��� (sn)

    private float nextSpawnTime; // Bir sonraki spawn zaman�

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        { 
            Spawn(); 
            nextSpawnTime = Time.time + spawnInterval; // Bir sonraki spawn zaman�n� g�ncelle
        }
    }

    void Spawn()
    {
        // Rastgele spawn noktas� olu�tur
        Vector3 spawnPosition = Random.insideUnitCircle * spawnRadius;
        spawnPosition.z = 0f; // Z eksenini s�f�rla

        // Spawn noktas�nda d��man� yarat
        GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }

}
