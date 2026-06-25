using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<ItemStack> items = new List<ItemStack>();

    public IReadOnlyList<ItemStack> Items => items;

    public void Add(ItemData item, int amount = 1)
    {
        if (item == null || amount <= 0)
        {
            return;
        }

        if (item.stackable)
        {
            ItemStack existing = items.Find(stack => stack.item == item);
            if (existing != null)
            {
                existing.amount += amount;
                return;
            }
        }

        items.Add(new ItemStack(item, amount));
    }

    public bool Has(ItemData item, int amount = 1)
    {
        ItemStack existing = items.Find(stack => stack.item == item);
        return existing != null && existing.amount >= amount;
    }

    public bool Remove(ItemData item, int amount = 1)
    {
        ItemStack existing = items.Find(stack => stack.item == item);
        if (existing == null || existing.amount < amount)
        {
            return false;
        }

        existing.amount -= amount;
        if (existing.amount <= 0)
        {
            items.Remove(existing);
        }

        return true;
    }
}
