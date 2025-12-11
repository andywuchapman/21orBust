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
    [Tooltip("How much PROFIT (from when you sat at this table) to move UP.")]
    public int profitToLevelUp = 20;     

    [Tooltip("How much LOSS (from when you sat at this table) to move DOWN.")]
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
    
    public void ResetBaselineToCurrentMoney()
    {
        if (player == null)
            player = FindObjectOfType<Player>();

        if (player != null)
        {
            moneyAtLevelStart = player.GetMoney();
            Debug.Log($"BlackjackLevels: Baseline reset. moneyAtLevelStart = {moneyAtLevelStart}");
        }
    }
    
    public void OnRoundEnd()
    {
        if (player == null)
        {
            Debug.LogWarning("BlackjackLevels: Player reference missing.");
            return;
        }

        int currentMoney = player.GetMoney();
        int profit = currentMoney - moneyAtLevelStart;   // profit can be negative

        Debug.Log($"BlackjackLevels: OnRoundEnd → currentMoney={currentMoney}, start={moneyAtLevelStart}, profit={profit}, level={currentLevel}");

        bool changed = false;

        // Move UP if overall profit at this table is high enough
        if (profit >= profitToLevelUp && currentLevel < 2)
        {
            currentLevel++;
            moneyAtLevelStart = currentMoney;  // new baseline at new table
            changed = true;
            Debug.Log($"BlackjackLevels: moved UP to level {currentLevel}");
        }
        
        else if (profit <= -lossToLevelDown && currentLevel > 0)
        {
            currentLevel--;
            moneyAtLevelStart = currentMoney;  // new baseline at new table
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




