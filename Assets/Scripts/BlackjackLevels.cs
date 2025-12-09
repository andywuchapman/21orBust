using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackjackLevels : MonoBehaviour
{
    [Header("UI")]
    public Readouts readouts;
    public Image tableBackgroundImage;

    [Header("Tables")]
    public List<BlackJackTableContents> tableConfigs;

    [Header("Bank")]
    public int playerBank = 300;

    public int currentLevelIndex = 0;
    public int winningsAtCurrentLevel = 0;

    public int minBet;
    public int maxBet;
    public string tableName;

    void Start()
    {
        if (tableConfigs == null || tableConfigs.Count == 0)
        {
            Debug.LogError("No table configs assigned on BlackjackLevels");
            return;
        }

        LoadTable(currentLevelIndex);
    }

    private void LoadTable(int index)
    {
        if (index < 0 || index >= tableConfigs.Count)
        {
            Debug.LogError("Invalid table index: " + index);
            return;
        }

        BlackJackTableContents table = tableConfigs[index];

        winningsAtCurrentLevel = 0;

        tableName = table.tableName;
        minBet = table.minBet;
        maxBet = table.maxBet;

        if (tableBackgroundImage != null && table.tableBackground != null)
        {
            tableBackgroundImage.sprite = table.tableBackground;
        }

        if (readouts != null)
        {
            readouts.ShowLevel(index + 1);
            readouts.ShowTableInfo(table.tableName,
                                   playerBank,
                                   winningsAtCurrentLevel,
                                   table.earningsNeededToMoveUp);
        }

        Debug.Log("Loaded table: " + table.tableName +
                  " | minBet: " + minBet +
                  " | maxBet: " + maxBet +
                  " | bank: " + playerBank);
    }

    public void OnHandFinished(int netChangeInChips)
    {
        playerBank += netChangeInChips;
        winningsAtCurrentLevel += netChangeInChips;

        BlackJackTableContents currentTable = tableConfigs[currentLevelIndex];

        if (readouts != null)
        {
            readouts.UpdateBank(playerBank);
            readouts.UpdateWinnings(winningsAtCurrentLevel, currentTable.earningsNeededToMoveUp);
        }

        Debug.Log("Hand result: " + netChangeInChips +
                  " | winnings at this table: " + winningsAtCurrentLevel +
                  " | bank: " + playerBank);

        TryMoveUpTable();
    }

    public bool CanPlaceBet(int betAmount)
    {
        if (betAmount < minBet || betAmount > maxBet)
        {
            Debug.Log("Bet " + betAmount + " is outside allowed range [" + minBet + ", " + maxBet + "]");
            return false;
        }

        if (playerBank < betAmount)
        {
            Debug.Log("Not enough money to place bet. Bank: " + playerBank);
            return false;
        }

        return true;
    }

    private void TryMoveUpTable()
    {
        if (currentLevelIndex >= tableConfigs.Count - 1)
            return;

        BlackJackTableContents currentTable = tableConfigs[currentLevelIndex];
        BlackJackTableContents nextTable = tableConfigs[currentLevelIndex + 1];

        bool reachedEarningsTarget = winningsAtCurrentLevel >= currentTable.earningsNeededToMoveUp;
        bool canAffordNextTable = playerBank >= nextTable.minBet;

        if (reachedEarningsTarget && canAffordNextTable)
        {
            Debug.Log("Moving from " + currentTable.tableName + " to " + nextTable.tableName);
            currentLevelIndex++;
            LoadTable(currentLevelIndex);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            OnHandFinished(100);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            OnHandFinished(-50);
        }
    }
}



