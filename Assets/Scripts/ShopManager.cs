using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public ItemData[] itemPool;
    public ShopItem[] itemSlots;
    public GoldManager goldManager;

    private void Start()
    {
        GenerateShopItems();
    }

    void GenerateShopItems()
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            int randomIndex = Random.Range(0, itemPool.Length);
            ItemData randomItem = itemPool[randomIndex];

            itemSlots[i].Setup(randomItem, goldManager);
        }
    }
}