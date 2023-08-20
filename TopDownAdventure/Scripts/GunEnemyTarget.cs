using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GunEnemyTarget : MonoBehaviour
{
    //public Animator animator;
    //public Animator animatorFire;
    public Transform swordPivot; // Silahýn pivot noktasý
    private Transform target;
    private bool isAttacking;
    public GameObject bulletPrefab;

    public GameObject innerObject1;
    public GameObject innerObject2;

    private Animator innerAnimator1;
    private Animator innerAnimator2;


    public float fireRate = 1f;

    private float fireTimer = 0f;

    private void Start()
    {
        gameObject.GetComponentInChildren<Animator>();

        innerAnimator1 = innerObject1.GetComponent<Animator>();
        innerAnimator2 = innerObject2.GetComponent<Animator>();

        //animator = GameObject.FindGameObjectWithTag("GunBarrel").GetComponent<Animator>();
        innerAnimator1.enabled = false;
        //animatorFire = GameObject.FindGameObjectWithTag("Tree").GetComponent<Animator>();
        innerAnimator2.enabled = false;
    }

    private void Update()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 10f);
        float closestDistance = float.MaxValue;
        Transform closestTarget = null;

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                target = collider.transform;
                Vector3 direction = target.position - swordPivot.position; // Hedefe doðru olan vektör
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // Vektörün açýsý
                swordPivot.rotation = Quaternion.AngleAxis(angle, Vector3.forward); // Silah pivotunu hedefe doðru çevir
                Transform colliderTransform = collider.transform;
                float distance = Vector3.Distance(transform.position, colliderTransform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestTarget = colliderTransform;
                }
            }
        }

        target = closestTarget;
        fireTimer -= Time.deltaTime;

        if (target != null)
        {
            float distanceToTarget = Vector3.Distance(transform.position, target.position);

            if (distanceToTarget <= 10f &&fireTimer<=0)
            {
                innerAnimator1.enabled = true;
                innerAnimator2.enabled = true;
                isAttacking = true;
                innerAnimator1.SetTrigger("Attack");
                innerAnimator2.SetTrigger("Attack");

                GameObject bullet = Instantiate(bulletPrefab, swordPivot.position, swordPivot.rotation);
                fireTimer = fireRate;

            }
            else if (distanceToTarget > 10 && distanceToTarget <= 20f && isAttacking && distanceToTarget > 2f)
            {
                innerAnimator1.enabled = false;
                innerAnimator2.enabled = false;
                isAttacking = false;
            }
        }
        else
        {
            swordPivot.rotation = Quaternion.identity; // Eðer hedef yoksa silahýn pivotunu sýfýra eþitle
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 10f);
    }
}
