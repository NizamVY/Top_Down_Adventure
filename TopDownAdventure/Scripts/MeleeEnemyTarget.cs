using UnityEngine;

public class MeleeEnemyTarget : MonoBehaviour
{
    public Animator animator;
    private Transform target;
    private bool isAttacking;

    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.enabled = false;
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

        if (target != null)
        {
            float distanceToTarget = Vector3.Distance(transform.position, target.position);

            if (distanceToTarget <= 5f && !isAttacking)
            {
                animator.enabled = true;
                isAttacking = true;
                animator.SetTrigger("Attack");
            }
            else if (distanceToTarget > 5f && distanceToTarget <= 10f && isAttacking && distanceToTarget > 5f)
            {
                animator.enabled = false;
                isAttacking = false;
            }
            else if (distanceToTarget <= 10f)
            {
                Vector3 direction = target.position - transform.position;
                transform.up = direction.normalized;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 10f);
    }
}