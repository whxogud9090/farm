using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] private ItemData item;
    [SerializeField] private int amount = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.TryGetComponent(out Inventory inventory))
        {
            return;
        }

        inventory.Add(item, amount);
        Destroy(gameObject);
    }
}
