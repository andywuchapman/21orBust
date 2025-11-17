using UnityEngine;

public class Player : MonoBehaviour
{
    private Hand hand;
    private bool IsStanding = false;

    public int Hit()
    {
        if (IsStanding)
        {
            return -1;
        }
        
        hand.AddCardToHand();
        return hand.ComputeHandTotal();
    }

    public int Stand()
    {
        IsStanding = true;
        return hand.ComputeHandTotal(); 
    }

    public int GetPlayerTotal()
    {
        return hand.TotalValue();
    }

    public bool IsPlaying()
    {
        if (!hand.IsBust())
        {
            return true;
        }
        return false;
    }

    public void Reset()
    {
        IsStanding = false;
        hand.ClearHand();
    }
    
    // show player hand 
        // show both cards and new cards that are added to hand 
        
    // functionality for player to determine if ace is 1 or 11
}
