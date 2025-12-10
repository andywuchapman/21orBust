using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackjackLevels : MonoBehaviour
{
    public Readouts readouts;
    public Image tableBackgroundImage;
    public List<BlackJackTableContents> tables;

    public List<GameObject> tableVisuals;

    public int playerBank = 300;

    private int currentLevel = 0;
    private int winningsAtCurrentTable = 0;

    void Start()
    {
        currentLevel = 0;
        ApplyCurrentTable();
    }

    public void OnHandFinished(int netChangeInChips)
    {
        playerBank += netChangeInChips;
        winningsAtCurrentTable += netChangeInChips;

        UpdateReadouts();
        AdjustTable();
    }

    public bool CanPlaceBet(int betAmount)
    {
        BlackJackTableContents t = tables[currentLevel];

        if (betAmount < t.minBet || betAmount > t.maxBet)
            return false;

        if (playerBank < betAmount)
            return false;

        return true;
    }

    private void ApplyCurrentTable()
    {
        if (tables == null || tables.Count == 0)
            return;

        if (currentLevel < 0 || currentLevel >= tables.Count)
            currentLevel = 0;

        BlackJackTableContents t = tables[currentLevel];

        winningsAtCurrentTable = 0;

        if (tableBackgroundImage != null && t.tableBackground != null)
            tableBackgroundImage.sprite = t.tableBackground;

        if (tableVisuals != null && tableVisuals.Count > 0)
        {
            for (int i = 0; i < tableVisuals.Count; i++)
            {
                if (tableVisuals[i] != null)
                    tableVisuals[i].SetActive(i == currentLevel);
            }
        }

        UpdateReadouts();
        Debug.Log("Now at table: " + t.tableName);
    }

    private void UpdateReadouts()
    {
        if (readouts == null)
            return;

        BlackJackTableContents t = tables[currentLevel];

        readouts.ShowLevel(currentLevel + 1);
        readouts.ShowTableInfo(
            t.tableName,
            playerBank,
            winningsAtCurrentTable,
            t.earningsNeededToMoveUp
        );
    }

    private void AdjustTable()
    {
        if (tables == null || tables.Count == 0)
            return;

        BlackJackTableContents current = tables[currentLevel];

        if (currentLevel < tables.Count - 1)
        {
            BlackJackTableContents next = tables[currentLevel + 1];
            bool reachedTarget = winningsAtCurrentTable >= current.earningsNeededToMoveUp;
            bool canAffordNext = playerBank >= next.minBet;

            if (reachedTarget && canAffordNext)
            {
                currentLevel++;
                ApplyCurrentTable();
                current = tables[currentLevel];
            }
        }

        while (currentLevel > 0 && playerBank < tables[currentLevel].minBet)
        {
            currentLevel--;
            ApplyCurrentTable();
        }
    }
}




