using UnityEngine;
using TMPro;

public class Readouts : MonoBehaviour
{
    public TMP_Text levelText;
    public TMP_Text tableNameText;
    public TMP_Text bankText;
    public TMP_Text winningsText;
    public TMP_Text promotionTargetText;

    public void ShowLevel(int levelNumber)
    {
        if (levelText != null)
        {
            levelText.text = "Level: " + levelNumber;
        }
    }

    public void ShowTableInfo(string tableName, int bank, int winnings, int promotionTarget)
    {
        if (tableNameText != null)
        {
            tableNameText.text = "Table: " + tableName;
        }

        UpdateBank(bank);
        UpdateWinnings(winnings, promotionTarget);
    }

    public void UpdateBank(int bank)
    {
        if (bankText != null)
        {
            bankText.text = "Bank: " + bank;
        }
    }

    public void UpdateWinnings(int winnings, int promotionTarget)
    {
        if (winningsText != null)
        {
            winningsText.text = "Winnings at this table: " + winnings;
        }

        if (promotionTargetText != null)
        {
            int remaining = promotionTarget - winnings;
            if (remaining < 0) remaining = 0;

            promotionTargetText.text = "Needed to level up: " + remaining;
        }
    }
}