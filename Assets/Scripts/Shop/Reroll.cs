using UnityEngine;

public class Reroll : MonoBehaviour
{
    public ShopManager shopManager;

    public void Reset()
    {
        shopManager.GenerateShopItems();
    }
}
