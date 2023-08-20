using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public float attackDistance = 2f;   // Saldýrý mesafesi
    public float turnSpeed = 10f;       // Dönüþ hýzý

    private GameObject closestEnemy;    // En yakýn düþman
    private Animator anim;              // Animatör bileþeni

    private void Start()
    {
        anim = GetComponent<Animator>();    // Animatör bileþenini al
    }

    private void Update()
    {
        FindClosestEnemy();                 // En yakýn düþmaný bul
        AttackIfInRange();                  // Mesafeye göre saldýrý yap
    }

    private void FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");  // "Enemy" etiketli tüm objeleri al
        float closestDistance = Mathf.Infinity;                              // En yakýn mesafeyi sonsuz olarak ayarla

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);  // Kendi pozisyonundan düþman pozisyonuna olan mesafeyi hesapla

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
            float distanceToEnemy = Vector3.Distance(transform.position, closestEnemy.transform.position);  // Kendi pozisyonundan en yakýn düþman pozisyonuna olan mesafeyi hesapla

            if (distanceToEnemy <= attackDistance)
            {
                anim.SetTrigger("Attack");                   // Attack animasyonunu tetikle
                Vector3 direction = (closestEnemy.transform.position - transform.position).normalized;   // Hedefe doðru normalleþtirilmiþ yön vektörü al
                Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));  // Yönü belirle
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);  // Dönüþü saðla
            }
        }
    }
}
