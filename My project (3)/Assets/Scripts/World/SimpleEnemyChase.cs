using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SimpleEnemyChase : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float detectionRange = 5f;

    private Rigidbody2D body;
    private Transform target;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        body.gravityScale = 0f;
        body.freezeRotation = true;
    }

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            target = player.transform;
        }
    }

    private void FixedUpdate()
    {
        if (target == null)
        {
            body.linearVelocity = Vector2.zero;
            return;
        }

        Vector2 toTarget = target.position - transform.position;
        if (toTarget.magnitude > detectionRange)
        {
            body.linearVelocity = Vector2.zero;
            return;
        }

        body.linearVelocity = toTarget.normalized * moveSpeed;
    }
}
