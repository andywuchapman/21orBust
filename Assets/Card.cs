using UnityEngine;
using UnityEngine.Rendering;

public class Card : MonoBehaviour
{
    public enum Suit
    {
        Hearts,
        Diamonds,
        Clubs,
        Spades
    }

    public enum Rank
    {
        Ace = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13,
    }
    
    public Suit CardSuit { get; private set; }
    public Rank CardRank { get; private set; }
    
    public int CardValue { get; private set; }
    
    // need code for showing card sprites

    public Card(Suit suit, Rank rank)
    {
        CardSuit = suit;
        CardRank = rank;

        if (rank >= Rank.Two && rank <= Rank.Ten)
        {
            CardValue = (int)rank;
        }
        else if (rank == Rank.Jack || rank == Rank.Queen || rank == Rank.King)
        {
            CardValue = 10;
        }
        else if (rank == Rank.Ace)
        {
            CardValue = 11;
        }
}
}
