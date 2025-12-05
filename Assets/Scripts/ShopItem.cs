using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    public Text nameText;
    public Text costText;
    public Text descriptionText;
    public Image iconImage;

    private GameObject shopItem;
    private ItemData itemData;
    private GoldManager goldManager;

    public void Setup(ItemData data, GoldManager gm)
    {
        itemData = data;
        goldManager = gm;

        nameText.text = itemData.itemName;
        costText.text = "Cost: " + itemData.cost;
        descriptionText.text = itemData.description;
        iconImage.sprite = itemData.icon;
    }

    public void Buy()
    {
        if (goldManager.SpendGold(itemData.cost))
        {
            Debug.Log("Bought " + itemData.itemName);
        }
        else
        {
            Debug.Log("Not enough gold!");
        }
    }
}