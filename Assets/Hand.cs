using UnityEngine;
using System.Collections.Generic;

public class Hand : MonoBehaviour
{
    private List<Card> hand;
    Deck deck;

    public Hand()
    {
        hand = new List<Card>();
    }

    public void AddCardToHand()
    {
        hand.Clear();

        hand.Add(deck.DealCard());
        ComputeHandTotal();
    }

    public void ClearHand()
    {
        hand.Clear();
    }

    public int ComputeHandTotal()
    {
        int total = 0;
        
        for (int i = 0; i < hand.Count; i++)
        {
            if (hand[i].CardRank == Card.Rank.Ace)
            {
                // check with player if value is 11 or 1
            }
            total += hand[i].CardValue;
        }
        return total;
    }

    public int TotalValue()
    {
        int total = 0;
        for (int i = 0; i < hand.Count; i++)
        {
            total += hand[i].CardValue;
        }
        return total;
    }

    public bool IsBust()
    {
        if (ComputeHandTotal() > 21)
        {
            return true;
        }
        return false;
    }

    public bool HasBlackjack()
    {
        if (hand.Count == 2 && ComputeHandTotal() == 21)
        {
            return true;
        }
        return false;
    }
}
