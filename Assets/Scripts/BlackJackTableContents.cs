using UnityEngine;

[CreateAssetMenu(fileName = "NewBlackjackTable", menuName = "Blackjack/Table Contents")]
public class BlackJackTableContents : ScriptableObject
{
    public string tableName;

    public int minBet;
    public int maxBet;

    public int earningsNeededToMoveUp = 200;

    public Sprite tableBackground;
}