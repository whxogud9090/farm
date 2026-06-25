using UnityEngine;

public class Gatherable : Interactable
{
    [SerializeField] private ItemData item;
    [SerializeField] private int amount = 1;
    [SerializeField] private bool destroyAfterGather = true;

    public override void Interact(GameObject actor)
    {
        Inventory inventory = actor.GetComponent<Inventory>();
        if (inventory == null)
        {
            return;
        }

        inventory.Add(item, amount);

        if (destroyAfterGather)
        {
            Destroy(gameObject);
        }
    }
}
