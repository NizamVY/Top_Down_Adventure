using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public float attackDistance = 2f;   // Sald�r� mesafesi
    public float turnSpeed = 10f;       // D�n�� h�z�

    private GameObject closestEnemy;    // En yak�n d��man
    private Animator anim;              // Animat�r bile�eni

    private void Start()
    {
        anim = GetComponent<Animator>();    // Animat�r bile�enini al
    }

    private void Update()
    {
        FindClosestEnemy();                 // En yak�n d��man� bul
        AttackIfInRange();                  // Mesafeye g�re sald�r� yap
    }

    private void FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");  // "Enemy" etiketli t�m objeleri al
        float closestDistance = Mathf.Infinity;                              // En yak�n mesafeyi sonsuz olarak ayarla

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);  // Kendi pozisyonundan d��man pozisyonuna olan mesafeyi hesapla

            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestEnemy = enemy;
            }
        }
    }

    private void AttackIfInRange()
    {
        if (closestEnemy != null)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, closestEnemy.transform.position);  // Kendi pozisyonundan en yak�n d��man pozisyonuna olan mesafeyi hesapla

            if (distanceToEnemy <= attackDistance)
            {
                anim.SetTrigger("Attack");                   // Attack animasyonunu tetikle
                Vector3 direction = (closestEnemy.transform.position - transform.position).normalized;   // Hedefe do�ru normalle�tirilmi� y�n vekt�r� al
                Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));  // Y�n� belirle
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);  // D�n��� sa�la
            }
        }
    }
}
