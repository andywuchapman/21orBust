using UnityEngine;
using UnityEngine.UI;

public class GoldManager : MonoBehaviour
{
    public int currentGold = 100;
    public Text goldText;

    private void Start()
    {
        UpdateUI();
    }

    public bool SpendGold(int amount)
    {
        if (currentGold >= amount)
        {
            currentGold -= amount;
            UpdateUI();
            return true;
        }
        return false;
    }

    public void UpdateUI()
    {
        goldText.text = "Gold: " + currentGold.ToString();
    }

}