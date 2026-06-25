using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float followSpeed = 8f;
    [SerializeField] private Vector3 offset = new Vector3(0f, 0f, -10f);

    private void LateUpdate()
    {
        if (target == null)
        {
            return;
        }

        Vector3 goal = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, goal, Time.deltaTime * followSpeed);
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
}
