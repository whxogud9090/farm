using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    [SerializeField] private string prompt = "Interact";

    public string Prompt => prompt;

    public abstract void Interact(GameObject actor);
}
