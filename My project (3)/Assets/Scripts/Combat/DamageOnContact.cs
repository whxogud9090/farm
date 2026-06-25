using UnityEngine;

public class DamageOnContact : MonoBehaviour
{
    [SerializeField] private int damage = 1;
    [SerializeField] private float cooldown = 0.7f;

    private float lastHitTime;

    private void OnCollisionStay2D(Collision2D collision)
    {
        TryDamage(collision.gameObject);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        TryDamage(other.gameObject);
    }

    private void TryDamage(GameObject target)
    {
        if (Time.time < lastHitTime + cooldown)
        {
            return;
        }

        if (target.TryGetComponent(out Health health))
        {
            health.TakeDamage(damage);
            lastHitTime = Time.time;
        }
    }
}
