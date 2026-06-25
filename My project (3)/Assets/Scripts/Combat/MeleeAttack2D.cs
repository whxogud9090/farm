using System.Collections;
using UnityEngine;

public class MeleeAttack2D : MonoBehaviour
{
    [SerializeField] private KeyCode attackKey = KeyCode.Space;
    [SerializeField] private int damage = 1;
    [SerializeField] private float range = 0.8f;
    [SerializeField] private float radius = 0.35f;
    [SerializeField] private float cooldown = 0.35f;
    [SerializeField] private LayerMask targetLayers;

    private PlayerController2D controller;
    private bool canAttack = true;

    private void Awake()
    {
        controller = GetComponent<PlayerController2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(attackKey) && canAttack)
        {
            StartCoroutine(Attack());
        }
    }

    private IEnumerator Attack()
    {
        canAttack = false;

        Vector2 direction = controller != null ? controller.FacingDirection : Vector2.down;
        Vector2 center = (Vector2)transform.position + direction.normalized * range;
        Collider2D[] hits = Physics2D.OverlapCircleAll(center, radius, targetLayers);

        foreach (Collider2D hit in hits)
        {
            if (hit.TryGetComponent(out Health health))
            {
                health.TakeDamage(damage);
            }
        }

        yield return new WaitForSeconds(cooldown);
        canAttack = true;
    }

    private void OnDrawGizmosSelected()
    {
        Vector2 direction = controller != null ? controller.FacingDirection : Vector2.down;
        Vector2 center = (Vector2)transform.position + direction.normalized * range;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(center, radius);
    }
}
