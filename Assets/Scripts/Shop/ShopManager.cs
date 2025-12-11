using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public ItemData[] itemPool;
    public ShopItem[] itemSlots;
    public GameObject shopCanvas;
    public GameObject blackjackCanvas;

    private void Start()
    {
        GenerateShopItems();
    }

    public void GenerateShopItems()
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            int randomIndex = Random.Range(0, itemPool.Length);
            ItemData randomItem = itemPool[randomIndex];

            itemSlots[i].Setup(randomItem);
        }
    }
    
    public void OnContinueButtonPressed()
    {
        shopCanvas.SetActive(false);
        blackjackCanvas.SetActive(true);
    }
}