using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Card card;
    public Deck deck;

    public int handValue = 0;

    public int money = 1000;
    
    public GameObject[] hand;
    public int cardIndex = 0;
    List<Card> aceList = new List<Card>();
    
    public void StartHand()
    {
        GetCard();
        GetCard();
    }

    public int GetCard(bool isDuplicate = false)
    {
        int cardValue = deck.DealCard(hand[cardIndex].GetComponent<Card>(), isDuplicate);
        hand[cardIndex].GetComponent<Renderer>().enabled = true;
        handValue += cardValue;

        if (cardValue == 1)
        {
            aceList.Add(hand[cardIndex].GetComponent<Card>());
        }

        AceCheck();
        cardIndex++;
        
        return handValue;
    }
    
    public void AceCheck()
    {
        // for each ace in the lsit check
        foreach (Card ace in aceList)
        {
            if(handValue + 10 < 22 && ace.GetValueOfCard() == 1)
            {
                // if converting, adjust card object value and hand
                ace.SetValue(11);
                handValue += 10;
            } else if (handValue > 21 && ace.GetValueOfCard() == 11)
            {
                // if converting, adjust gameobject value and hand value
                ace.SetValue(1);
                handValue -= 10;
            }
        }
    }
    
    public void AdjustMoney(int amount)
    {
        money += amount;
    }

    
    public int GetMoney()
    {
        return money;
    }


    public void ResetHand()
    {
        for (int i = 0; i < hand.Length; i++)
        {
            hand[i].GetComponent<Card>().ResetCard();
            hand[i].GetComponent<Renderer>().enabled = false;
        }

        cardIndex = 0;
        handValue = 0;
        aceList = new List<Card>();

    }

    public void ReplaceLastCardInHand()
    {
        cardIndex--;
        RemoveLastCardValueFromHandValue();
        GetCard();
    }

    public void RemoveLastCard()
    {
        cardIndex--;
        RemoveLastCardValueFromHandValue();
        hand[cardIndex].GetComponent<Renderer>().enabled = false;
    }

    private void RemoveLastCardValueFromHandValue()
    {
        Card lastCard = hand[cardIndex].GetComponent<Card>();
        handValue = handValue - lastCard.GetValueOfCard();
    }

    public void RandomizeLastCardInHand()
    {
        cardIndex--;
        RemoveLastCardValueFromHandValue();
        
        int cardValue = deck.RandomizeCard(hand[cardIndex].GetComponent<Card>());
        hand[cardIndex].GetComponent<Renderer>().enabled = true;
        handValue += cardValue;

        if (cardValue == 1)
        {
            aceList.Add(hand[cardIndex].GetComponent<Card>());
        }

        AceCheck();
        cardIndex++;
    }
}
