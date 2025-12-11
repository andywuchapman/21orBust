using UnityEngine;

public class BlackjackLevels : MonoBehaviour
{
    [Header("References")]
    public Player player;                

    [Header("Table Objects (backgrounds)")]
    public GameObject lowStakesTable;    
    public GameObject mediumStakesTable; 
    public GameObject highStakesTable;   

    [Header("Level Rules")]
    public int profitToLevelUp = 20;    
    public int lossToLevelDown = 300;    
    
    [SerializeField] private int currentLevel = 0;

    private int moneyAtLevelStart;

    private void Start()
    {
        if (player == null)
            player = FindObjectOfType<Player>();

        moneyAtLevelStart = player.GetMoney();
        Debug.Log($"BlackjackLevels: Start. moneyAtLevelStart = {moneyAtLevelStart}");

        UpdateTableVisuals();
    }
    
    public void ApplyHandResult(int moneyDelta)
    {
        if (player == null)
        {
            Debug.LogWarning("BlackjackLevels: No Player set.");
            return;
        }
        
        player.AdjustMoney(moneyDelta);
        int currentMoney = player.GetMoney();
        int profit = currentMoney - moneyAtLevelStart;

        Debug.Log($"BlackjackLevels: Hand result {moneyDelta}. CurrentMoney={currentMoney}, profit at this table={profit}, level={currentLevel}");
        
        bool changed = false;

      
        if (profit >= profitToLevelUp && currentLevel < 2)
        {
            currentLevel++;
            moneyAtLevelStart = currentMoney;   // reset baseline for the new table
            changed = true;
            Debug.Log($"BlackjackLevels: moved UP to level {currentLevel}");
        }
        else if (profit <= -lossToLevelDown && currentLevel > 0)
        {
            currentLevel--;
            moneyAtLevelStart = currentMoney;   // reset baseline for the new table
            changed = true;
            Debug.Log($"BlackjackLevels: moved DOWN to level {currentLevel}");
        }

        if (changed)
        {
            UpdateTableVisuals();
        }
        else
        {
            Debug.Log("BlackjackLevels: stayed at current table.");
        }
    }

    private void UpdateTableVisuals()
    {
        if (lowStakesTable != null)    lowStakesTable.SetActive(currentLevel == 0);
        if (mediumStakesTable != null) mediumStakesTable.SetActive(currentLevel == 1);
        if (highStakesTable != null)   highStakesTable.SetActive(currentLevel == 2);

        Debug.Log($"BlackjackLevels: Update visuals → level {currentLevel}. " +
                  $"Low={lowStakesTable?.activeSelf}, Med={mediumStakesTable?.activeSelf}, High={highStakesTable?.activeSelf}");
    }
}









