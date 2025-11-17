using UnityEngine;

public class Game : MonoBehaviour
{
    private Player player;
    private Dealer dealer;
    
    // need to reveal hands
    
    
    public void StartGame()
    {
        playerTurn();
        dealerTurn();
        determineWinner();
    }

    private void playerTurn()
    {
        while (player.IsPlaying())
        {
            // if player chooses to hit
                // hit
                
            // if player stands 
                // stands
        }
    }

    private void dealerTurn()
    {
        dealer.Play();
    }

    private void determineWinner()
    {
        if (player.GetPlayerTotal() > dealer.GetDealerTotal() && player.GetPlayerTotal() <= 21)
        {
            ShowPlayerWinner();
        }
        else if (dealer.GetDealerTotal() > 21)
        {
            ShowPlayerWinner();
        }
        else if (player.GetPlayerTotal() > 21)
        {
            ShowDealerWinner();
        }
        else
        {
            ShowDealerWinner();
        }
    }

    private void ShowPlayerWinner()
    {
        // implementation to show screen for player winning
    }

    private void ShowDealerWinner()
    {
        // implementation to show screen for dealer winning
    }
}
