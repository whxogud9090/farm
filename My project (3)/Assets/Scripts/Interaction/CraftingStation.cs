using System.Collections.Generic;
using UnityEngine;

public class CraftingStation : Interactable
{
    [SerializeField] private List<CraftingRecipe> recipes = new List<CraftingRecipe>();

    public override void Interact(GameObject actor)
    {
        Inventory inventory = actor.GetComponent<Inventory>();
        if (inventory == null)
        {
            return;
        }

        foreach (CraftingRecipe recipe in recipes)
        {
            if (recipe.Craft(inventory))
            {
                Debug.Log($"Crafted {recipe.result.displayName}");
                return;
            }
        }

        Debug.Log("No craftable recipe found.");
    }
}
