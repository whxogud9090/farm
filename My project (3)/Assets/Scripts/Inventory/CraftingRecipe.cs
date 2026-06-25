using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Farm/Crafting Recipe")]
public class CraftingRecipe : ScriptableObject
{
    public List<ItemStack> ingredients = new List<ItemStack>();
    public ItemData result;
    public int resultAmount = 1;

    public bool CanCraft(Inventory inventory)
    {
        if (inventory == null || result == null)
        {
            return false;
        }

        foreach (ItemStack ingredient in ingredients)
        {
            if (!inventory.Has(ingredient.item, ingredient.amount))
            {
                return false;
            }
        }

        return true;
    }

    public bool Craft(Inventory inventory)
    {
        if (!CanCraft(inventory))
        {
            return false;
        }

        foreach (ItemStack ingredient in ingredients)
        {
            inventory.Remove(ingredient.item, ingredient.amount);
        }

        inventory.Add(result, resultAmount);
        return true;
    }
}
