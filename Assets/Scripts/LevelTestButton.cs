using UnityEngine;

public class LevelTestButton : MonoBehaviour
{
    [Tooltip("Net result of this hand for the player. Positive = win, Negative = loss.")]
    public int moneyDelta = 100;          // set in Inspector: +100 or -200

    private BlackjackLevels blackjackLevels;

    public void OnClick()
    {
        if (blackjackLevels == null)
            blackjackLevels = FindObjectOfType<BlackjackLevels>();

        if (blackjackLevels == null)
        {
            Debug.LogWarning("LevelTestButton: No BlackjackLevels found in scene.");
            return;
        }

        blackjackLevels.ApplyHandResult(moneyDelta);
    }
}



