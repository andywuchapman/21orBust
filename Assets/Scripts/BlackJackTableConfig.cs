using UnityEngine;

[CreateAssetMenu(fileName = "NewBlackjackTable", menuName = "Blackjack/Table Config")]
public class BlackjackTableConfig : ScriptableObject
{
    public string tableName = "Low Stakes";

    public int requiredBuyIn = 100;
    public int startingChips = 200;
    public int minBet = 10;
    public int maxBet = 100;

    public int deckCount = 6;

    // Background sprite for this table level
    public Sprite tableBackground;

    // How much profit you need at this table to move up
    public int promotionProfitTarget = 200;
}