using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Shop/Item")]
public class ItemData : ScriptableObject
{
    public string name;
    public int cost;
    public Sprite icon;
    public PowerupType type;
    [TextArea]
    public string description;
}