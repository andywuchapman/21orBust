using UnityEngine;
using UnityEngine.UI;

public class EarningsBackgroundSwitcher : MonoBehaviour
{
    [System.Serializable]
    public class LevelConfig
    {
        public int minEarnings;     // how much money you need to unlock this look
        public Sprite background;   // table sprite for this level
    }

    public Image backgroundImage;     // the UI Image that shows the table
    public LevelConfig[] levels;      // list of level thresholds

    private int currentLevelIndex = -1;

    // Call this whenever the player's money changes
    public void UpdateBackground(int currentEarnings)
    {
        if (levels == null || levels.Length == 0 || backgroundImage == null)
            return;

        int bestIndex = -1;

        // Pick the highest level whose minEarnings we meet
        for (int i = 0; i < levels.Length; i++)
        {
            if (currentEarnings >= levels[i].minEarnings)
            {
                bestIndex = i;
            }
        }

        // If we qualify for a new level, change the sprite
        if (bestIndex != -1 && bestIndex != currentLevelIndex)
        {
            currentLevelIndex = bestIndex;
            backgroundImage.sprite = levels[currentLevelIndex].background;
            Debug.Log($"Switched background to level {currentLevelIndex} at earnings {currentEarnings}");
        }
    }
}