using UnityEngine;

public class InteractionController : MonoBehaviour
{
    [SerializeField] private KeyCode interactKey = KeyCode.E;

    private Interactable currentTarget;

    private void Update()
    {
        if (Input.GetKeyDown(interactKey) && currentTarget != null)
        {
            currentTarget.Interact(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Interactable interactable))
        {
            currentTarget = interactable;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (currentTarget != null && other.gameObject == currentTarget.gameObject)
        {
            currentTarget = null;
        }
    }
}
