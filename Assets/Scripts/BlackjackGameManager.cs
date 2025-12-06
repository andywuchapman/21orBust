using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BlackjackGameManager : MonoBehaviour
{
    public int playerChips;
    public int minBet;
    public int maxBet;
    public int deckCount;
    public bool dealerHitsSoft17;

    public Image tableBackgroundImage;      // UI image for table art
    public BlackjackLevels levelController; // link back to level system

    private int chipsBeforeHand;

    // Called by BlackjackLevels when a table is loaded
    public void ApplyTableConfig(BlackjackTableConfig config)
    {
        playerChips      = config.startingChips;
        minBet           = config.minBet;
        maxBet           = config.maxBet;
        deckCount        = config.deckCount;
        

        if (tableBackgroundImage != null && config.tableBackground != null)
        {
            tableBackgroundImage.sprite = config.tableBackground;
        }

        // Here is where you would rebuild the deck and refresh any chip UI.
    }

    // Call this at the start of a real blackjack hand
    public void StartHand()
    {
        if (playerChips < minBet)
        {
            
        }
        
    }
    
    public void EndHand()
    {
        int netChange = playerChips - chipsBeforeHand;

        if (levelController != null)
        {
            levelController.OnHandFinished(netChange);
        }
        
    }
}