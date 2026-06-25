using UnityEngine;

[CreateAssetMenu(menuName = "Farm/Item Data")]
public class ItemData : ScriptableObject
{
    public string itemId;
    public string displayName;
    public Sprite icon;
    [TextArea] public string description;
    public bool stackable = true;
}
