using System.Collections.Generic;
using UnityEngine;

public class BlackjackLevels : MonoBehaviour
{
    public Readouts readouts;                     // UI for level, bank, etc.
    public List<GameObject> levelPrefabs;        
    public List<BlackjackTableConfig> tableConfigs;

    public BlackjackGameManager gameManager;     // main blackjack script

    public int playerBank = 500;                 // chips across all tables

    private GameObject levelGameObject;
    private int currentLevel = 0;
    private int winningsAtCurrentLevel = 0;      // profit at this table only

    void Start()
    {
        Debug.Log("BlackjackLevels Start called");

        if (tableConfigs == null || tableConfigs.Count == 0)
        {
            Debug.LogError("No table configs assigned on BlackjackLevels");
            return;
        }

        LoadLevel(currentLevel);
    }

    void Update()
    {
        // Test keys so you can demo the logic even without full gameplay.
        // N - move to next level
        // W - simulate winning 100 chips
        // L - simulate losing 100 chips

        if (Input.GetKeyDown(KeyCode.N))
        {
            GoToNextLevel();
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            OnHandFinished(100);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            OnHandFinished(-100);
        }
    }

    public void GoToNextLevel()
    {
        currentLevel++;

        if (IsGameOver())
        {
            Debug.Log("No more levels.");
            currentLevel = tableConfigs.Count - 1;
            return;
        }

        LoadLevel(currentLevel);
    }

    public bool IsGameOver()
    {
        return currentLevel >= tableConfigs.Count;
    }

    private void LoadLevel(int index)
    {
        Debug.Log("Loading level index " + index);

        if (levelGameObject != null)
            Destroy(levelGameObject);

        BlackjackTableConfig config = tableConfigs[index];

        winningsAtCurrentLevel = 0;

        if (playerBank < config.requiredBuyIn)
        {
            Debug.Log("Not enough money to join table: " + config.tableName);
            return;
        }

        playerBank -= config.requiredBuyIn;

        gameManager.ApplyTableConfig(config);

        if (levelPrefabs != null && levelPrefabs.Count > index && levelPrefabs[index] != null)
        {
            Vector3 pos = levelPrefabs[index].transform.position;
            levelGameObject = Instantiate(levelPrefabs[index], pos, Quaternion.identity);
        }

        if (readouts != null)
        {
            readouts.ShowLevel(index + 1);
            readouts.ShowTableInfo(config.tableName,
                                   playerBank,
                                   winningsAtCurrentLevel,
                                   config.promotionProfitTarget);
        }

        Debug.Log("Loaded table: " + config.tableName + ", bank: " + playerBank);
    }

    public void OnHandFinished(int netChangeInChips)
    {
        playerBank += netChangeInChips;
        winningsAtCurrentLevel += netChangeInChips;

        Debug.Log("Hand result: " + netChangeInChips +
                  ", Gold: " + playerBank +
                  ", winnings at this table: " + winningsAtCurrentLevel);

        if (readouts != null)
        {
            BlackjackTableConfig config = tableConfigs[currentLevel];
            readouts.UpdateBank(playerBank);
            readouts.UpdateWinnings(winningsAtCurrentLevel, config.promotionProfitTarget);
        }

        TryAutoPromote();
    }

    private void TryAutoPromote()
    {
        if (currentLevel >= tableConfigs.Count - 1)
            return;

        BlackjackTableConfig current = tableConfigs[currentLevel];
        BlackjackTableConfig next = tableConfigs[currentLevel + 1];

        bool reachedTarget = winningsAtCurrentLevel >= current.promotionProfitTarget;
        bool canAffordNext = playerBank >= next.requiredBuyIn;

        if (reachedTarget && canAffordNext)
        {
            Debug.Log("Promoting from " + current.tableName + " to " + next.tableName);
            GoToNextLevel();
        }
    }
}


