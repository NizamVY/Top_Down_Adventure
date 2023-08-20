using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemySlime : MonoBehaviour
{
    public GameObject enemyPrefab; // D��man�n prefab'� (�rne�in, bir prefab oyunda yarat�lm�� bir d��man objesi olabilir)
    public float spawnRadius = 16f; // D��man�n spawn edilebilece�i maksimum yar��ap
    public float spawnInterval = 8f; // D��manlar�n spawn edilme s�kl��� (sn)

    private float nextSpawnTime; // Bir sonraki spawn zaman�

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        { // E�er bir sonraki spawn zaman� gelmi�se
            Spawn(); // D��man� spawn et
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
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }

}
