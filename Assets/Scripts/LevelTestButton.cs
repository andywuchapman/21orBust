using UnityEngine;

public class LevelTestButton : MonoBehaviour
{
    public Player player;                // drag Player here (or leave null to auto-find)
    public BlackjackLevels blackjackLevels; // drag BackgroundManager here (or auto-find)

    [Header("Test Settings")]
    public int moneyDelta = 20;          // positive = win, negative = loss

    public void OnClick()
    {
        if (player == null)
            player = FindObjectOfType<Player>();

        if (blackjackLevels == null)
            blackjackLevels = FindObjectOfType<BlackjackLevels>();

        if (player == null || blackjackLevels == null)
        {
            Debug.LogWarning("LevelTestButton: Missing Player or BlackjackLevels reference.");
            return;
        }

        // Simulate winning or losing money
        player.AdjustMoney(moneyDelta);
        Debug.Log($"LevelTestButton: Changed player money by {moneyDelta}. New total = {player.GetMoney()}");

        // Ask the level system to re-evaluate based on the new amount
        blackjackLevels.OnRoundEnd();
    }
}



