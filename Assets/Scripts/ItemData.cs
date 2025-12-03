using UnityEngine;

[CreateAssetMenu(menuName = "Shop/Item")]
public class ItemData : ScriptableObject
{
    public string itemName;
    public int cost;
    [TextArea]
    public string description;
}