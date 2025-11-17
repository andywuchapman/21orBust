using UnityEngine;

public class Dealer : MonoBehaviour
{
    private Hand hand;
    private Player player;

    public void AddCard()
    {
        hand.AddCardToHand();
    }

    public int GetDealerTotal()
    {
        return hand.TotalValue();
    }

    public void Play()
    {
        while (hand.TotalValue() < 17)
        {
            AddCard();
        }
    }

    public void Reset()
    {
        hand.ClearHand();
    }
    
    // show dealer hand 
        // start with only showing one card
        // reveal second card when player is done 
}
