using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    //public Text nameText;
    public Button buyButton;
    public Text cashText;
    public Text costText;
    public Text descriptionText;
    public Image iconImage;
    public Powerups Powerups;
    public Player Player;
    private ItemData data;
    private int currentCost;

    public void Setup(ItemData data)
    {
        //nameText.text = data.name; // obsolete due to powerup name being present on sprite
        this.data = data;
        cashText.text = "Cash: $" + Player.GetMoney();
        CalculateCost();
        costText.text = "Cost: " + currentCost.ToString();
        descriptionText.text = data.description;
        iconImage.sprite = data.icon;
        
        // enable buy
        buyButton.interactable = true;
        iconImage.color = Color.white;
    }
    
    private void CalculateCost()
    {
        // base cost = 10% of player's cash
        float baseCost = Player.GetMoney() * 0.01f;
        // random offset between -5% and +5% of player cash
        float offset = Player.GetMoney() * 0.005f;
        float randomOffset = Random.Range(-offset, offset);
        currentCost = Mathf.RoundToInt(data.cost * (baseCost + randomOffset));
        // ensure minimum cost is at least 1
        if (currentCost < 1)
            currentCost = 1;
    }
    public void Buy()
    {
        if (Player.GetMoney() >= currentCost)
        {
            Player.AdjustMoney(-currentCost);
            cashText.text = "Cash: $" + Player.GetMoney();
            Powerups.AddPowerup(data.type);
            Debug.Log("Bought " + data.name);
            
            // disable after buy
            buyButton.interactable = false;
            iconImage.color = Color.gray; 
        }
        else
        {
            Debug.Log("Not enough money!");
        }
    }
}