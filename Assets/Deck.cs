using UnityEngine;
using System.Collections.Generic;
using Unity.Mathematics;

public class Deck : MonoBehaviour
{
    private List<Card> cards;

    public Deck()
    {
        cards = new List<Card>();
        CreateFullDeck();
        Shuffle();
    }

    private void CreateFullDeck()
    {
        cards.Clear();

        foreach (Card.Suit suit in System.Enum.GetValues(typeof(Card.Suit)))
        {
            foreach (Card.Rank rank in System.Enum.GetValues(typeof(Card.Rank)))
            {
                cards.Add(new Card(suit, rank));
            }
        }
    }

    public void Shuffle()
    {
        System.Random rng = new System.Random();

        int n = cards.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            Card temp = cards[k];
            cards[k] = cards[n];
            cards[n] = temp;
        }
    }

    public Card DealCard()
    {
        if (cards.Count == 0)
        {
            return null;
        }
        
        Card card = cards[0];
        cards.RemoveAt(0);
        return card;
    }
}
