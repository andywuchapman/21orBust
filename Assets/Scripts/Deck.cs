using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public Sprite[] cardSprites;
    int[] cardValues = new int[53];
    private int currentIndex = 0;

    void Start()
    {
        GetCardValues();
    }

    void GetCardValues()
    {
        int num = 0;
        for (int i = 0; i < cardSprites.Length; i++)
        {
            num = i;
            num %= 13;
            if (num > 10 || num == 0)
            {
                num = 10;
            }

            cardValues[i] = num++;
        }

        currentIndex = 1;
    }

    public void Shuffle()
    {
        for(int i = cardSprites.Length -1; i > 0; --i)
        {
            int j = Mathf.FloorToInt(Random.Range(0.0f, 1.0f) * cardSprites.Length - 1) + 1;
            Sprite face = cardSprites[i];
            cardSprites[i] = cardSprites[j];
            cardSprites[j] = face;

            int value = cardValues[i];
            cardValues[i] = cardValues[j];
            cardValues[j] = value;
        }
        currentIndex = 1;
    }

    public int DealCard(Card card, bool isLastCard = false)
    {
        int index = currentIndex;
        if (isLastCard)
            index--;
        card.SetSprite(cardSprites[index]);
        card.SetValue(cardValues[index]);
        if (!isLastCard)
            currentIndex++;
        return card.GetValueOfCard();
    }

     public Sprite GetCardBack()
     {
         return cardSprites[0];
     }

     public Sprite GetTopCardSprite()
     {
         return cardSprites[currentIndex];
     }
     
}